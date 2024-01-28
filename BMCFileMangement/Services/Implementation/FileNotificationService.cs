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
        public static List<filetransferinfoEntity> NotificaitonItems { get; set; }

        public List<filetransferinfoEntity> CurrentListofNotificaitons => NotificaitonItems;

        public void SetCurrentNotificaitonItems(filetransferinfoEntity item)
        {
            NotificaitonItems.Add(new filetransferinfoEntity()
            { });
        }

    
    }
}
