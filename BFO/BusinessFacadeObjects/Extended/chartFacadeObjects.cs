
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
    public sealed partial class chartFacadeObjects : BaseFacade, IchartFacadeObjects
    {
	
		#region Instance Variables
		private string ClassName = "chartFacadeObjects";
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

        public chartFacadeObjects()
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

        ~chartFacadeObjects()
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
		
		async Task<long> IchartFacadeObjects.Delete(chartEntity chart, CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.CreatechartDataAccess().Delete(chart, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IchartFacade.Deletechart"));
            }
        }
		
		async Task<long> IchartFacadeObjects.Update(chartEntity chart , CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatechartDataAccess().Update(chart,cancellationToken);
			}
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("IchartFacade.Updatechart"));
            }
		}
		
		async Task<long> IchartFacadeObjects.Add(chartEntity chart, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatechartDataAccess().Add(chart, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IchartFacade.Addchart"));
            }
		}
		
        async Task<long> IchartFacadeObjects.SaveList(List<chartEntity> list, CancellationToken cancellationToken)
        {
            try
            {
                IList<chartEntity> listAdded = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Added);
                IList<chartEntity> listUpdated = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Changed);
                IList<chartEntity> listDeleted = list.FindAll(Item => Item.CurrentState == BaseEntity.EntityState.Deleted);
               
                return await DataAccessFactory.CreatechartDataAccess().SaveList(listAdded, listUpdated, listDeleted, cancellationToken);
            }
           
            catch (Exception ex)
            {
               throw GetFacadeException(ex, SourceOfException("Imer_poFacade.Save_chart"));
            }
        }
        
		#endregion Save Update Delete List	
		
		#region GetAll
		
		async Task<IList<chartEntity>> IchartFacadeObjects.GetAll(chartEntity chart, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatechartDataAccess().GetAll(chart, cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<chartEntity> IchartFacade.GetAllchart"));
            }
		}
		
		async Task<IList<chartEntity>> IchartFacadeObjects.GetAllByPages(chartEntity chart, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatechartDataAccess().GetAllByPages(chart,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<chartEntity> IchartFacade.GetAllByPageschart"));
            }
		}
		
		#endregion GetAll
        
        #region FOR Master Details SAVE	
        
        #endregion	
	
        
        #region Simple load Single Row
        async  Task<chartEntity>  IchartFacadeObjects.GetSingle(chartEntity chart, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatechartDataAccess().GetSingle(chart,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("chartEntity IchartFacade.GetSinglechart"));
            }
		}
        #endregion 
         
        #region ForListView Paged Method
        async Task<IList<chartEntity>> IchartFacadeObjects.GAPgListView(chartEntity chart, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.CreatechartDataAccess().GAPgListView(chart,cancellationToken);
			}
           
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("IList<chartEntity> IchartFacade.GAPgListViewchart"));
            }
		}
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion 
    
    
    
            
        
    
    
        #endregion
	}
}