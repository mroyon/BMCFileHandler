﻿

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    public partial interface IfiletransferinfoFacadeObjects 
    { 
		
		
		
		[OperationContract]
        Task<IList<filetransferinfoEntity>> GetAllMyNotificaiton(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
        
        
            
    }
}