
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
    public sealed partial class filestructureFacadeObjects : BaseFacade, IfilestructureFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "filestructureFacadeObjects";
        private bool _isDisposed;
        private Context _currentContext;

        private BaseDataAccessFactory _dataAccessFactory;

        #endregion

        #region Private Properties

        private Context CurrentContext
        {
            [DebuggerStepThrough()]
            get
            {
                if (_currentContext == null)
                {
                    _currentContext = new Context();
                }

                return _currentContext;
            }
        }

        private BaseDataAccessFactory DataAccessFactory
        {
            [DebuggerStepThrough()]
            get
            {
                if (_dataAccessFactory == null)
                {
                    _dataAccessFactory = BaseDataAccessFactory.Create(CurrentContext);
                }

                return _dataAccessFactory;
            }
        }

        #endregion

        #region Constructer & Destructor

        public filestructureFacadeObjects()
            : base()
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (_currentContext != null)
                    {
                        _currentContext.Dispose();
                    }
                }
            }

            _isDisposed = true;
        }

        ~filestructureFacadeObjects()
        {
            Dispose(false);
        }
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        #endregion
		
		#region Business Facade
		
		#region Save Update Delete List	
		
		async Task<long> IfilestructureFacadeObjects.Delete(filestructureEntity filestructure, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.CreatefilestructureDataAccess().Delete(filestructure, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfilestructureFacade.Deletefilestructure"));
            }
        }
		
		async Task<long> IfilestructureFacadeObjects.Update(filestructureEntity filestructure , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefilestructureDataAccess().Update(filestructure,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("IfilestructureFacade.Updatefilestructure"));
            }
		}
		
		async Task<long> IfilestructureFacadeObjects.Add(filestructureEntity filestructure, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefilestructureDataAccess().Add(filestructure, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfilestructureFacade.Addfilestructure"));
            }
		}
		
        async Task<long> IfilestructureFacadeObjects.SaveList(List<filestructureEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<filestructureEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<filestructureEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<filestructureEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.CreatefilestructureDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_filestructure"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<filestructureEntity>> IfilestructureFacadeObjects.GetAll(filestructureEntity filestructure, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefilestructureDataAccess().GetAll(filestructure, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<filestructureEntity> IfilestructureFacade.GetAllfilestructure"));
            }
		}
		
		async Task<IList<filestructureEntity>> IfilestructureFacadeObjects.GetAllByPages(filestructureEntity filestructure, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefilestructureDataAccess().GetAllByPages(filestructure,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<filestructureEntity> IfilestructureFacade.GetAllByPagesfilestructure"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        async Task<long> IfilestructureFacadeObjects.SaveMasterDetfileuserrelation(filestructureEntity Master, List<fileuserrelationEntity> DetailList, CancellationToken cancellationToken)
        {
            try
               {
                    DetailList.ForEach(P => P.BaseSecurityParam = new SecurityCapsule());
                    DetailList.ForEach(P => P.BaseSecurityParam = Master.BaseSecurityParam);
                    if (Master.CurrentState == BaseEntity.EntityState.Deleted)
						DetailList.ForEach(p => p.CurrentState = BaseEntity.EntityState.Deleted);
                    IList<fileuserrelationEntity> listAdded = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                    IList<fileuserrelationEntity> listUpdated = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                    IList<fileuserrelationEntity> listDeleted = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
                    return await DataAccessFactory.CreatefilestructureDataAccess().SaveMasterDetfileuserrelation(Master, listAdded, listUpdated, listDeleted, cancellationToken);
               }
               catch (Exception ex)
               {
                    throw GetFacadeException(ex, SourceOfException("Imer_poFacade.SaveMasterDetfileuserrelation"));
               }
        }
        
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<filestructureEntity>  IfilestructureFacadeObjects.GetSingle(filestructureEntity filestructure, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefilestructureDataAccess().GetSingle(filestructure,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("filestructureEntity IfilestructureFacade.GetSinglefilestructure"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<filestructureEntity>> IfilestructureFacadeObjects.GAPgListView(filestructureEntity filestructure, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefilestructureDataAccess().GAPgListView(filestructure,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<filestructureEntity> IfilestructureFacade.GAPgListViewfilestructure"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
            
        
    
    
        #endregion
	}
}