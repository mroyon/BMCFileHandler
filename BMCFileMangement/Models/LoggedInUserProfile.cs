using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BMCFileMangement.Models
{
    [Serializable]
    [DataContract(Name = "LoggedInUserProfile", Namespace = "http://www.KAF.com/types")]
    public partial class LoggedInUserProfile
    {
        #region Properties

        protected Guid? _userid;
        protected string _username;
        protected string _useremail;
        protected string _userphone;
        protected DateTime? _logindate;
        protected DateTime? _lastlogindate;
        protected int? _isonline;
        protected long? _folderid;

        [DataMember]
        public Guid? userid
        {
            get { return _userid; }
            set { _userid = value;  }
        }
        [DataMember]
        public string username
        {
            get { return _username; }
            set { _username = value;  }
        }
        [DataMember]
        public string useremail
        {
            get { return _useremail; }
            set { _useremail = value; }
        }
        [DataMember]
        public string userphone
        {
            get { return _userphone; }
            set { _userphone = value; }
        }
        [DataMember]
        public DateTime? logindate
        {
            get { return _logindate; }
            set { _logindate = value; }
        }
        [DataMember]
        public DateTime? lastlogindate
        {
            get { return _lastlogindate; }
            set { _lastlogindate = value; }
        }
     
        [DataMember]
        public int? isonline
        {
            get { return _isonline; }
            set { _isonline = value; }
        }
     
        [DataMember]
        public long? folderid
        {
            get { return _folderid; }
            set { _folderid = value; }
        }
     



        #endregion

        /// <summary>
        /// FileHandlerEntity
        /// </summary>
        public LoggedInUserProfile() 
        {
        }
    }
}
