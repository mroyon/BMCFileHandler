using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface IfolderstructureDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(folderstructureEntity folderstructure, CancellationToken cancellationToken);
		
        Task<long> Update(folderstructureEntity folderstructure, CancellationToken cancellationToken);
        
        Task<long> Delete(folderstructureEntity folderstructure, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<folderstructureEntity> listAdded, IList<folderstructureEntity> listUpdated, IList<folderstructureEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<folderstructureEntity>> GetAll(folderstructureEntity folderstructure, CancellationToken cancellationToken);
		
        Task<IList<folderstructureEntity>> GetAllByPages(folderstructureEntity folderstructure, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        Task<long> SaveMasterDetfilestructure(folderstructureEntity masterEntity, IList<filestructureEntity> listAdded, IList<filestructureEntity> listUpdated, IList<filestructureEntity> listDeleted, CancellationToken cancellationToken);

        Task<long> SaveMasterDetfolderuserrelation(folderstructureEntity masterEntity, IList<folderuserrelationEntity> listAdded, IList<folderuserrelationEntity> listUpdated, IList<folderuserrelationEntity> listDeleted, CancellationToken cancellationToken);

        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<folderstructureEntity> GetSingle(folderstructureEntity folderstructure, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<folderstructureEntity>> GAPgListView(folderstructureEntity folderstructure, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
               
        
        
        
        
    }
}
