using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BDO.DataAccessObjects.ExtendedEntities
{
    [Serializable]
    [DataContract(Name = "PageEntity", Namespace = "http://www.KAF.com/types")]

    public class PageEntity
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }
    }

}
