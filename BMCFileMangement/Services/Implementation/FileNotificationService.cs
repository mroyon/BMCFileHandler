using BDO.Core.DataAccessObjects.SecurityModels;
using BDO.Core.DataAccessObjects.Models;
using BMCFileMangement.Models;
using BMCFileMangement.Services.Interface;
using CLL.LLClasses.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMCFileMangement.Services.Implementation
{
    public class FileNotificationService : IFileNotificationService
    {
        public static List<filetransferinfoEntity> _NotificaitonItems { get; set; }

        public List<filetransferinfoEntity> CurrentListofNotificaitons => _NotificaitonItems;

        public void SetCurrentNotificaitonItems(List<filetransferinfoEntity> item)
        {
            if(_NotificaitonItems == null)
                _NotificaitonItems = new List<filetransferinfoEntity>();
            _NotificaitonItems.AddRange(item);
        }

    
    }
}
