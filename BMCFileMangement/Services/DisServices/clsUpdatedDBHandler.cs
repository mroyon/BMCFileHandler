using AppConfig.HelperClasses;
using BDO.Core.Base;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BMCFileMangement.forms.UserControls;
using BMCFileMangement.Services.Implementation;
using BMCFileMangement.Services.Interface;
using CLL.LLClasses.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BMCFileMangement.Services.DisServices
{
    public class clsUpdatedDBHandler : IDisposable
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<clsUpdatedDBHandler> _logger;

        /// <summary>
        /// clsUpdatedDBHandler
        /// </summary>
        /// <param name="config"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="msgService"></param>
        /// <param name="applog"></param>
        /// <param name="userprofile"></param>
        /// <param name="fileNotificationList"></param>
        // Constructor
        public clsUpdatedDBHandler(
            ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<clsUpdatedDBHandler>();
        }


        public clsUpdatedDBHandler()
        {
        }

        #region Disposable

        // Flag to track whether Dispose has been called already
        private bool disposed = false;

        // Unmanaged resources or other disposable objects can be declared here



        // Custom method of the class
        public void SomeMethod()
        {
            Console.WriteLine("SomeMethod is called.");
        }

        // Implementation of IDisposable.Dispose()
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected method to handle the actual cleanup logic
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources (if any)
                }

                // Dispose unmanaged resources (if any)

                // Mark as disposed to avoid redundant disposal
                disposed = true;
            }
        }

        // Finalizer (destructor) to be used if the consumer of the class
        // forgets to call Dispose explicitly
        ~clsUpdatedDBHandler()
        {
            Dispose(false);
        }

        #endregion Disposable


        /// <summary>
        /// FetchFileTransferInfo
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public async Task<List<filetransferinfoEntity>> FetchFileTransferInfo(Guid? userid, long maxVal)
        {
            CancellationToken cancellationToken = new CancellationToken();
            var obj = await BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.GetFacadeCreate(null)
                .GetAllMyNotificaiton(new BDO.Core.DataAccessObjects.Models.filetransferinfoEntity()
                {
                    touserid = userid,
                    filetransid = maxVal == 0 ? null : maxVal
                }, cancellationToken);
            return obj.ToList();
        }

        /// <summary>
        /// UpdateFileTransferInfo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task UpdateFileTransferInfo(filetransferinfoEntity obj)
        {
            CancellationToken cancellationToken = new CancellationToken();
            obj.showeddate = DateTime.Now;
            obj.showedpopup = true;
            BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.GetFacadeCreate(null).UpdatePopUpData(obj, cancellationToken);
        }

        /// <summary>
        /// UpdateFileOpenAndShowPopAndDownload
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public void UpdateFileOpenAndShowPopAndDownload(ToastNotificationActivatedEventArgsCompat e)
        {
            CancellationToken cancellationToken = new CancellationToken();

            if (e.Argument != String.Empty)
            {
                string[] augArray = e.Argument.Split(';');
                if (augArray.Length > 0)
                {

                    IConfiguration configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .Build();
                    DateTime dt = DateTime.Now;

                    Stream? fileStream = null;
                    string _Password = configuration["FtpSettings:Password"];
                    string _UserName = configuration["FtpSettings:UserName"];
                    string _ftpURL = configuration["FtpSettings:FtpAddress"];

                    string remoteFileUrl = $"{_ftpURL}{augArray[3].ToString()}";
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remoteFileUrl);
                    request.Credentials = new NetworkCredential(_UserName, _Password);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;

                    try
                    {
                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                        fileStream = response.GetResponseStream();

                        // Using statement ensures that the FileStream is properly closed and resources are released
                        using (FileStream outputStream = new FileStream(augArray[2].ToString(), FileMode.Create))
                        {
                            // Read from the input stream and write to the file stream
                            fileStream.CopyTo(outputStream);
                        }
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = augArray[2].ToString(),
                            UseShellExecute = true
                        });

                        clsSecurityCapsule objCap = new clsSecurityCapsule();

                        filetransferinfoEntity obj = new filetransferinfoEntity();
                        obj.filetransid = long.Parse(augArray[0].ToString());
                        obj.BaseSecurityParam = new SecurityCapsule();
                        obj.BaseSecurityParam = objCap.GetSecurityCapsule(dt, augArray[4]);
                        objCap.Dispose();

                        obj.showedpopup = true;
                        obj.showeddate = dt;
                        obj.opendate = dt;
                        obj.isopen = true;
                        obj.status = 2;

                        BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.GetFacadeCreate(null).UpdateOpenDataNPopUpData(obj, cancellationToken);

                    }
                    catch (WebException webEx)
                    {
                        throw new InvalidOperationException($"Error: {webEx.Message}", webEx);
                    }
                }

            }
        }

      



    }
}
