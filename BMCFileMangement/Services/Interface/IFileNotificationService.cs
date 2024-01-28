using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using BMCFileMangement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMCFileMangement.Services.Interface
{
    public interface IFileNotificationService
    {
        void SetCurrentNotificaitonItems(List<filetransferinfoEntity> item);
        List<filetransferinfoEntity> CurrentListofNotificaitons { get; }
    }
}
