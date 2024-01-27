
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
    public sealed partial class trantinyurldataFacadeObjects : BaseFacade, ItrantinyurldataFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "trantinyurldataFacadeObjects";
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

        public trantinyurldataFacadeObjects()
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

        ~trantinyurldataFacadeObjects()
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
		
		async Task<long> ItrantinyurldataFacadeObjects.Delete(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.CreatetrantinyurldataDataAccess().Delete(trantinyurldata, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("ItrantinyurldataFacade.Deletetrantinyurldata"));
            }
        }
		
		async Task<long> ItrantinyurldataFacadeObjects.Update(trantinyurldataEntity trantinyurldata , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurldataDataAccess().Update(trantinyurldata,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("ItrantinyurldataFacade.Updatetrantinyurldata"));
            }
		}
		
		async Task<long> ItrantinyurldataFacadeObjects.Add(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurldataDataAccess().Add(trantinyurldata, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("ItrantinyurldataFacade.Addtrantinyurldata"));
            }
		}
		
        async Task<long> ItrantinyurldataFacadeObjects.SaveList(List<trantinyurldataEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<trantinyurldataEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<trantinyurldataEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<trantinyurldataEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.CreatetrantinyurldataDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_trantinyurldata"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<trantinyurldataEntity>> ItrantinyurldataFacadeObjects.GetAll(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurldataDataAccess().GetAll(trantinyurldata, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<trantinyurldataEntity> ItrantinyurldataFacade.GetAlltrantinyurldata"));
            }
		}
		
		async Task<IList<trantinyurldataEntity>> ItrantinyurldataFacadeObjects.GetAllByPages(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurldataDataAccess().GetAllByPages(trantinyurldata,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<trantinyurldataEntity> ItrantinyurldataFacade.GetAllByPagestrantinyurldata"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        async Task<long> ItrantinyurldataFacadeObjects.SaveMasterDettrantinyurlaccessinfo(trantinyurldataEntity Master, List<trantinyurlaccessinfoEntity> DetailList, CancellationToken cancellationToken)
        {
            try
               {
                    DetailList.ForEach(P => P.BaseSecurityParam = new SecurityCapsule());
                    DetailList.ForEach(P => P.BaseSecurityParam = Master.BaseSecurityParam);
                    if (Master.CurrentState == BaseEntity.EntityState.Deleted)
						DetailList.ForEach(p => p.CurrentState = BaseEntity.EntityState.Deleted);
                    IList<trantinyurlaccessinfoEntity> listAdded = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                    IList<trantinyurlaccessinfoEntity> listUpdated = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                    IList<trantinyurlaccessinfoEntity> listDeleted = DetailList.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
                    return await DataAccessFactory.CreatetrantinyurldataDataAccess().SaveMasterDettrantinyurlaccessinfo(Master, listAdded, listUpdated, listDeleted, cancellationToken);
               }
               catch (Exception ex)
               {
                    throw GetFacadeException(ex, SourceOfException("Imer_poFacade.SaveMasterDettrantinyurlaccessinfo"));
               }
        }
        
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<trantinyurldataEntity>  ItrantinyurldataFacadeObjects.GetSingle(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurldataDataAccess().GetSingle(trantinyurldata,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("trantinyurldataEntity ItrantinyurldataFacade.GetSingletrantinyurldata"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<trantinyurldataEntity>> ItrantinyurldataFacadeObjects.GAPgListView(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatetrantinyurldataDataAccess().GAPgListView(trantinyurldata,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<trantinyurldataEntity> ItrantinyurldataFacade.GAPgListViewtrantinyurldata"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
            
        
    
    
        #endregion
	}
}