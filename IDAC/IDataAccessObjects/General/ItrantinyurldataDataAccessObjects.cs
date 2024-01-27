using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface ItrantinyurldataDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
		
        Task<long> Update(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
        
        Task<long> Delete(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<trantinyurldataEntity> listAdded, IList<trantinyurldataEntity> listUpdated, IList<trantinyurldataEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<trantinyurldataEntity>> GetAll(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
		
        Task<IList<trantinyurldataEntity>> GetAllByPages(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        Task<long> SaveMasterDettrantinyurlaccessinfo(trantinyurldataEntity masterEntity, IList<trantinyurlaccessinfoEntity> listAdded, IList<trantinyurlaccessinfoEntity> listUpdated, IList<trantinyurlaccessinfoEntity> listDeleted, CancellationToken cancellationToken);

        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<trantinyurldataEntity> GetSingle(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<trantinyurldataEntity>> GAPgListView(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
               
        
        
        
        
    }
}
