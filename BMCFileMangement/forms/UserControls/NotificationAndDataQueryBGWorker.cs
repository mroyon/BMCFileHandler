using BDO.Core.DataAccessObjects.Models;
using BMCFileMangement.Services.DisServices;
using BMCFileMangement.Services.Implementation;
using BMCFileMangement.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Services.Maps;
using Timer = System.Windows.Forms.Timer;

namespace BMCFileMangement.forms.UserControls
{
    public partial class NotificationAndDataQueryBGWorker : UserControl
    {

        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<NotificationAndDataQueryBGWorker> _logger;
        private readonly IMessageService _msgService;
        private readonly IConfigurationRoot _config;
        private readonly IApplicationLogService _applog;
        private readonly IUserProfileService _userprofile;
        private readonly frmMainWindow _MainWindow;
        private readonly IFTPTransferService _fTPTransferService;


        public BackgroundWorker backgroundWorker;

        public NotificationAndDataQueryBGWorker()
        {
            InitializeComponent();
        }


        /// <summary>
        /// NotificationAndDataQueryBGWorker
        /// </summary>
        /// <param name="config"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="msgService"></param>
        /// <param name="applog"></param>
        /// <param name="userprofile"></param>
        /// <param name="fTPTransferService"></param>
        /// <param name="MainWindow"></param>
        public NotificationAndDataQueryBGWorker(
          IConfigurationRoot config,
          ILoggerFactory loggerFactory,
          IMessageService msgService,
          IApplicationLogService applog,
          IUserProfileService userprofile,
          IFTPTransferService fTPTransferService,
          frmMainWindow MainWindow)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<NotificationAndDataQueryBGWorker>();
            _msgService = msgService;
            _applog = applog;
            _userprofile = userprofile;
            _fTPTransferService = fTPTransferService;

            InitializeComponent();
            InitializeBackgroundWorker();
            _MainWindow = MainWindow;
        }

        /// <summary>
        /// InitializeBackgroundWorker
        /// </summary>
        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            backgroundWorker.DoWork += async (sender, e) => await BackgroundWorker_DoWork(sender, e);
            backgroundWorker.ProgressChanged += async (sender, e) => await BackgroundWorker_ProgressChanged(sender, e);
            backgroundWorker.RunWorkerCompleted += async (sender, e) => await BackgroundWorker_RunWorkerCompleted(sender, e);

            // Start the background worker when the main form loads
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// BackgroundWorker_DoWork
        /// </summary>
        /// <returns></returns>
        private async Task BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Infinite loop to keep the background worker running
            while (true)
            {
                // Simulate work being done
                Thread.Sleep(1000); // Sleep for 1 second
                await watchFolderContents();
                // Report progress if needed
                // This can be omitted if progress reporting is not necessary
            }
        }


        /// <summary>
        /// watchFolderContents
        /// </summary>
        /// <returns></returns>
        private async Task watchFolderContents()
        {
            CancellationToken cancellationToken = new CancellationToken();
            long maxVal = 0;

            clsUpdatedDBHandler objHandler = new clsUpdatedDBHandler(_loggerFactory);
            filetransferinfoEntity objSingle = await objHandler.FetchFileTransferInfoTopOne(_userprofile.CurrentUser.userid);
            if (objSingle != null)
            {
                var heroImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"Picture1.png");
                new ToastContentBuilder()
                    .AddText(objSingle.filename)
                    .AddInlineImage(new Uri(heroImage))
                    .AddButton(new ToastButton()
                                .SetContent("Open File")
                                .AddArgument(objSingle.filetransid.GetValueOrDefault().ToString())
                                .AddArgument(objSingle.touserid.GetValueOrDefault().ToString())
                                .AddArgument(objSingle.filename)
                                .AddArgument(objSingle.touserid.GetValueOrDefault().ToString() + "/" + "INBOX" + "/" + objSingle.filename)
                                .AddArgument(objSingle.tousername))
                    .AddAttributionText(objSingle.fromuserremark)
                    //.AddAttributionText("Priority: High")
                    .SetToastScenario(ToastScenario.Default)
                    .Show(toast =>
                    {
                        //toast.ExpirationTime = DateTime.Now.AddSeconds(15);
                    });
            }
            objHandler.Dispose();
            await Task.Delay(4000);

            if (objSingle != null)
                await UpdatePopData(objSingle);


            //// Check which forms are currently open
            //foreach (Form openForm in Application.OpenForms)
            //{
            //    if (openForm.Name == "frmInBox")
            //    {
            //        frmInBox obj = new frmInBox(_config,
            //            _loggerFactory,
            //            _msgService,
            //            _applog,
            //            _userprofile,
            //            _fTPTransferService);

            //        obj.LoadGridFromOutSide();
            //    }
            //}

            await Task.Delay(4000);

        }



        /// BackgroundWorker_ProgressChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This method is called on the main thread when progress is reported
            // Update UI or perform any necessary actions based on the background work
        }

        /// <summary>
        /// BackgroundWorker_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (e.Result != null)
            //{
            //    filetransferinfoEntity objSingle = (filetransferinfoEntity)e.Result;
            //    if (objSingle != null)
            //        await UpdatePopData(objSingle);
            //}
            //backgroundWorker.RunWorkerAsync();
        }

        private async Task UpdatePopData(filetransferinfoEntity obj)
        {
            clsUpdatedDBHandler objHandler = new clsUpdatedDBHandler(_loggerFactory);
            await objHandler.UpdateFileTransferInfo(obj);
            objHandler.Dispose();
        }

    }
}
