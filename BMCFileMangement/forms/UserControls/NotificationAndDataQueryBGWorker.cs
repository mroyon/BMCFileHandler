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
        private readonly IFileNotificationService _fileNotificationList;
        private readonly MainWindow _MainWindow;

        public BackgroundWorker backgroundWorker;


        public NotificationAndDataQueryBGWorker(
           IConfigurationRoot config,
           ILoggerFactory loggerFactory,
           IMessageService msgService,
           IApplicationLogService applog,
           IUserProfileService userprofile,
           IFileNotificationService fileNotificationList,

           MainWindow MainWindow)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<NotificationAndDataQueryBGWorker>();
            _msgService = msgService;
            _applog = applog;
            _userprofile = userprofile;

            InitializeComponent();
            InitializeBackgroundWorker();
            _fileNotificationList = fileNotificationList;
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
            backgroundWorker.DoWork += async (sender, e) => await BackgroundWorker_DoWork();
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
        private async Task BackgroundWorker_DoWork()
        {
            // Infinite loop to keep the background worker running
            while (!backgroundWorker.CancellationPending)
            {
                //MessageBox.Show("Asdf");
                await watchFolderContents();
                // Simulate an asynchronous task with Task.Delay
                await Task.Delay(2000); // Adjust as needed
                // Report progress (if needed)
                //backgroundWorker.ReportProgress(0);
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
            if (_fileNotificationList.CurrentListofNotificaitons != null && _fileNotificationList.CurrentListofNotificaitons.Count > 0)
                maxVal = _fileNotificationList.CurrentListofNotificaitons.Max(obj => obj.filetransid).GetValueOrDefault(0);

            var obj = await BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.GetFacadeCreate(null)
                .GetAllMyNotificaiton(new BDO.Core.DataAccessObjects.Models.filetransferinfoEntity()
                {
                    touserid = _userprofile.CurrentUser.userid,
                    filetransid = maxVal == 0 ? null : maxVal
                }, cancellationToken);

            if (obj != null && obj.Count > 0)
            {
                _fileNotificationList.SetCurrentNotificaitonItems(obj.ToList());
                _MainWindow.LostNotificaitonListFromExtTrigger();
                if (ParentForm is MainWindow mainForm)
                {
                    // Call the method in UserControl2

                }
            }
            await Task.Delay(30000);
        }

        // <summary>
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
            // Cleanup or handle completion if needed
        }

        private void NotificationAndDataQueryBGWorker_Load(object sender, EventArgs e)
        {

        }
    }
}
