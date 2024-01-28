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
            dtGrdNotification.Invoke((Action)delegate
            {
                dtGrdNotification.DataSource = _fileNotificationList.CurrentListofNotificaitons.ToList();
            });

        }
    }
}
