
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
    public sealed partial class trantinyurlaccessinfoFacadeObjects : BaseFacade, ItrantinyurlaccessinfoFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "trantinyurlaccessinfoFacadeObjects";
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

        public trantinyurlaccessinfoFacadeObjects()
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

        ~trantinyurlaccessinfoFacadeObjects()
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
		
		async Task<long> ItrantinyurlaccessinfoFacadeObjects.Delete(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.CreatetrantinyurlaccessinfoDataAccess().Delete(trantinyurlaccessinfo, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("ItrantinyurlaccessinfoFacade.Deletetrantinyurlaccessinfo"));
            }
        }
		
		async Task<long> ItrantinyurlaccessinfoFacadeObjects.Update(trantinyurlaccessinfoEntity trantinyurlaccessinfo , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurlaccessinfoDataAccess().Update(trantinyurlaccessinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("ItrantinyurlaccessinfoFacade.Updatetrantinyurlaccessinfo"));
            }
		}
		
		async Task<long> ItrantinyurlaccessinfoFacadeObjects.Add(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurlaccessinfoDataAccess().Add(trantinyurlaccessinfo, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("ItrantinyurlaccessinfoFacade.Addtrantinyurlaccessinfo"));
            }
		}
		
        async Task<long> ItrantinyurlaccessinfoFacadeObjects.SaveList(List<trantinyurlaccessinfoEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<trantinyurlaccessinfoEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<trantinyurlaccessinfoEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<trantinyurlaccessinfoEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.CreatetrantinyurlaccessinfoDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_trantinyurlaccessinfo"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<trantinyurlaccessinfoEntity>> ItrantinyurlaccessinfoFacadeObjects.GetAll(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurlaccessinfoDataAccess().GetAll(trantinyurlaccessinfo, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<trantinyurlaccessinfoEntity> ItrantinyurlaccessinfoFacade.GetAlltrantinyurlaccessinfo"));
            }
		}
		
		async Task<IList<trantinyurlaccessinfoEntity>> ItrantinyurlaccessinfoFacadeObjects.GetAllByPages(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurlaccessinfoDataAccess().GetAllByPages(trantinyurlaccessinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<trantinyurlaccessinfoEntity> ItrantinyurlaccessinfoFacade.GetAllByPagestrantinyurlaccessinfo"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<trantinyurlaccessinfoEntity>  ItrantinyurlaccessinfoFacadeObjects.GetSingle(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurlaccessinfoDataAccess().GetSingle(trantinyurlaccessinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("trantinyurlaccessinfoEntity ItrantinyurlaccessinfoFacade.GetSingletrantinyurlaccessinfo"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<trantinyurlaccessinfoEntity>> ItrantinyurlaccessinfoFacadeObjects.GAPgListView(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurlaccessinfoDataAccess().GAPgListView(trantinyurlaccessinfo,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<trantinyurlaccessinfoEntity> ItrantinyurlaccessinfoFacade.GAPgListViewtrantinyurlaccessinfo"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
            
        
    
    
        #endregion
	}
}