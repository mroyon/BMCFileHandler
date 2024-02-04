using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMCFileMangement.Services.Interface
{
    public interface IMessageService
    {
        string GetSuccessMessage();

        string GetUserIPAddress();
    }
}
