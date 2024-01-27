

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.DataAccessObjects.ExtendedEntities;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "IKnsServiceFacadeObjects")]
    public partial interface IKnsServiceFacadeObjects : IDisposable
    { 
	
		
		[OperationContract]
        Task<GetStatusByCivilIDEntity> GetStatusByCivilID(GetStatusByCivilIDEntity objEntity, CancellationToken cancellationToken);




        [OperationContract]
        Task<KAFMilitaryInfoEntity> GetMilitaryInfoByMilitaryID(KAFMilitaryInfoEntity objEntity, CancellationToken cancellationToken);



        [OperationContract]
        Task<KAFMilitaryInfoEntity> GetMilitaryInfoByCivilID(KAFMilitaryInfoEntity objEntity, CancellationToken cancellationToken);


        [OperationContract]
        Task<KAFMilitaryInfoEntity> GetMilitaryInfoByCivilID_WithClause(KAFMilitaryInfoEntity objEntity, CancellationToken cancellationToken);

    }
}
