﻿using Microsoft.Toolkit.Uwp.Notifications;
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
        public BackgroundWorker backgroundWorker;

            
        /// <summary>
        /// public BackgroundWorker backgroundWorker;
        /// </summary>
        public NotificationAndDataQueryBGWorker()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
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