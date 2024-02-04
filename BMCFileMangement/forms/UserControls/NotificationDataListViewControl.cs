using BDO.Core.DataAccessObjects.Models;
using BMCFileMangement.Services.DisServices;
using BMCFileMangement.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Markup;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
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
        private readonly IFTPTransferService _fTPTransferService;

        public BackgroundWorker backgroundWorkerPopUp;

        /// <summary>
        /// NotificationDataListViewControl
        /// </summary>
        public NotificationDataListViewControl()
        {
            InitializeComponent();
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
           IFileNotificationService fileNotificationList,
           IFTPTransferService fTPTransferService)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<NotificationDataListViewControl>();
            _msgService = msgService;
            _applog = applog;
            _fileNotificationList = fileNotificationList;
            _userprofile = userprofile;
            _fTPTransferService = fTPTransferService;

            InitializeComponent();
            InitializeBackgroundWorkerPopUp();
        }

        /// <summary>
        /// InitializeBackgroundWorker
        /// </summary>
        private void InitializeBackgroundWorkerPopUp()
        {
            backgroundWorkerPopUp = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            backgroundWorkerPopUp.DoWork += async (sender, e) => await BackgroundWorkerPopUp_DoWork();
            backgroundWorkerPopUp.ProgressChanged += async (sender, e) => await BackgroundWorkerPopUp_ProgressChanged(sender, e);
            backgroundWorkerPopUp.RunWorkerCompleted += async (sender, e) => await BackgroundWorkerPopUp_RunWorkerCompleted(sender, e);

            // Start the background worker when the main form loads
            if (!backgroundWorkerPopUp.IsBusy)
            {
                backgroundWorkerPopUp.RunWorkerAsync();
            }
        }

        /// <summary>
        /// BackgroundWorkerPopUp_DoWork
        /// </summary>
        /// <returns></returns>
        private async Task BackgroundWorkerPopUp_DoWork()
        {
            // Infinite loop to keep the background worker running
            while (!backgroundWorkerPopUp.CancellationPending)
            {
                //MessageBox.Show("Asdf");
                await ShowPopUpNotification();
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
        private async Task ShowPopUpNotification()
        {
            CancellationToken cancellationToken = new CancellationToken();
            long maxVal = 0;
            await Task.Delay(2000);
        }

        /// BackgroundWorker_ProgressChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task BackgroundWorkerPopUp_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This method is called on the main thread when progress is reported
            // Update UI or perform any necessary actions based on the background work
        }

        /// <summary>
        /// BackgroundWorker_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task BackgroundWorkerPopUp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_fileNotificationList.CurrentListofNotificaitons != null && _fileNotificationList.CurrentListofNotificaitons.Count > 0)
            {
                List<filetransferinfoEntity> itemsToRemove = new List<filetransferinfoEntity>();

                foreach (var objSingle in _fileNotificationList.CurrentListofNotificaitons)
                {
                    if (!objSingle.showedpopup.GetValueOrDefault(true))
                    {
                        string folderPath = @"C:\TestFolderBMC";

                        var heroImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"Picture1.png");
                        new ToastContentBuilder()
                            .AddArgument("action", "viewConversation")
                            .AddArgument("conversationId", 100)
                            .AddText(objSingle.filename)
                            .AddInlineImage(new Uri(heroImage))
                            .AddButton(new ToastButton()
                                        .SetContent("Open Folder")
                                        .AddArgument("url", objSingle.fromuserremark))
                            .AddAttributionText(objSingle.fullpath)
                            .SetToastScenario(ToastScenario.Default)
                            .Show(toast =>
                            {
                                toast.ExpirationTime = DateTime.Now.AddSeconds(15);
                            });
                        await Task.Delay(10000);

                        UpdatePopData(objSingle);

                        await Task.Delay(5000);

                        itemsToRemove.Add(objSingle);

                        await Task.Delay(5000);
                    }
                }

                foreach (var objSingle in itemsToRemove)
                {
                    _fileNotificationList.DeleteCurrentNotificaitonItems(objSingle);
                    loadDataForNotification();
                }
                itemsToRemove = new List<filetransferinfoEntity>();
            }
        }

        /// <summary>
        /// UpdatePopData
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private async Task UpdatePopData(filetransferinfoEntity obj)
        {
            clsUpdatedDBHandler objHandler = new clsUpdatedDBHandler(_loggerFactory);
            await objHandler.UpdateFileTransferInfo(obj);
            objHandler.Dispose();
        }

        /// <summary>
        /// loadDataForNotification
        /// </summary>
        public void loadDataForNotification()
        {
            this.Invoke(new Action(() =>
            {
                //Setup columns and other UI stuff
                //Set datasource of grid

                dtGrdNotification.AutoGenerateColumns = false;

                dtGrdNotification.Columns.Add("fromusername", "From User");
                dtGrdNotification.Columns.Add("sentdate", "Sent Date");
                dtGrdNotification.Columns.Add("filename", "File Name");
                dtGrdNotification.Columns.Add("priority", "Priority");
                dtGrdNotification.Columns.Add("fromuserremark", "Remarks");

                dtGrdNotification.Columns["fromusername"].DataPropertyName = "fromusername";
                dtGrdNotification.Columns["sentdate"].DataPropertyName = "sentdate";
                dtGrdNotification.Columns["filename"].DataPropertyName = "filename";
                dtGrdNotification.Columns["priority"].DataPropertyName = "priority";
                dtGrdNotification.Columns["fromuserremark"].DataPropertyName = "fromuserremark";

                for (int i = 0; i < dtGrdNotification.Columns.Count - 1; i++)
                {
                    dtGrdNotification.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                dtGrdNotification.Columns[dtGrdNotification.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dtGrdNotification.DataSource = _fileNotificationList.CurrentListofNotificaitons?.ToList();
            }));
        }


        private void dtGrdNotification_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dtGrdNotification.Columns["filename"].Index)
            {
                string fileName = dtGrdNotification.Rows[e.RowIndex].Cells["filename"].Value.ToString(); // Replace with the actual column name containing file information
                DownloadFile(fileName);
            }
        }


        private async Task DownloadFile(string fileName)
        {
            string fullPath = _userprofile.CurrentUser.userid.GetValueOrDefault().ToString() + "/IN/" + fileName;
            var fileStream = await _fTPTransferService.DownloadFile(fullPath);

            // Using statement ensures that the FileStream is properly closed and resources are released
            using (FileStream outputStream = new FileStream(fileName, FileMode.Create))
            {
                // Read from the input stream and write to the file stream
                fileStream.CopyTo(outputStream);
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = fileName,
                UseShellExecute = true
            });

            //MessageBox.Show($"Downloading file: {fileName}");
        }

    }
}
