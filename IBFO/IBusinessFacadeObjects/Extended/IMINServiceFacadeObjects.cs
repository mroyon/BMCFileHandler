

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
    [ServiceContract(Name = "IMINServiceFacadeObjects")]
    public partial interface IMINServiceFacadeObjects : IDisposable
    { 
	
    }
}
