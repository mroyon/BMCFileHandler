
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
    public sealed partial class gen_serviceinfoFacadeObjects 
    {
	
		async Task<IList<gen_dropdownEntity>> Igen_serviceinfoFacadeObjects.GetMappedDataForDropDown(BDO.Core.DataAccessObjects.Models.gen_serviceinfoEntity gen_serviceinfo, System.Threading.CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_serviceinfoDataAccess().GetMappedDataForDropDown(gen_serviceinfo,cancellationToken);
			}
			catch (Exception ex)
			{
				throw GetFacadeException(ex, SourceOfException("IList<gen_serviceinfoEntity> Igen_serviceinfoFacade.GetMappedDataForDropDown")); 
			}
		}

    }
}