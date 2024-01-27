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
    [DataContract(Name = "FileHandlerEntity", Namespace = "http://www.KAF.com/types")]
    public partial class FileHandlerEntity
    {
        #region Properties

        protected long? _queueid;
        protected string _filename;
        protected string _filefullpath;
        protected string _owner;
        protected DateTime? _filecreatedate;
        protected DateTime? _filemodifieddate;
        protected DateTime? _enqueuedatetime;
        protected int? _priority;
        protected string _filestatus;


        [DataMember]
        public long? queueid
        {
            get { return _queueid; }
            set { _queueid = value;  }
        }
        [DataMember]
        public string filename
        {
            get { return _filename; }
            set { _filename = value;  }
        }
        [DataMember]
        public string filefullpath
        {
            get { return _filefullpath; }
            set { _filefullpath = value; }
        }
        [DataMember]
        public string owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        [DataMember]
        public DateTime? filecreatedate
        {
            get { return _filecreatedate; }
            set { _filecreatedate = value; }
        }
        [DataMember]
        public DateTime? filemodifieddate
        {
            get { return _filemodifieddate; }
            set { _filemodifieddate = value; }
        }
        [DataMember]
        public DateTime? enqueuedatetime
        {
            get { return _enqueuedatetime; }
            set { _enqueuedatetime = value; }
        }
        [DataMember]
        public int? priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        [DataMember]
        public string filestatus
        {
            get { return _filestatus; }
            set { _filestatus = value; }
        }






        #endregion

        /// <summary>
        /// FileHandlerEntity
        /// </summary>
        public FileHandlerEntity() 
        {
        }
    }
}
