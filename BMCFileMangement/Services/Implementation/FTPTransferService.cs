using AppConfig.HelperClasses;
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
        public string UploadFile(string localFilePath, string remoteDirectory, string newFileName)
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
        public string DeleteDirectoryFTP(string fileDir)
        {
            string retValue = string.Empty;
            string strMsg = string.Empty;
            string strmsg = string.Empty;
            try
            {
                string _Password = _ftpSettings.Password;
                string _UserName = _ftpSettings.UserName;
                string _ftpURL = _ftpSettings.FtpAddress;

                /* Create an FTP Request */
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(_ftpURL + fileDir);
                ftpRequest.Credentials = new NetworkCredential(_UserName, _Password);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;

                /* Establish Return Communication with the FTP Server */
                FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse.Close();

                ftpRequest = null;
                retValue = "Folder deleted successfully.";
            }
            catch (Exception ex) { retValue = ex.Message; }
            return retValue;
        }

        public bool IsExistFolderFTP(string ftpUrl)
        {
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;
            bool isexist = false;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_ftpURL + ftpUrl);
                request.Credentials = new NetworkCredential(_UserName, _Password);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    isexist = true;
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        return false;
                    }
                }
            }
            return isexist;
        }

        public List<string> GetDirectoryListFTP(string ParentFolderpath)
        {
            //string _Password = _ftpSettings.Password;
            //string _UserName = _ftpSettings.UserName;
            //string _ftpURL = _ftpSettings.FtpAddress;

            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_ftpURL + ftpUrl);
            //request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            //request.Credentials = new NetworkCredential(_UserName, _Password);
            //List<string> directoryItems = new List<string>();
            //using (WebResponse response = request.GetResponse())
            //    //using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            //    //{
            //    //    //string directoryList = reader.ReadToEnd();
            //    //    //return directoryList.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //    //}

            //using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            //{
            //    while (!reader.EndOfStream)
            //    {
            //        string line = reader.ReadLine();
            //        directoryItems.Add(line);
            //    }
            //}
            //return directoryItems.ToArray();

            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(_ftpURL + ParentFolderpath);
                ftpRequest.Credentials = new NetworkCredential(_UserName, _Password);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    var lineArr = line.Split('/');
                    line = lineArr[lineArr.Count() - 1];
                    directories.Add(line);
                    line = streamReader.ReadLine();
                }

                streamReader.Close();

                return directories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<string> GetAllFilesFromDirectoryFTP(string ParentFolderpath)
        {
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(_ftpURL + ParentFolderpath);
                ftpRequest.Credentials = new NetworkCredential(_UserName, _Password);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    var lineArr = line.Split('/');
                    line = lineArr[lineArr.Count() - 1];
                    line = $"{_ftpURL}{ParentFolderpath}/{line}";

                    directories.Add(line);
                    line = streamReader.ReadLine();
                }

                streamReader.Close();

                return directories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetFilesFromFtp(string ParentFolderpath)
        {
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;
            List<string> res = new List<string>();
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(_ftpURL + ParentFolderpath);
                ftpRequest.Credentials = new NetworkCredential(_UserName, _Password);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();

                Stream stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                string data = streamReader.ReadToEnd();
                res = data.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        public void SetFtpWorkingDirectory(string directory="")
        {
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_ftpSettings.FtpAddress + directory);
            request.Credentials = new NetworkCredential(_UserName, _Password);
            request.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine($"Current working directory: {response.StatusDescription}");
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public DateTime GetFileDateFTP(string filepath)
        {
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;
           
            DateTime result = DateTime.MinValue;
            try
            {
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(filepath));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(_UserName, _Password);
                reqFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                result = response.LastModified;
                response.Close();
            }
            catch
            {

            }
            return result;
        }
        public long GetFileSizeFTP(string filepath)
        {
            string _Password = _ftpSettings.Password;
            string _UserName = _ftpSettings.UserName;
            string _ftpURL = _ftpSettings.FtpAddress;

            long result = 0;
            try
            {
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(filepath));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(_UserName, _Password);
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                result = response.ContentLength;
                response.Close();
            }
            catch
            {

            }
            return result;
        }
    }
}
