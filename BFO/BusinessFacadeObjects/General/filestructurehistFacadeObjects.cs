
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
    public sealed partial class filestructurehistFacadeObjects : BaseFacade, IfilestructurehistFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "filestructurehistFacadeObjects";
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

        public filestructurehistFacadeObjects()
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

        ~filestructurehistFacadeObjects()
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
		
		async Task<long> IfilestructurehistFacadeObjects.Delete(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.CreatefilestructurehistDataAccess().Delete(filestructurehist, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfilestructurehistFacade.Deletefilestructurehist"));
            }
        }
		
		async Task<long> IfilestructurehistFacadeObjects.Update(filestructurehistEntity filestructurehist , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefilestructurehistDataAccess().Update(filestructurehist,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("IfilestructurehistFacade.Updatefilestructurehist"));
            }
		}
		
		async Task<long> IfilestructurehistFacadeObjects.Add(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefilestructurehistDataAccess().Add(filestructurehist, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfilestructurehistFacade.Addfilestructurehist"));
            }
		}
		
        async Task<long> IfilestructurehistFacadeObjects.SaveList(List<filestructurehistEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<filestructurehistEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<filestructurehistEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<filestructurehistEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.CreatefilestructurehistDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_filestructurehist"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<filestructurehistEntity>> IfilestructurehistFacadeObjects.GetAll(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefilestructurehistDataAccess().GetAll(filestructurehist, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<filestructurehistEntity> IfilestructurehistFacade.GetAllfilestructurehist"));
            }
		}
		
		async Task<IList<filestructurehistEntity>> IfilestructurehistFacadeObjects.GetAllByPages(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefilestructurehistDataAccess().GetAllByPages(filestructurehist,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<filestructurehistEntity> IfilestructurehistFacade.GetAllByPagesfilestructurehist"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<filestructurehistEntity>  IfilestructurehistFacadeObjects.GetSingle(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefilestructurehistDataAccess().GetSingle(filestructurehist,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("filestructurehistEntity IfilestructurehistFacade.GetSinglefilestructurehist"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<filestructurehistEntity>> IfilestructurehistFacadeObjects.GAPgListView(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefilestructurehistDataAccess().GAPgListView(filestructurehist,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<filestructurehistEntity> IfilestructurehistFacade.GAPgListViewfilestructurehist"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
            
        
    
    
        #endregion
	}
}