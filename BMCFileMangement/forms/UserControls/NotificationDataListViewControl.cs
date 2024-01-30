using BMCFileMangement.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BMCFileMangement.forms.UserControls
{
    public partial class NotificationDataListViewControl : UserControl
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<NotificationDataListViewControl> _logger;
        private readonly IMessageService _msgService;
        private readonly IConfigurationRoot _config;
        private readonly IApplicationLogService _applog;
        private readonly IUserProfileService _userprofile;
        private readonly IFileNotificationService _fileNotificationList;


        public BackgroundWorker backgroundWorkerPop;


        public NotificationDataListViewControl()
        {
            InitializeComponent();
            InitializeBackgroundWorkerPop();
        }


        /// <summary>
        /// InitializeBackgroundWorker
        /// </summary>
        private void InitializeBackgroundWorkerPop()
        {
            backgroundWorkerPop = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            backgroundWorkerPop.DoWork += async (sender, e) => await backgroundWorkerPop_DoWork();
            backgroundWorkerPop.ProgressChanged += async (sender, e) => await backgroundWorkerPop_ProgressChanged(sender, e);
            backgroundWorkerPop.RunWorkerCompleted += async (sender, e) => await backgroundWorkerPop_RunWorkerCompleted(sender, e);

            // Start the background worker when the main form loads
            if (!backgroundWorkerPop.IsBusy)
            {
                backgroundWorkerPop.RunWorkerAsync();
            }
        }


        /// <summary>
        /// BackgroundWorker_DoWork
        /// </summary>
        /// <returns></returns>
        private async Task backgroundWorkerPop_DoWork()
        {
            // Infinite loop to keep the background worker running
            while (!backgroundWorkerPop.CancellationPending)
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
            {

            }
            await Task.Delay(30000);
        }

        // <summary>
        /// backgroundWorkerPop_ProgressChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task backgroundWorkerPop_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This method is called on the main thread when progress is reported
            // Update UI or perform any necessary actions based on the background work
        }

        /// <summary>
        /// backgroundWorkerPop_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task backgroundWorkerPop_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Cleanup or handle completion if needed

        }

        /// <summary>
        /// NotificationDataListViewControl
        /// </summary>
        /// <param name="config"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="msgService"></param>
        /// <param name="applog"></param>
        /// <param name="userprofile"></param>
        public NotificationDataListViewControl(
            IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            IMessageService msgService,
            IApplicationLogService applog,
            IUserProfileService userprofile,
           IFileNotificationService fileNotificationList)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<NotificationDataListViewControl>();
            _msgService = msgService;
            _applog = applog;
            _fileNotificationList = fileNotificationList;
            _userprofile = userprofile;

            InitializeComponent();
        }

        public void loadDataForNotification()
        {
            dtGrdNotification.DataSource = _fileNotificationList.CurrentListofNotificaitons.ToList();
        }
    }
}
