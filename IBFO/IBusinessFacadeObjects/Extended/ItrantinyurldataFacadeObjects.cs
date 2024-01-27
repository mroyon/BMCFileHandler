

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    public partial interface ItrantinyurldataFacadeObjects
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> SetActualURLByTinyURL(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
		
		#endregion Save Update Delete List
        #region Simple load Single Row
        [OperationContract]
        Task<trantinyurldataEntity> GetActualURLByTinyURL(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
         #endregion 
    }
}
