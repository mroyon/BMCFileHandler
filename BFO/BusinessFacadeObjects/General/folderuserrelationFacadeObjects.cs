
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
    public sealed partial class folderuserrelationFacadeObjects : BaseFacade, IfolderuserrelationFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "folderuserrelationFacadeObjects";
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

        public folderuserrelationFacadeObjects()
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

        ~folderuserrelationFacadeObjects()
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
		
		async Task<long> IfolderuserrelationFacadeObjects.Delete(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.CreatefolderuserrelationDataAccess().Delete(folderuserrelation, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfolderuserrelationFacade.Deletefolderuserrelation"));
            }
        }
		
		async Task<long> IfolderuserrelationFacadeObjects.Update(folderuserrelationEntity folderuserrelation , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderuserrelationDataAccess().Update(folderuserrelation,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("IfolderuserrelationFacade.Updatefolderuserrelation"));
            }
		}
		
		async Task<long> IfolderuserrelationFacadeObjects.Add(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderuserrelationDataAccess().Add(folderuserrelation, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfolderuserrelationFacade.Addfolderuserrelation"));
            }
		}
		
        async Task<long> IfolderuserrelationFacadeObjects.SaveList(List<folderuserrelationEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<folderuserrelationEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<folderuserrelationEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<folderuserrelationEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.CreatefolderuserrelationDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_folderuserrelation"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<folderuserrelationEntity>> IfolderuserrelationFacadeObjects.GetAll(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderuserrelationDataAccess().GetAll(folderuserrelation, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<folderuserrelationEntity> IfolderuserrelationFacade.GetAllfolderuserrelation"));
            }
		}
		
		async Task<IList<folderuserrelationEntity>> IfolderuserrelationFacadeObjects.GetAllByPages(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderuserrelationDataAccess().GetAllByPages(folderuserrelation,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<folderuserrelationEntity> IfolderuserrelationFacade.GetAllByPagesfolderuserrelation"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<folderuserrelationEntity>  IfolderuserrelationFacadeObjects.GetSingle(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderuserrelationDataAccess().GetSingle(folderuserrelation,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("folderuserrelationEntity IfolderuserrelationFacade.GetSinglefolderuserrelation"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<folderuserrelationEntity>> IfolderuserrelationFacadeObjects.GAPgListView(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderuserrelationDataAccess().GAPgListView(folderuserrelation,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<folderuserrelationEntity> IfolderuserrelationFacade.GAPgListViewfolderuserrelation"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
            
        
    
    
        #endregion
	}
}