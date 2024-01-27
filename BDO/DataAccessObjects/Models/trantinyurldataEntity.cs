﻿using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "trantinyurldataEntity", Namespace = "http://www.KAF.com/types")]
    public partial class trantinyurldataEntity : BaseEntity
    {
        #region Properties
    
        protected long ? _tinyurlid;
        protected string _tinyurl;
        protected string _tinyurlcode;
        protected string _actualurl;
        protected long ? _serviceid;
        protected bool ? _isactive;
        protected bool ? _otisonetime;
        protected bool ? _otisused;
        protected DateTime ? _otusedtime;
        protected string _otusedfromip;
                
        
        [DataMember]
        public long ? tinyurlid
        {
            get { return _tinyurlid; }
            set { _tinyurlid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(350)]
        [Display(Name = "tinyurl", ResourceType = typeof(CLL.LLClasses.Models._trantinyurldata))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._trantinyurldata), ErrorMessageResourceName = "tinyurlRequired")]
        public string tinyurl
        {
            get { return _tinyurl; }
            set { _tinyurl = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(150)]
        [Display(Name = "tinyurlcode", ResourceType = typeof(CLL.LLClasses.Models._trantinyurldata))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._trantinyurldata), ErrorMessageResourceName = "tinyurlcodeRequired")]
        public string tinyurlcode
        {
            get { return _tinyurlcode; }
            set { _tinyurlcode = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[MaxLength(-1)]
        [Display(Name = "actualurl", ResourceType = typeof(CLL.LLClasses.Models._trantinyurldata))]
        public string actualurl
        {
            get { return _actualurl; }
            set { _actualurl = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "serviceid", ResourceType = typeof(CLL.LLClasses.Models._trantinyurldata))]
        [Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._trantinyurldata), ErrorMessageResourceName = "serviceidRequired")]
        public long ? serviceid
        {
            get { return _serviceid; }
            set { _serviceid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "isactive", ResourceType = typeof(CLL.LLClasses.Models._trantinyurldata))]
        public bool ? isactive
        {
            get { return _isactive; }
            set { _isactive = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "otisonetime", ResourceType = typeof(CLL.LLClasses.Models._trantinyurldata))]
        public bool ? otisonetime
        {
            get { return _otisonetime; }
            set { _otisonetime = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "otisused", ResourceType = typeof(CLL.LLClasses.Models._trantinyurldata))]
        public bool ? otisused
        {
            get { return _otisused; }
            set { _otisused = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [Display(Name = "otusedtime", ResourceType = typeof(CLL.LLClasses.Models._trantinyurldata))]
        public DateTime ? otusedtime
        {
            get { return _otusedtime; }
            set { _otusedtime = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(50)]
        [Display(Name = "otusedfromip", ResourceType = typeof(CLL.LLClasses.Models._trantinyurldata))]
        public string otusedfromip
        {
            get { return _otusedfromip; }
            set { _otusedfromip = value; this.OnChnaged(); }
        }
        
        
        #endregion
    
        #region Constructor
    
        public trantinyurldataEntity():base()
        {
        }
        
        public trantinyurldataEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }
        
         public trantinyurldataEntity(IDataReader reader, bool IsListViewShow)
        {
            this.LoadFromReader(reader, IsListViewShow);
        }
        
      
        
        protected void LoadFromReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("TinyURLId"))) _tinyurlid = reader.GetInt64(reader.GetOrdinal("TinyURLId"));
                if (!reader.IsDBNull(reader.GetOrdinal("TinyURL"))) _tinyurl = reader.GetString(reader.GetOrdinal("TinyURL"));
                if (!reader.IsDBNull(reader.GetOrdinal("TinyURLCode"))) _tinyurlcode = reader.GetString(reader.GetOrdinal("TinyURLCode"));
                if (!reader.IsDBNull(reader.GetOrdinal("ActualURL"))) _actualurl = reader.GetString(reader.GetOrdinal("ActualURL"));
                if (!reader.IsDBNull(reader.GetOrdinal("ServiceID"))) _serviceid = reader.GetInt64(reader.GetOrdinal("ServiceID"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsActive"))) _isactive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                if (!reader.IsDBNull(reader.GetOrdinal("OTIsOneTime"))) _otisonetime = reader.GetBoolean(reader.GetOrdinal("OTIsOneTime"));
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
                if (!reader.IsDBNull(reader.GetOrdinal("TinyURLId"))) _tinyurlid = reader.GetInt64(reader.GetOrdinal("TinyURLId"));
                if (!reader.IsDBNull(reader.GetOrdinal("TinyURL"))) _tinyurl = reader.GetString(reader.GetOrdinal("TinyURL"));
                if (!reader.IsDBNull(reader.GetOrdinal("TinyURLCode"))) _tinyurlcode = reader.GetString(reader.GetOrdinal("TinyURLCode"));
                if (!reader.IsDBNull(reader.GetOrdinal("ActualURL"))) _actualurl = reader.GetString(reader.GetOrdinal("ActualURL"));
                if (!reader.IsDBNull(reader.GetOrdinal("ServiceID"))) _serviceid = reader.GetInt64(reader.GetOrdinal("ServiceID"));
                if (!reader.IsDBNull(reader.GetOrdinal("IsActive"))) _isactive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                if (!reader.IsDBNull(reader.GetOrdinal("OTIsOneTime"))) _otisonetime = reader.GetBoolean(reader.GetOrdinal("OTIsOneTime"));
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
