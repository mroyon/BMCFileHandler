using AppConfig.HelperClasses;
using BDO.Core.Base;
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
using System.Threading.Tasks.Sources;
using Windows.Storage;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BMCFileMangement.Services.Implementation
{
    public class FTPTransferService : IFTPTransferService
    {
        private readonly IConfigurationRoot _config;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<FTPTransferService> _logger;
        private readonly IUserProfileService _userProfileService;
        private readonly IMessageService _msgService;
        private readonly FtpSettings _ftpSettings;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="logger"></param>
        /// <param name="userProfileService"></param>
        /// <param name="msgService"></param>
        public FTPTransferService(
            IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            ILogger<FTPTransferService> logger,
            IUserProfileService userProfileService,
            IMessageService msgService)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<FTPTransferService>();
            _userProfileService = userProfileService;
            _ftpSettings = _config.GetSection(nameof(FtpSettings)).Get<FtpSettings>();
            _msgService = msgService;
        }


        /// <summary>
        /// CreateUserFTPDir
        /// </summary>
        /// <param name="pathToCreate"></param>
        /// <returns></returns>
        public string CreateUserFTPDir(string pathToCreate)
        {
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;

            string retValue = string.Empty;
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;
            string currentDir = "";
            try
            {
                currentDir = _ftpURL + pathToCreate;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(currentDir);
                reqFTP.Credentials = new NetworkCredential(_UserName, _Password);
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = false;
                reqFTP.UsePassive = true;
                reqFTP.EnableSsl = false;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                ftpStream = response.GetResponseStream();
                ftpStream.Close();
                response.Close();
                retValue = "Folder created successfully.";
            }
            catch (WebException ex)
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
        public string UploadFile(string localFilePath, string remoteDirectory, string newFileName )
        {
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;

            string retValue = string.Empty;
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;

            string remoteFileUrl = $"{_ftpURL}{remoteDirectory}{newFileName}";
            try
            {

                byte[] fileBytes = System.IO.File.ReadAllBytes(localFilePath);

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remoteFileUrl);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(_UserName, _Password);
                Stream ftpstream = request.GetRequestStream();
                ftpstream.Write(fileBytes, 0, fileBytes.Length);
                ftpstream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                retValue = response.StatusDescription;
                response.Close();
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
        public string DeleteFile(string remoteFilePath)
        {
            string retValue = string.Empty;
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;


            try
            {
                string remoteFileUrl = $"{_ftpURL}{remoteFilePath}";

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remoteFileUrl);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(_UserName, _Password);
                request.Proxy = null;
                request.UseBinary = false;
                request.UsePassive = true;
                request.KeepAlive = false;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(responseStream);
                sr.ReadToEnd();
                retValue = response.StatusDescription;
                sr.Close();
                response.Close();
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
        /// DownloadFile_FileStream
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<Stream> DownloadFile_FileStream(string remoteFilePath)
        {
            Stream? retValue = null;
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;

            string remoteFileUrl = $"{_ftpURL}{remoteFilePath}";
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remoteFileUrl);
            request.Credentials = new NetworkCredential(_UserName, _Password);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                retValue = response.GetResponseStream();
            }
            catch (WebException webEx)
            {
                throw new InvalidOperationException($"Error: {webEx.Message}", webEx);
            }
            return retValue;



        }
        /// <summary>
        /// DownloadFile
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<Stream> DownloadFile(string remoteFilePath)
        {
            Stream? retValue = null;
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;

            string remoteFileUrl = $"{_ftpURL}{remoteFilePath}";
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remoteFileUrl);
            request.Credentials = new NetworkCredential(_UserName, _Password);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                retValue = response.GetResponseStream();
            }
            catch (WebException webEx)
            {
                throw new InvalidOperationException($"Error: {webEx.Message}", webEx);
            }
            return retValue;
        }



        public bool FileExistsOnFtp(string remoteDirectory, string FileName)
        {
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;
            string retValue = string.Empty;
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;
            string remoteFileUrl = $"{_ftpURL}{remoteDirectory}{FileName}";
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remoteFileUrl);
                request.Credentials = new NetworkCredential(_UserName, _Password);
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                else
                {
                    throw; // Handle other exceptions if needed
                }
            }
        }



        public SecurityCapsule GetSecurityCapsule(DateTime dt)
        {
            AppConfig.HelperClasses.transactioncodeGen objTrans = new transactioncodeGen();
            SecurityCapsule objSec = new BDO.Core.Base.SecurityCapsule();
            objSec.transid = objTrans.GetRandomAlphaNumericStringForTransactionActivity("FST", dt);
            objSec.createdbyusername = _userProfileService.CurrentUser.username;
            objSec.createddate = dt;
            objSec.updatedbyusername = _userProfileService.CurrentUser.username;
            objSec.updateddate = dt;
            objSec.ipaddress = _msgService.GetUserIPAddress();
            return objSec;
        }

    }
}
