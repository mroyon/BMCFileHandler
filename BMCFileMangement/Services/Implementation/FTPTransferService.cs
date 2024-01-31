using BDO.Core.DataAccessObjects.CommonEntities;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using BMCFileMangement.Models;
using BMCFileMangement.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BMCFileMangement.Services.Implementation
{
    public class FTPTransferService : IFTPTransferService
    {
        private readonly IConfigurationRoot _config;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<FTPTransferService> _logger;
        private readonly IUserProfileService _userProfileService;
        private readonly FtpSettings _ftpSettings;


        public FTPTransferService(
            IConfigurationRoot config, 
            ILoggerFactory loggerFactory, 
            ILogger<FTPTransferService> logger, 
            IUserProfileService userProfileService)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<FTPTransferService>();
            _userProfileService = userProfileService;
            _ftpSettings = _config.GetSection(nameof(FtpSettings)).Get<FtpSettings>();

        }


        /// <summary>
        /// CreateUserFTPDir
        /// </summary>
        /// <param name="pathToCreate"></param>
        /// <returns></returns>
        public async Task<string> CreateUserFTPDir(string pathToCreate)
        {
            string retValue = string.Empty;
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;
            string currentDir = "";
            try
            {
                currentDir = _ftpURL + pathToCreate;

                // Create the FTP request
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri($"{currentDir}"));
                request.Credentials = new NetworkCredential(_UserName, _Password);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;

                try
                {
                    // Perform the FTP request asynchronously
                    using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                    {
                        // The status code 257 indicates that the directory was created successfully
                        if (response.StatusCode != FtpStatusCode.PathnameCreated)
                        {
                            retValue = $"Failed to create directory. Status code: {response.StatusCode}";
                        }
                    }
                }
                catch (WebException webEx)
                {
                    retValue = $"Error: {webEx.Message}";
                }
            }
            catch (WebException e)
            {
                retValue = ((FtpWebResponse)e.Response).StatusDescription;
            }
            catch (Exception ex)
            {
                retValue = $"Error: {ex.Message}";
            }

            return retValue;

        }

        /// <summary>
        /// UploadFile
        /// </summary>
        /// <param name="localFilePath"></param>
        /// <param name="remoteDirectory"></param>
        /// <param name="newFileName"></param>
        /// <returns></returns>
        public async Task<string> UploadFile(string localFilePath, string remoteDirectory,string newFileName)
        {
            string retValue = string.Empty;
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;

            string remoteFileUrl = $"{_ftpURL}{remoteDirectory}{newFileName}";

            // Create the FTP request
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(remoteFileUrl));
            request.Credentials = new NetworkCredential(_UserName, _Password);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            try
            {
                using (Stream localFileStream = File.OpenRead(localFilePath))
                using (Stream requestStream = await request.GetRequestStreamAsync())
                {
                    await localFileStream.CopyToAsync(requestStream);
                }

                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                {
                    // Check if the upload was successful (status code 226)
                    if (response.StatusCode != FtpStatusCode.ClosingData)
                    {
                        retValue = $"Failed to upload file. Status code: {response.StatusCode}";
                    }
                }
            }
            catch (WebException webEx)
            {
                retValue = $"Error: {webEx.Message}";
            }
            catch (Exception ex)
            {
                retValue = $"Error: {ex.Message}";
            }

            return retValue;
        }

        /// <summary>
        /// DeleteFile
        /// </summary>
        /// <param name="remoteFilePath"></param>
        /// <returns></returns>
        public async Task<string> DeleteFile(string remoteFilePath)
        {
            string retValue = string.Empty;
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;

            // Create the FTP request
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri($"{_ftpURL}{remoteFilePath}"));
            request.Credentials = new NetworkCredential(_UserName, _Password);
            request.Method = WebRequestMethods.Ftp.DeleteFile;

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                {
                    // Check if the deletion was successful (status code 250)
                    if (response.StatusCode != FtpStatusCode.FileActionOK)
                    {
                        retValue = $"Failed to delete file. Status code: {response.StatusCode}";
                    }
                }
            }
            catch (WebException webEx)
            {
                retValue = $"Error: {webEx.Message}";
            }
            catch (Exception  ex)
            {
                retValue = $"Error: {ex.Message}";
            }
            return retValue;
        }

        /// <summary>
        /// DownloadFile
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<Stream> DownloadFile(string remoteFilePath, string localFilePath)
        {
            Stream? retValue = null;
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri($"{_ftpURL}{remoteFilePath}"));
            request.Credentials = new NetworkCredential(_UserName, _Password);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                using (Stream responseStream = response.GetResponseStream())
                    retValue = responseStream;
            }
            catch (WebException webEx)
            {
                throw new InvalidOperationException($"Error: {webEx.Message}", webEx);
            }
            return retValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localFilePath">"path/to/local/file.txt"</param>
        /// <param name="remoteDirectory">"/remote/directory/"</param>
        /// <param name="newFileName">"new_file_name.txt"</param>
        /// <returns></returns>

    }
}
