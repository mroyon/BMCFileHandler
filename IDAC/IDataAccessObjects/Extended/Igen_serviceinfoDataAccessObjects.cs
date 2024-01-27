using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
    public partial interface Igen_serviceinfoDataAccessObjects
    {

        Task<IList<gen_dropdownEntity>> GetMappedDataForDropDown(gen_serviceinfoEntity gen_servicestatus, CancellationToken cancellationToken);

    }
}
