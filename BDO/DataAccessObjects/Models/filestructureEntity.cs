using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "filestructureEntity", Namespace = "http://www.KAF.com/types")]
    public partial class filestructureEntity : BaseEntity
    {
        #region Properties
    
        protected long ? _fileid;
        protected long ? _folderid;
        protected string _filename;
        protected string _userfilename;
        protected string _filepath;
        protected bool ? _isdeleted;
        protected string _deletedbyuser;
        protected DateTime ? _deleteddate;

        protected Guid? _userid;
        [DataMember]
        public Guid? userid
        {
            get { return _userid; }
            set { _userid = value; this.OnChnaged(); }
        }


        [DataMember]
        public long ? fileid
        {
            get { return _fileid; }
            set { _fileid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "folderid", ResourceType = typeof(CLL.LLClasses.Models._filestructure))]
        public long ? folderid
        {
            get { return _folderid; }
            set { _folderid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(350)]
        [Display(Name = "filename", ResourceType = typeof(CLL.LLClasses.Models._filestructure))]
        public string filename
        {
            get { return _filename; }
            set { _filename = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(350)]
        [Display(Name = "userfilename", ResourceType = typeof(CLL.LLClasses.Models._filestructure))]
        public string userfilename
        {
            get { return _userfilename; }
            set { _userfilename = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(350)]
        [Display(Name = "filepath", ResourceType = typeof(CLL.LLClasses.Models._filestructure))]
        public string filepath
        {
            get { return _filepath; }
            set { _filepath = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "isdeleted", ResourceType = typeof(CLL.LLClasses.Models._filestructure))]
        public bool ? isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(256)]
        [Display(Name = "deletedbyuser", ResourceType = typeof(CLL.LLClasses.Models._filestructure))]
        public string deletedbyuser
        {
            get { return _deletedbyuser; }
            set { _deletedbyuser = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "deleteddate", ResourceType = typeof(CLL.LLClasses.Models._filestructure))]
        public DateTime ? deleteddate
        {
            get { return _deleteddate; }
            set { _deleteddate = value; this.OnChnaged(); }
        }
        
        
        #endregion
    
        #region Constructor
    
        public filestructureEntity():base()
        {
        }
        
        public filestructureEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }
        
         public filestructureEntity(IDataReader reader, bool IsListViewShow)
        {
            this.LoadFromReader(reader, IsListViewShow);
        }
        
      
        
        protected void LoadFromReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("FileID"))) _fileid = reader.GetInt64(reader.GetOrdinal("FileID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FolderID"))) _folderid = reader.GetInt64(reader.GetOrdinal("FolderID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileName"))) _filename = reader.GetString(reader.GetOrdinal("FileName"));
                if (!reader.IsDBNull(reader.GetOrdinal("UserFileName"))) _userfilename = reader.GetString(reader.GetOrdinal("UserFileName"));
                if (!reader.IsDBNull(reader.GetOrdinal("FilePath"))) _filepath = reader.GetString(reader.GetOrdinal("FilePath"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsDeleted"))) _isdeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
                if (!reader.IsDBNull(reader.GetOrdinal("DeletedByUser"))) _deletedbyuser = reader.GetString(reader.GetOrdinal("DeletedByUser"));
                if (!reader.IsDBNull(reader.GetOrdinal("DeletedDate"))) _deleteddate = reader.GetDateTime(reader.GetOrdinal("DeletedDate"));
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
                if (!reader.IsDBNull(reader.GetOrdinal("FileID"))) _fileid = reader.GetInt64(reader.GetOrdinal("FileID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FolderID"))) _folderid = reader.GetInt64(reader.GetOrdinal("FolderID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FileName"))) _filename = reader.GetString(reader.GetOrdinal("FileName"));
                if (!reader.IsDBNull(reader.GetOrdinal("UserFileName"))) _userfilename = reader.GetString(reader.GetOrdinal("UserFileName"));
                if (!reader.IsDBNull(reader.GetOrdinal("FilePath"))) _filepath = reader.GetString(reader.GetOrdinal("FilePath"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsDeleted"))) _isdeleted = reader.GetBoolean(reader.GetOrdinal("IsDeleted"));
                if (!reader.IsDBNull(reader.GetOrdinal("DeletedByUser"))) _deletedbyuser = reader.GetString(reader.GetOrdinal("DeletedByUser"));
                if (!reader.IsDBNull(reader.GetOrdinal("DeletedDate"))) _deleteddate = reader.GetDateTime(reader.GetOrdinal("DeletedDate"));
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
