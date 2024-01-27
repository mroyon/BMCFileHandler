using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;


namespace BDO.Core.DataAccessObjects.ExtendedEntities
{
    public class TinyURLPassThroughSettings
    {

        public string WebApiAddress { get; set; }
        public int EncryptionLength { get; set; }

    }
}
