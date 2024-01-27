
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
    public sealed partial class trantinyurldataFacadeObjects 
    {
		async Task<long> ItrantinyurldataFacadeObjects.SetActualURLByTinyURL(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurldataDataAccess().SetActualURLByTinyURL(trantinyurldata, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("ItrantinyurldataFacade.SetActualURLByTinyURL"));
            }
		}
        async  Task<trantinyurldataEntity>  ItrantinyurldataFacadeObjects.GetActualURLByTinyURL(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurldataDataAccess().GetActualURLByTinyURL(trantinyurldata,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("trantinyurldataEntity ItrantinyurldataFacade.GetActualURLByTinyURL"));
            }
		}
	}
}