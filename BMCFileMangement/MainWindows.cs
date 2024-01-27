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
using System.Windows.Forms.Design;

namespace BMCFileMangement
{
    public partial class MainWindows : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<MainWindows> _logger;
        private readonly IMessageService _msgService;
        private readonly IConfigurationRoot _config;

        private BackgroundWorker backgroundWorker;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="msgService"></param>
        public MainWindows(
            IConfigurationRoot config, 
            ILoggerFactory loggerFactory,            
            IMessageService msgService)
        {

            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<MainWindows>();
            _msgService = msgService;
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            backgroundWorker.DoWork += async (sender, e) => await BackgroundWorker_DoWork();
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

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
                // Your asynchronous background work goes here
                // For example, perform an asynchronous task

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
            string folderPath = @"C:\TestFolderBMC";

            var heroImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"Money-Heist.jpg");
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 100)
                .AddText("Folder Changed")
                .AddInlineImage(new Uri(heroImage))
                .AddButton(new ToastButton()
                            .SetContent("Open Folder")
                            .AddArgument("url", folderPath))
                //.AddAttributionText("Cool code")
                .SetToastScenario(ToastScenario.Default)
                .Show(toast =>
                {
                    toast.ExpirationTime = DateTime.Now.AddSeconds(15);
                });

            
            await Task.Delay(20000);
        }

        /// <summary>
        /// BackgroundWorker_ProgressChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This method is called on the main thread when progress is reported
            // Update UI or perform any necessary actions based on the background work
        }

        /// <summary>
        /// BackgroundWorker_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Cleanup or handle completion if needed
        }


        // Override the form's OnFormClosing event to safely cancel the background worker
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Ensure the background worker is stopped when the form is closing
            if (backgroundWorker != null && backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }


        private void MainWindows_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("Form loaded at: {time}", DateTimeOffset.Now);
        }

        private void statusDateTime_Tick(object sender, EventArgs e)
        {
            currentDateTimeStip.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }

        private void mnLogOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
