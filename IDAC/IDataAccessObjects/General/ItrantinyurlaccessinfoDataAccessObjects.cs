using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface ItrantinyurlaccessinfoDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
		
        Task<long> Update(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
        
        Task<long> Delete(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<trantinyurlaccessinfoEntity> listAdded, IList<trantinyurlaccessinfoEntity> listUpdated, IList<trantinyurlaccessinfoEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<trantinyurlaccessinfoEntity>> GetAll(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
		
        Task<IList<trantinyurlaccessinfoEntity>> GetAllByPages(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<trantinyurlaccessinfoEntity> GetSingle(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<trantinyurlaccessinfoEntity>> GAPgListView(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
               
        
        
        
        
    }
}
