using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface IfiletransferinfoDataAccessObjects
    {
		 
		Task<IList<filetransferinfoEntity>> GetAllMyNotificaiton(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
		
		
    }
}
