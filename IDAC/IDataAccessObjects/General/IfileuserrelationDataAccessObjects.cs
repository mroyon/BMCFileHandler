using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface IfileuserrelationDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
		
        Task<long> Update(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
        
        Task<long> Delete(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<fileuserrelationEntity> listAdded, IList<fileuserrelationEntity> listUpdated, IList<fileuserrelationEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<fileuserrelationEntity>> GetAll(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
		
        Task<IList<fileuserrelationEntity>> GetAllByPages(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<fileuserrelationEntity> GetSingle(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<fileuserrelationEntity>> GAPgListView(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
               
        
        
        
        
    }
}
