using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface IfilestructureDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(filestructureEntity filestructure, CancellationToken cancellationToken);
		
        Task<long> Update(filestructureEntity filestructure, CancellationToken cancellationToken);
        
        Task<long> Delete(filestructureEntity filestructure, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<filestructureEntity> listAdded, IList<filestructureEntity> listUpdated, IList<filestructureEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<filestructureEntity>> GetAll(filestructureEntity filestructure, CancellationToken cancellationToken);
		
        Task<IList<filestructureEntity>> GetAllByPages(filestructureEntity filestructure, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        Task<long> SaveMasterDetfileuserrelation(filestructureEntity masterEntity, IList<fileuserrelationEntity> listAdded, IList<fileuserrelationEntity> listUpdated, IList<fileuserrelationEntity> listDeleted, CancellationToken cancellationToken);

        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<filestructureEntity> GetSingle(filestructureEntity filestructure, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<filestructureEntity>> GAPgListView(filestructureEntity filestructure, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
               
        
        
        
        
    }
}
