using BDO.Core.DataAccessObjects.Models;
using BMCFileMangement.forms.UserControls;
using BMCFileMangement.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMCFileMangement.Services.DisServices
{
    public  class clsUpdatedDBHandler : IDisposable
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

    }
}
