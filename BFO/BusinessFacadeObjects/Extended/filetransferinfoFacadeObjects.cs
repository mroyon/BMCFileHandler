
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
        async Task<long> IfiletransferinfoFacadeObjects.UpdatePopUpData(BDO.Core.DataAccessObjects.Models.filetransferinfoEntity filetransferinfo, System.Threading.CancellationToken cancellationToken)
        {
            try
            {
                return await DataAccessFactory.CreatefiletransferinfoDataAccess().UpdatePopUpData(filetransferinfo, cancellationToken);
            }

            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfiletransferinfoFacade.UpdatePopUpData"));
            }
        }
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


        async Task<IList<filetransferinfoEntity>> IfiletransferinfoFacadeObjects.GetAllByPagesInBoxView(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefiletransferinfoDataAccess().GetAllByPagesInBoxView(filetransferinfo, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<filetransferinfoEntity> IfiletransferinfoFacade.GetAllByPagesInBoxView"));
            }
		}
        


        async Task<IList<filetransferinfoEntity>> IfiletransferinfoFacadeObjects.GetAllByPagesOutBoxView(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefiletransferinfoDataAccess().GetAllByPagesOutBoxView(filetransferinfo, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<filetransferinfoEntity> IfiletransferinfoFacade.GetAllByPagesOutBoxView"));
            }
		}


        async Task<long> IfiletransferinfoFacadeObjects.UpdateOpenData(BDO.Core.DataAccessObjects.Models.filetransferinfoEntity filetransferinfo, System.Threading.CancellationToken cancellationToken)
        {
            try
            {
                return await DataAccessFactory.CreatefiletransferinfoDataAccess().UpdateOpenData(filetransferinfo, cancellationToken);
            }

            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfiletransferinfoFacade.UpdateOpenData"));
            }
        }

        async Task<long> IfiletransferinfoFacadeObjects.UpdateOpenDataNPopUpData(BDO.Core.DataAccessObjects.Models.filetransferinfoEntity filetransferinfo, System.Threading.CancellationToken cancellationToken)
        {
            try
            {
                return await DataAccessFactory.CreatefiletransferinfoDataAccess().UpdateOpenDataNPopUpData(filetransferinfo, cancellationToken);
            }

            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfiletransferinfoFacade.UpdateOpenDataNPopUpData"));
            }
        }


        async Task<filetransferinfoEntity> IfiletransferinfoFacadeObjects.GetSingleNewPopTopView(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
        {
            try
            {
                return await DataAccessFactory.CreatefiletransferinfoDataAccess().GetSingleNewPopTopView(filetransferinfo, cancellationToken);
            }

            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("filetransferinfoEntity IfiletransferinfoFacade.GetSingleNewPopTopView"));
            }
        }

    }
}