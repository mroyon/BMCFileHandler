using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "trantinyurlaccessinfoEntity", Namespace = "http://www.KAF.com/types")]
    public partial class trantinyurlaccessinfoEntity : BaseEntity
    {
        #region Properties
    
        protected long ? _tinyurlacceessid;
        protected long ? _tinyurlid;
        protected bool ? _otisused;
        protected DateTime ? _otusedtime;
        protected string _otusedfromip;
                
        
        [DataMember]
        public long ? tinyurlacceessid
        {
            get { return _tinyurlacceessid; }
            set { _tinyurlacceessid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "tinyurlid", ResourceType = typeof(CLL.LLClasses.Models._trantinyurlaccessinfo))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._trantinyurlaccessinfo), ErrorMessageResourceName = "tinyurlidRequired")]
        public long ? tinyurlid
        {
            get { return _tinyurlid; }
            set { _tinyurlid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "otisused", ResourceType = typeof(CLL.LLClasses.Models._trantinyurlaccessinfo))]
        public bool ? otisused
        {
            get { return _otisused; }
            set { _otisused = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "otusedtime", ResourceType = typeof(CLL.LLClasses.Models._trantinyurlaccessinfo))]
        public DateTime ? otusedtime
        {
            get { return _otusedtime; }
            set { _otusedtime = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(50)]
        [Display(Name = "otusedfromip", ResourceType = typeof(CLL.LLClasses.Models._trantinyurlaccessinfo))]
        public string otusedfromip
        {
            get { return _otusedfromip; }
            set { _otusedfromip = value; this.OnChnaged(); }
        }
        
        
        #endregion
    
        #region Constructor
    
        public trantinyurlaccessinfoEntity():base()
        {
        }
        
        public trantinyurlaccessinfoEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }
        
         public trantinyurlaccessinfoEntity(IDataReader reader, bool IsListViewShow)
        {
            this.LoadFromReader(reader, IsListViewShow);
        }
        
      
        
        protected void LoadFromReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("TinyURLAcceessID"))) _tinyurlacceessid = reader.GetInt64(reader.GetOrdinal("TinyURLAcceessID"));
                if (!reader.IsDBNull(reader.GetOrdinal("TinyURLId"))) _tinyurlid = reader.GetInt64(reader.GetOrdinal("TinyURLId"));
                if (!reader.IsDBNull(reader.GetOrdinal("OTIsUsed"))) _otisused = reader.GetBoolean(reader.GetOrdinal("OTIsUsed"));
                if (!reader.IsDBNull(reader.GetOrdinal("OTUsedTime"))) _otusedtime = reader.GetDateTime(reader.GetOrdinal("OTUsedTime"));
                if (!reader.IsDBNull(reader.GetOrdinal("OTUsedFromIP"))) _otusedfromip = reader.GetString(reader.GetOrdinal("OTUsedFromIP"));
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
                if (!reader.IsDBNull(reader.GetOrdinal("TinyURLAcceessID"))) _tinyurlacceessid = reader.GetInt64(reader.GetOrdinal("TinyURLAcceessID"));
                if (!reader.IsDBNull(reader.GetOrdinal("TinyURLId"))) _tinyurlid = reader.GetInt64(reader.GetOrdinal("TinyURLId"));
                if (!reader.IsDBNull(reader.GetOrdinal("OTIsUsed"))) _otisused = reader.GetBoolean(reader.GetOrdinal("OTIsUsed"));
                if (!reader.IsDBNull(reader.GetOrdinal("OTUsedTime"))) _otusedtime = reader.GetDateTime(reader.GetOrdinal("OTUsedTime"));
                if (!reader.IsDBNull(reader.GetOrdinal("OTUsedFromIP"))) _otusedfromip = reader.GetString(reader.GetOrdinal("OTUsedFromIP"));
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
