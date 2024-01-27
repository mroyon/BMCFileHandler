using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface ItrantinyurldataDataAccessObjects
    {

        #region SetActualURLByTinyURL Entity	

        Task<long> SetActualURLByTinyURL(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);

        #endregion SetActualURLByTinyURL

        #region GetActualURLByTinyURL
        Task<trantinyurldataEntity> GetActualURLByTinyURL(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
         #endregion 
        
    }
}
