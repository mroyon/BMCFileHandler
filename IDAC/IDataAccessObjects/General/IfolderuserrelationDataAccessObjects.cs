using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface IfolderuserrelationDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
		
        Task<long> Update(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
        
        Task<long> Delete(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<folderuserrelationEntity> listAdded, IList<folderuserrelationEntity> listUpdated, IList<folderuserrelationEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<folderuserrelationEntity>> GetAll(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
		
        Task<IList<folderuserrelationEntity>> GetAllByPages(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<folderuserrelationEntity> GetSingle(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<folderuserrelationEntity>> GAPgListView(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
               
        
        
        
        
    }
}
