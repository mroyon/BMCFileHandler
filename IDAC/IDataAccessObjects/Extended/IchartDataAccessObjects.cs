using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface IchartDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(chartEntity chart, CancellationToken cancellationToken);
		
        Task<long> Update(chartEntity chart, CancellationToken cancellationToken);
        
        Task<long> Delete(chartEntity chart, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<chartEntity> listAdded, IList<chartEntity> listUpdated, IList<chartEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<chartEntity>> GetAll(chartEntity chart, CancellationToken cancellationToken);
		
        Task<IList<chartEntity>> GetAllByPages(chartEntity chart, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<chartEntity> GetSingle(chartEntity chart, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<chartEntity>> GAPgListView(chartEntity chart, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
               
        
        
        
        
    }
}
