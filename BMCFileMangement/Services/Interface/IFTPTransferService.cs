using BMCFileMangement.Models;
using CLL.LLClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.Models;

namespace BMCFileMangement.Services.Interface
{
    public interface IFTPTransferService
    {
        string CreateUserFTPDir(string pathToCreate);

        string UploadFile(string localFilePath, string remoteDirectory, string newFileName);

        string DeleteFile(string remoteFilePath);

        Task<Stream> DownloadFile(string remoteFilePath);

        string DeleteDirectoryFTP(string fileDir);
    }
}
