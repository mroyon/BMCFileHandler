using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "chartEntity", Namespace = "http://www.KAF.com/types")]
    public partial class chartEntity : BaseEntity
    {
        #region Properties
    
        protected long ? _chartid;
        protected string _charttitle;
        protected long ? _chartvalues;
        protected Guid ? _userid;
        protected string _username;


        [DataMember]
        public Guid? userid
        {
            get { return _userid; }
            set { _userid = value; this.OnChnaged(); }
        }


        [DataMember]
        public string username
        {
            get { return _username; }
            set { _username = value; this.OnChnaged(); }
        }
        [DataMember]
        public long ? chartid
        {
            get { return _chartid; }
            set { _chartid = value; this.OnChnaged(); }
        }
        
        [DataMember]
        [MaxLength(250)]
        //[Display(Name = "charttitle", ResourceType = typeof(CLL.LLClasses.Models._chart))]
        //[Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._chart), ErrorMessageResourceName = "charttitleRequired")]
        public string charttitle
        {
            get { return _charttitle; }
            set { _charttitle = value; this.OnChnaged(); }
        }
        
        [DataMember]
        //[Display(Name = "chartvalues", ResourceType = typeof(CLL.LLClasses.Models._chart))]
        //[Required(ErrorMessageResourceType = typeof(CLL.LLClasses.Models._chart), ErrorMessageResourceName = "chartvaluesRequired")]
        public long ? chartvalues
        {
            get { return _chartvalues; }
            set { _chartvalues = value; this.OnChnaged(); }
        }
        
        
        #endregion
    
        #region Constructor
    
        public chartEntity():base()
        {
        }
        
        public chartEntity(IDataReader reader)
        {
            this.LoadFromReader(reader);
        }
        
         public chartEntity(IDataReader reader, bool IsListViewShow)
        {
            this.LoadFromReader(reader, IsListViewShow);
        }
        
      
        
        protected void LoadFromReader(IDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("UserName"))) _username = reader.GetString(reader.GetOrdinal("UserName"));
                if (!reader.IsDBNull(reader.GetOrdinal("ChartTitle"))) _charttitle = reader.GetString(reader.GetOrdinal("ChartTitle"));
                if (!reader.IsDBNull(reader.GetOrdinal("ChartValues"))) _chartvalues = reader.GetInt32(reader.GetOrdinal("ChartValues"));
                CurrentState = EntityState.Unchanged;
            }
        }


        protected void LoadFromReader(IDataReader reader, bool IsListViewShow)
        {
            if (reader != null && !reader.IsClosed)
            {
                this.BaseSecurityParam = new SecurityCapsule();
                if (!reader.IsDBNull(reader.GetOrdinal("ChartID"))) _chartid = reader.GetInt64(reader.GetOrdinal("ChartID"));
                if (!reader.IsDBNull(reader.GetOrdinal("ChartTitle"))) _charttitle = reader.GetString(reader.GetOrdinal("ChartTitle"));
                if (!reader.IsDBNull(reader.GetOrdinal("ChartValues"))) _chartvalues = reader.GetInt64(reader.GetOrdinal("ChartValues"));
                CurrentState = EntityState.Unchanged;
            }
        }
        
        #endregion
        
        
            
    }
}
