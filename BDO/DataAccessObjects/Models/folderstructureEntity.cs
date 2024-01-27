using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "folderstructureEntity", Namespace = "http://www.KAF.com/types")]
    public partial class folderstructureEntity : BaseEntity
    {
        #region Properties
    
        protected long ? _folderid;
        protected string _foldername;
        protected string _physicalpath;
        protected long ? _parentfolderid;
        protected bool ? _isdeleted;
        protected string _deletedbyuser;
        protected DateTime ? _deleteddate;
                
        
        [DataMember]
        public long ? folderid
        {
            get { return _folderid; }
            set { _folderid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(350)]
        [Display(Name = "foldername", ResourceType = typeof(CLL.LLClasses.Models._folderstructure))]
        public string foldername
        {
            get { return _foldername; }
            set { _foldername = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(350)]
        [Display(Name = "physicalpath", ResourceType = typeof(CLL.LLClasses.Models._folderstructure))]
        public string physicalpath
        {
            get { return _physicalpath; }
            set { _physicalpath = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "parentfolderid", ResourceType = typeof(CLL.LLClasses.Models._folderstructure))]
        public long ? parentfolderid
        {
            get { return _parentfolderid; }
            set { _parentfolderid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "isdeleted", ResourceType = typeof(CLL.LLClasses.Models._folderstructure))]
        public bool ? isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(256)]
        [Display(Name = "deletedbyuser", ResourceType = typeof(CLL.LLClasses.Models._folderstructure))]
        public string deletedbyuser
        {
            get { return _deletedbyuser; }
            set { _deletedbyuser = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "deleteddate", ResourceType = typeof(CLL.LLClasses.Models._folderstructure))]
        public DateTime ? deleteddate
        {
            get { return _deleteddate; }
            set { _deleteddate = value; this.OnChnaged(); }
        }
        
        
        #endregion
    
        #region Constructor
    
        public folderstructureEntity():base()
        {
        }
        
        public folderstructureEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }
        
         public folderstructureEntity(IDataReader reader, bool IsListViewShow)
        {
            this.LoadFromReader(reader, IsListViewShow);
        }
        
      
        
        protected void LoadFromReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("FolderID"))) _folderid = reader.GetInt64(reader.GetOrdinal("FolderID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FolderName"))) _foldername = reader.GetString(reader.GetOrdinal("FolderName"));
                if (!reader.IsDBNull(reader.GetOrdinal("PhysicalPath"))) _physicalpath = reader.GetString(reader.GetOrdinal("PhysicalPath"));
                if (!reader.IsDBNull(reader.GetOrdinal("ParentFolderID"))) _parentfolderid = reader.GetInt64(reader.GetOrdinal("ParentFolderID"));
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
                if (!reader.IsDBNull(reader.GetOrdinal("FolderID"))) _folderid = reader.GetInt64(reader.GetOrdinal("FolderID"));
                if (!reader.IsDBNull(reader.GetOrdinal("FolderName"))) _foldername = reader.GetString(reader.GetOrdinal("FolderName"));
                if (!reader.IsDBNull(reader.GetOrdinal("PhysicalPath"))) _physicalpath = reader.GetString(reader.GetOrdinal("PhysicalPath"));
                if (!reader.IsDBNull(reader.GetOrdinal("ParentFolderID"))) _parentfolderid = reader.GetInt64(reader.GetOrdinal("ParentFolderID"));
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
