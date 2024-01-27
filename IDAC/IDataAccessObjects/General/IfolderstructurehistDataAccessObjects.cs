using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface IfolderstructurehistDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
		
        Task<long> Update(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
        
        Task<long> Delete(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<folderstructurehistEntity> listAdded, IList<folderstructurehistEntity> listUpdated, IList<folderstructurehistEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<folderstructurehistEntity>> GetAll(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
		
        Task<IList<folderstructurehistEntity>> GetAllByPages(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<folderstructurehistEntity> GetSingle(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<folderstructurehistEntity>> GAPgListView(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
               
        
        
        
        
    }
}
