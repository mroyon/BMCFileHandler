using System;
using System.Runtime.Serialization;
using System.Data;
using BDO.Core.Base;
using System.ComponentModel.DataAnnotations;


namespace BDO.Core.DataAccessObjects.Models
{
    [Serializable]
    [DataContract(Name = "fileStructureReadOnlyEntity", Namespace = "http://www.KAF.com/types")]

    public partial class fileStructureReadOnlyEntity
    {
        [DataMember]

        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }



    }
}
