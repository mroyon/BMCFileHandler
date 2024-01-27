
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
    public sealed partial class folderstructurehistFacadeObjects : BaseFacade, IfolderstructurehistFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "folderstructurehistFacadeObjects";
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

        public folderstructurehistFacadeObjects()
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

        ~folderstructurehistFacadeObjects()
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
		
		async Task<long> IfolderstructurehistFacadeObjects.Delete(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.CreatefolderstructurehistDataAccess().Delete(folderstructurehist, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfolderstructurehistFacade.Deletefolderstructurehist"));
            }
        }
		
		async Task<long> IfolderstructurehistFacadeObjects.Update(folderstructurehistEntity folderstructurehist , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderstructurehistDataAccess().Update(folderstructurehist,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("IfolderstructurehistFacade.Updatefolderstructurehist"));
            }
		}
		
		async Task<long> IfolderstructurehistFacadeObjects.Add(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderstructurehistDataAccess().Add(folderstructurehist, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfolderstructurehistFacade.Addfolderstructurehist"));
            }
		}
		
        async Task<long> IfolderstructurehistFacadeObjects.SaveList(List<folderstructurehistEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<folderstructurehistEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<folderstructurehistEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<folderstructurehistEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.CreatefolderstructurehistDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_folderstructurehist"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<folderstructurehistEntity>> IfolderstructurehistFacadeObjects.GetAll(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderstructurehistDataAccess().GetAll(folderstructurehist, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<folderstructurehistEntity> IfolderstructurehistFacade.GetAllfolderstructurehist"));
            }
		}
		
		async Task<IList<folderstructurehistEntity>> IfolderstructurehistFacadeObjects.GetAllByPages(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderstructurehistDataAccess().GetAllByPages(folderstructurehist,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<folderstructurehistEntity> IfolderstructurehistFacade.GetAllByPagesfolderstructurehist"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<folderstructurehistEntity>  IfolderstructurehistFacadeObjects.GetSingle(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderstructurehistDataAccess().GetSingle(folderstructurehist,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("folderstructurehistEntity IfolderstructurehistFacade.GetSinglefolderstructurehist"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<folderstructurehistEntity>> IfolderstructurehistFacadeObjects.GAPgListView(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderstructurehistDataAccess().GAPgListView(folderstructurehist,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<folderstructurehistEntity> IfolderstructurehistFacade.GAPgListViewfolderstructurehist"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
            
        
    
    
        #endregion
	}
}