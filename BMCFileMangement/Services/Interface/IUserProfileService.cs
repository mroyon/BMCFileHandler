using BDO.Core.DataAccessObjects.SecurityModels;
using BMCFileMangement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMCFileMangement.Services.Interface
{
    public interface IUserProfileService
    {
        void SetCurrentUser(owin_userEntity user);
        LoggedInUserProfile CurrentUser { get; }
    }
}
