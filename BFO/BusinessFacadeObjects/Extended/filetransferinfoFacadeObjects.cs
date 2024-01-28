
using AppConfig.ConfigDAAC;
using BDO.Core.Base;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BFO.Base;
using DAC.Core.CoreFactory;
using IBFO.Core.IBusinessFacadeObjects.General;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BFO.Core.BusinessFacadeObjects.General
{
    public sealed partial class filetransferinfoFacadeObjects 
    {
	
		async Task<IList<filetransferinfoEntity>> IfiletransferinfoFacadeObjects.GetAllMyNotificaiton(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefiletransferinfoDataAccess().GetAllMyNotificaiton(filetransferinfo, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<filetransferinfoEntity> IfiletransferinfoFacade.GetAllMyNotificaiton"));
            }
		}
        
	}
}