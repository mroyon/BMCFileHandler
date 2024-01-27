
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
    public sealed partial class folderstructureFacadeObjects : BaseFacade, IfolderstructureFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "folderstructureFacadeObjects";
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

        public folderstructureFacadeObjects()
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

        ~folderstructureFacadeObjects()
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
		
		async Task<long> IfolderstructureFacadeObjects.Delete(folderstructureEntity folderstructure, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.CreatefolderstructureDataAccess().Delete(folderstructure, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfolderstructureFacade.Deletefolderstructure"));
            }
        }
		
		async Task<long> IfolderstructureFacadeObjects.Update(folderstructureEntity folderstructure , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderstructureDataAccess().Update(folderstructure,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("IfolderstructureFacade.Updatefolderstructure"));
            }
		}
		
		async Task<long> IfolderstructureFacadeObjects.Add(folderstructureEntity folderstructure, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderstructureDataAccess().Add(folderstructure, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfolderstructureFacade.Addfolderstructure"));
            }
		}
		
        async Task<long> IfolderstructureFacadeObjects.SaveList(List<folderstructureEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<folderstructureEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<folderstructureEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<folderstructureEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.CreatefolderstructureDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_folderstructure"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<folderstructureEntity>> IfolderstructureFacadeObjects.GetAll(folderstructureEntity folderstructure, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderstructureDataAccess().GetAll(folderstructure, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<folderstructureEntity> IfolderstructureFacade.GetAllfolderstructure"));
            }
		}
		
		async Task<IList<folderstructureEntity>> IfolderstructureFacadeObjects.GetAllByPages(folderstructureEntity folderstructure, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderstructureDataAccess().GetAllByPages(folderstructure,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<folderstructureEntity> IfolderstructureFacade.GetAllByPagesfolderstructure"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        async Task<long> IfolderstructureFacadeObjects.SaveMasterDetfilestructure(folderstructureEntity Master, List<filestructureEntity> DetailList, CancellationToken cancellationToken)
        {
            try
               {
                    DetailList.ForEach(P => P.BaseSecurityParam = new SecurityCapsule());
                    DetailList.ForEach(P => P.BaseSecurityParam = Master.BaseSecurityParam);
                    if (Master.CurrentState == BaseEntity.EntityState.Deleted)
						DetailList.ForEach(p => p.CurrentState = BaseEntity.EntityState.Deleted);
                    IList<filestructureEntity> listAdded = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                    IList<filestructureEntity> listUpdated = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                    IList<filestructureEntity> listDeleted = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
                    return await DataAccessFactory.CreatefolderstructureDataAccess().SaveMasterDetfilestructure(Master, listAdded, listUpdated, listDeleted, cancellationToken);
               }
               catch (Exception ex)
               {
                    throw GetFacadeException(ex, SourceOfException("Imer_poFacade.SaveMasterDetfilestructure"));
               }
        }
        
        
        async Task<long> IfolderstructureFacadeObjects.SaveMasterDetfolderuserrelation(folderstructureEntity Master, List<folderuserrelationEntity> DetailList, CancellationToken cancellationToken)
        {
            try
               {
                    DetailList.ForEach(P => P.BaseSecurityParam = new SecurityCapsule());
                    DetailList.ForEach(P => P.BaseSecurityParam = Master.BaseSecurityParam);
                    if (Master.CurrentState == BaseEntity.EntityState.Deleted)
						DetailList.ForEach(p => p.CurrentState = BaseEntity.EntityState.Deleted);
                    IList<folderuserrelationEntity> listAdded = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                    IList<folderuserrelationEntity> listUpdated = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                    IList<folderuserrelationEntity> listDeleted = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
                    return await DataAccessFactory.CreatefolderstructureDataAccess().SaveMasterDetfolderuserrelation(Master, listAdded, listUpdated, listDeleted, cancellationToken);
               }
               catch (Exception ex)
               {
                    throw GetFacadeException(ex, SourceOfException("Imer_poFacade.SaveMasterDetfolderuserrelation"));
               }
        }
        
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<folderstructureEntity>  IfolderstructureFacadeObjects.GetSingle(folderstructureEntity folderstructure, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderstructureDataAccess().GetSingle(folderstructure,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("folderstructureEntity IfolderstructureFacade.GetSinglefolderstructure"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<folderstructureEntity>> IfolderstructureFacadeObjects.GAPgListView(folderstructureEntity folderstructure, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefolderstructureDataAccess().GAPgListView(folderstructure,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<folderstructureEntity> IfolderstructureFacade.GAPgListViewfolderstructure"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
            
        
    
    
        #endregion
	}
}