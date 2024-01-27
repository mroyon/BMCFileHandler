using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface IfilestructurehistDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
		
        Task<long> Update(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
        
        Task<long> Delete(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<filestructurehistEntity> listAdded, IList<filestructurehistEntity> listUpdated, IList<filestructurehistEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<filestructurehistEntity>> GetAll(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
		
        Task<IList<filestructurehistEntity>> GetAllByPages(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<filestructurehistEntity> GetSingle(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<filestructurehistEntity>> GAPgListView(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
               
        
        
        
        
    }
}
