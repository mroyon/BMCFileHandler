using BMCFileMangement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMCFileMangement.Services.Interface
{
    public interface IQueueManagerService
    {
        void Enqueue(FileHandlerEntity item);
        FileHandlerEntity? Dequeue();
        void DisplayQueue(); 
        string GetSuccessMessage();
    }
}
