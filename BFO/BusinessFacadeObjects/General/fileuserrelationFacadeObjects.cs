
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
    public sealed partial class fileuserrelationFacadeObjects : BaseFacade, IfileuserrelationFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "fileuserrelationFacadeObjects";
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

        public fileuserrelationFacadeObjects()
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

        ~fileuserrelationFacadeObjects()
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
		
		async Task<long> IfileuserrelationFacadeObjects.Delete(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.CreatefileuserrelationDataAccess().Delete(fileuserrelation, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfileuserrelationFacade.Deletefileuserrelation"));
            }
        }
		
		async Task<long> IfileuserrelationFacadeObjects.Update(fileuserrelationEntity fileuserrelation , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefileuserrelationDataAccess().Update(fileuserrelation,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("IfileuserrelationFacade.Updatefileuserrelation"));
            }
		}
		
		async Task<long> IfileuserrelationFacadeObjects.Add(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefileuserrelationDataAccess().Add(fileuserrelation, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfileuserrelationFacade.Addfileuserrelation"));
            }
		}
		
        async Task<long> IfileuserrelationFacadeObjects.SaveList(List<fileuserrelationEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<fileuserrelationEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<fileuserrelationEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<fileuserrelationEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.CreatefileuserrelationDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_fileuserrelation"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<fileuserrelationEntity>> IfileuserrelationFacadeObjects.GetAll(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefileuserrelationDataAccess().GetAll(fileuserrelation, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<fileuserrelationEntity> IfileuserrelationFacade.GetAllfileuserrelation"));
            }
		}
		
		async Task<IList<fileuserrelationEntity>> IfileuserrelationFacadeObjects.GetAllByPages(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefileuserrelationDataAccess().GetAllByPages(fileuserrelation,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<fileuserrelationEntity> IfileuserrelationFacade.GetAllByPagesfileuserrelation"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<fileuserrelationEntity>  IfileuserrelationFacadeObjects.GetSingle(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefileuserrelationDataAccess().GetSingle(fileuserrelation,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("fileuserrelationEntity IfileuserrelationFacade.GetSinglefileuserrelation"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<fileuserrelationEntity>> IfileuserrelationFacadeObjects.GAPgListView(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefileuserrelationDataAccess().GAPgListView(fileuserrelation,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<fileuserrelationEntity> IfileuserrelationFacade.GAPgListViewfileuserrelation"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
            
        
    
    
        #endregion
	}
}