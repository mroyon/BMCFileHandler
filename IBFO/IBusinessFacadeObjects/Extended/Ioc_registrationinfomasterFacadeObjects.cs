

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
    public partial interface Ioc_registrationinfomasterFacadeObjects 
    { 
		
		


        [OperationContract]
        Task<oc_registrationinfomasterEntity> GetSingleByCivilID(oc_registrationinfomasterEntity oc_registrationinfomaster, CancellationToken cancellationToken);


        [OperationContract]
        Task<List<KAF_GetMilitaryFamilyRegEntity>> GetUnregisteredFamilyData(KAF_GetMilitaryFamilyRegEntity kaf_getmilitaryfamilyreg, CancellationToken cancellationToken);

    }
}
