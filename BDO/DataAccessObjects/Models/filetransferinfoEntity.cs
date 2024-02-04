using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "filetransferinfoEntity", Namespace = "http://www.KAF.com/types")]
    public partial class filetransferinfoEntity : BaseEntity
    {
        #region Properties
    
        protected long ? _filetransid;
        protected string _fromusername;
        protected Guid ? _fromuserid;
        protected string _tousername;
        protected Guid ? _touserid;
        protected string _fromuserremark;
        protected DateTime ? _sentdate;
        protected bool ? _showedpopup;
        protected DateTime ? _showeddate;
        protected bool ? _isreceived;
        protected DateTime ? _receiveddate;
        protected bool ? _isopen;
        protected DateTime ? _opendate;
        protected string _filename;
        protected int ? _fileversion;
        protected string _fullpath;
        protected int ? _priority;
        protected string _filejsondata;
        protected int ? _status;
        protected DateTime ? _expecteddate;


        [DataMember]
        public long ? filetransid
        {
            get { return _filetransid; }
            set { _filetransid = value; this.OnChnaged(); }
        }
        
       
        
        [DataMember]
        [MaxLength(256)]
        [Display(Name = "fromusername", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public string fromusername
        {
            get { return _fromusername; }
            set { _fromusername = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "fromuserid", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public Guid ? fromuserid
        {
            get { return _fromuserid; }
            set { _fromuserid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(256)]
        [Display(Name = "tousername", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public string tousername
        {
            get { return _tousername; }
            set { _tousername = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "touserid", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public Guid ? touserid
        {
            get { return _touserid; }
            set { _touserid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(-1)]
        [Display(Name = "fromuserremark", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public string fromuserremark
        {
            get { return _fromuserremark; }
            set { _fromuserremark = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "sentdate", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public DateTime ? sentdate
        {
            get { return _sentdate; }
            set { _sentdate = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "showedpopup", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public bool ? showedpopup
        {
            get { return _showedpopup; }
            set { _showedpopup = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "showeddate", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public DateTime ? showeddate
        {
            get { return _showeddate; }
            set { _showeddate = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "isreceived", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public bool ? isreceived
        {
            get { return _isreceived; }
            set { _isreceived = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "receiveddate", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public DateTime ? receiveddate
        {
            get { return _receiveddate; }
            set { _receiveddate = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "isopen", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public bool ? isopen
        {
            get { return _isopen; }
            set { _isopen = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "opendate", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public DateTime ? opendate
        {
            get { return _opendate; }
            set { _opendate = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(350)]
        [Display(Name = "filename", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public string filename
        {
            get { return _filename; }
            set { _filename = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "fileversion", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public int ? fileversion
        {
            get { return _fileversion; }
            set { _fileversion = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(350)]
        [Display(Name = "fullpath", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public string fullpath
        {
            get { return _fullpath; }
            set { _fullpath = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "priority", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public int ? priority
        {
            get { return _priority; }
            set { _priority = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(-1)]
        [Display(Name = "filejsondata", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public string filejsondata
        {
            get { return _filejsondata; }
            set { _filejsondata = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "status", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public int ? status
        {
            get { return _status; }
            set { _status = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "expecteddate", ResourceType = typeof(CLL.LLClasses.Models._filetransferinfo))]
        public DateTime ? expecteddate
        {
            get { return _expecteddate; }
            set { _expecteddate = value; this.OnChnaged(); }
        }
        
        
        #endregion
    
        #region Constructor
    
        public filetransferinfoEntity():base()
        {
        }
        
        public filetransferinfoEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }
        
         public filetransferinfoEntity(IDataReader reader, bool IsListViewShow)
        {
            this.LoadFromReader(reader, IsListViewShow);
        }
        
      
        
        protected void LoadFromReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("FileTransID"))) _filetransid = reader.GetInt64(reader.GetOrdinal("FileTransID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FromUsername"))) _fromusername = reader.GetString(reader.GetOrdinal("FromUsername"));
                if (!reader.IsDBNull(reader.GetOrdinal("FromUserID"))) _fromuserid = reader.GetGuid(reader.GetOrdinal("FromUserID"));
                if (!reader.IsDBNull(reader.GetOrdinal("ToUsername"))) _tousername = reader.GetString(reader.GetOrdinal("ToUsername"));
                if (!reader.IsDBNull(reader.GetOrdinal("ToUserID"))) _touserid = reader.GetGuid(reader.GetOrdinal("ToUserID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FromUserRemark"))) _fromuserremark = reader.GetString(reader.GetOrdinal("FromUserRemark"));
                if (!reader.IsDBNull(reader.GetOrdinal("SentDate"))) _sentdate = reader.GetDateTime(reader.GetOrdinal("SentDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("ShowedPopUP"))) _showedpopup = reader.GetBoolean(reader.GetOrdinal("ShowedPopUP"));
                if (!reader.IsDBNull(reader.GetOrdinal("ShowedDate"))) _showeddate = reader.GetDateTime(reader.GetOrdinal("ShowedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsReceived"))) _isreceived = reader.GetBoolean(reader.GetOrdinal("IsReceived"));
                if (!reader.IsDBNull(reader.GetOrdinal("ReceivedDate"))) _receiveddate = reader.GetDateTime(reader.GetOrdinal("ReceivedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsOpen"))) _isopen = reader.GetBoolean(reader.GetOrdinal("IsOpen"));
                if (!reader.IsDBNull(reader.GetOrdinal("OpenDate"))) _opendate = reader.GetDateTime(reader.GetOrdinal("OpenDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileName"))) _filename = reader.GetString(reader.GetOrdinal("FileName"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileVersion"))) _fileversion = reader.GetInt32(reader.GetOrdinal("FileVersion"));
                if (!reader.IsDBNull(reader.GetOrdinal("FullPath"))) _fullpath = reader.GetString(reader.GetOrdinal("FullPath"));
                if (!reader.IsDBNull(reader.GetOrdinal("Priority"))) _priority = reader.GetInt32(reader.GetOrdinal("Priority"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileJsonData"))) _filejsondata = reader.GetString(reader.GetOrdinal("FileJsonData"));
                if (!reader.IsDBNull(reader.GetOrdinal("Status"))) _status = reader.GetInt32(reader.GetOrdinal("Status"));
                if (!reader.IsDBNull(reader.GetOrdinal("ExpectedDate"))) _expecteddate = reader.GetDateTime(reader.GetOrdinal("ExpectedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("TransID"))) this.BaseSecurityParam.transid = reader.GetString(reader.GetOrdinal("TransID"));
                if (!reader.IsDBNull(reader.GetOrdinal("CreatedByUserName"))) this.BaseSecurityParam.createdbyusername = reader.GetString(reader.GetOrdinal("CreatedByUserName"));
                if (!reader.IsDBNull(reader.GetOrdinal("CreatedDate"))) this.BaseSecurityParam.createddate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("UpdatedByUserName"))) this.BaseSecurityParam.updatedbyusername = reader.GetString(reader.GetOrdinal("UpdatedByUserName"));
                if (!reader.IsDBNull(reader.GetOrdinal("UpdatedDate"))) this.BaseSecurityParam.updateddate = reader.GetDateTime(reader.GetOrdinal("UpdatedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("IPAddress"))) this.BaseSecurityParam.ipaddress = reader.GetString(reader.GetOrdinal("IPAddress"));
                if (!reader.IsDBNull(reader.GetOrdinal("TS"))) this.BaseSecurityParam.ts = reader.GetInt64(reader.GetOrdinal("ts"));
                CurrentState = EntityState.Unchanged;
            }
        }


        protected void LoadFromReader(IDataReader reader, bool IsListViewShow)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("FileTransID"))) _filetransid = reader.GetInt64(reader.GetOrdinal("FileTransID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FromUsername"))) _fromusername = reader.GetString(reader.GetOrdinal("FromUsername"));
                if (!reader.IsDBNull(reader.GetOrdinal("FromUserID"))) _fromuserid = reader.GetGuid(reader.GetOrdinal("FromUserID"));
                if (!reader.IsDBNull(reader.GetOrdinal("ToUsername"))) _tousername = reader.GetString(reader.GetOrdinal("ToUsername"));
                if (!reader.IsDBNull(reader.GetOrdinal("ToUserID"))) _touserid = reader.GetGuid(reader.GetOrdinal("ToUserID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FromUserRemark"))) _fromuserremark = reader.GetString(reader.GetOrdinal("FromUserRemark"));
                if (!reader.IsDBNull(reader.GetOrdinal("SentDate"))) _sentdate = reader.GetDateTime(reader.GetOrdinal("SentDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("ShowedPopUP"))) _showedpopup = reader.GetBoolean(reader.GetOrdinal("ShowedPopUP"));
                if (!reader.IsDBNull(reader.GetOrdinal("ShowedDate"))) _showeddate = reader.GetDateTime(reader.GetOrdinal("ShowedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsReceived"))) _isreceived = reader.GetBoolean(reader.GetOrdinal("IsReceived"));
                if (!reader.IsDBNull(reader.GetOrdinal("ReceivedDate"))) _receiveddate = reader.GetDateTime(reader.GetOrdinal("ReceivedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsOpen"))) _isopen = reader.GetBoolean(reader.GetOrdinal("IsOpen"));
                if (!reader.IsDBNull(reader.GetOrdinal("OpenDate"))) _opendate = reader.GetDateTime(reader.GetOrdinal("OpenDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileName"))) _filename = reader.GetString(reader.GetOrdinal("FileName"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileVersion"))) _fileversion = reader.GetInt32(reader.GetOrdinal("FileVersion"));
                if (!reader.IsDBNull(reader.GetOrdinal("FullPath"))) _fullpath = reader.GetString(reader.GetOrdinal("FullPath"));
                if (!reader.IsDBNull(reader.GetOrdinal("Priority"))) _priority = reader.GetInt32(reader.GetOrdinal("Priority"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileJsonData"))) _filejsondata = reader.GetString(reader.GetOrdinal("FileJsonData"));
                if (!reader.IsDBNull(reader.GetOrdinal("Status"))) _status = reader.GetInt32(reader.GetOrdinal("Status"));
                if (!reader.IsDBNull(reader.GetOrdinal("ExpectedDate"))) _expecteddate = reader.GetDateTime(reader.GetOrdinal("ExpectedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("TransID"))) this.BaseSecurityParam.transid = reader.GetString(reader.GetOrdinal("TransID"));
                if (!reader.IsDBNull(reader.GetOrdinal("CreatedByUserName"))) this.BaseSecurityParam.createdbyusername = reader.GetString(reader.GetOrdinal("CreatedByUserName"));
                if (!reader.IsDBNull(reader.GetOrdinal("CreatedDate"))) this.BaseSecurityParam.createddate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("UpdatedByUserName"))) this.BaseSecurityParam.updatedbyusername = reader.GetString(reader.GetOrdinal("UpdatedByUserName"));
                if (!reader.IsDBNull(reader.GetOrdinal("UpdatedDate"))) this.BaseSecurityParam.updateddate = reader.GetDateTime(reader.GetOrdinal("UpdatedDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("IPAddress"))) this.BaseSecurityParam.ipaddress = reader.GetString(reader.GetOrdinal("IPAddress"));
                if (!reader.IsDBNull(reader.GetOrdinal("TS"))) this.BaseSecurityParam.ts = reader.GetInt64(reader.GetOrdinal("ts"));
                CurrentState = EntityState.Unchanged;
            }
        }
        
        #endregion
        
        
            
    }
}
