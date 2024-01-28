using BDO.Core.DataAccessObjects.SecurityModels;
using BMCFileMangement.Models;
using BMCFileMangement.Services.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMCFileMangement.Services.Implementation
{
    public class UserProfileService : IUserProfileService
    {
        public static LoggedInUserProfile StaticCurrentUser { get; set; }

        public LoggedInUserProfile CurrentUser => StaticCurrentUser;

        public void SetCurrentUser(owin_userEntity user)
        {
            StaticCurrentUser = new LoggedInUserProfile();
            StaticCurrentUser.userid = user.userid;
            StaticCurrentUser.username = user.username;
            StaticCurrentUser.useremail = user.emailaddress;
            StaticCurrentUser.userphone = user.mobilenumber;
            StaticCurrentUser.logindate = DateTime.Now;
            StaticCurrentUser.lastlogindate = user.lastlogindate;
            StaticCurrentUser.isonline = 1;
            StaticCurrentUser.folderid = user.folderid;
        }

        
    
    }
}
