using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface IfiletransferinfoDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
		
        Task<long> Update(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
        
        Task<long> Delete(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<filetransferinfoEntity> listAdded, IList<filetransferinfoEntity> listUpdated, IList<filetransferinfoEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<filetransferinfoEntity>> GetAll(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
		
        Task<IList<filetransferinfoEntity>> GetAllByPages(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<filetransferinfoEntity> GetSingle(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<filetransferinfoEntity>> GAPgListView(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
        #endregion

        #region Extras Reviewed, Published, Archived
        #endregion


        Task<long> AddExt(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);




    }
}
