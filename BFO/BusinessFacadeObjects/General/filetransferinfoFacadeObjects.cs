
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
    public sealed partial class filetransferinfoFacadeObjects : BaseFacade, IfiletransferinfoFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "filetransferinfoFacadeObjects";
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

        public filetransferinfoFacadeObjects()
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

        ~filetransferinfoFacadeObjects()
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
		
		async Task<long> IfiletransferinfoFacadeObjects.Delete(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.CreatefiletransferinfoDataAccess().Delete(filetransferinfo, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfiletransferinfoFacade.Deletefiletransferinfo"));
            }
        }
		
		async Task<long> IfiletransferinfoFacadeObjects.Update(filetransferinfoEntity filetransferinfo , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefiletransferinfoDataAccess().Update(filetransferinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("IfiletransferinfoFacade.Updatefiletransferinfo"));
            }
		}
		
		async Task<long> IfiletransferinfoFacadeObjects.Add(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefiletransferinfoDataAccess().Add(filetransferinfo, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IfiletransferinfoFacade.Addfiletransferinfo"));
            }
		}
		
        async Task<long> IfiletransferinfoFacadeObjects.SaveList(List<filetransferinfoEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<filetransferinfoEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<filetransferinfoEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<filetransferinfoEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.CreatefiletransferinfoDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_filetransferinfo"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<filetransferinfoEntity>> IfiletransferinfoFacadeObjects.GetAll(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefiletransferinfoDataAccess().GetAll(filetransferinfo, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<filetransferinfoEntity> IfiletransferinfoFacade.GetAllfiletransferinfo"));
            }
		}
		
		async Task<IList<filetransferinfoEntity>> IfiletransferinfoFacadeObjects.GetAllByPages(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefiletransferinfoDataAccess().GetAllByPages(filetransferinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<filetransferinfoEntity> IfiletransferinfoFacade.GetAllByPagesfiletransferinfo"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<filetransferinfoEntity>  IfiletransferinfoFacadeObjects.GetSingle(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefiletransferinfoDataAccess().GetSingle(filetransferinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("filetransferinfoEntity IfiletransferinfoFacade.GetSinglefiletransferinfo"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<filetransferinfoEntity>> IfiletransferinfoFacadeObjects.GAPgListView(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatefiletransferinfoDataAccess().GAPgListView(filetransferinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<filetransferinfoEntity> IfiletransferinfoFacade.GAPgListViewfiletransferinfo"));
            }
		}
        #endregion

        #region Extras Reviewed, Published, Archived
        #endregion




        #endregion
    }
}