

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "ItrantinyurldataFacadeObjects")]
    public partial interface ItrantinyurldataFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<trantinyurldataEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<trantinyurldataEntity>> GetAll(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<trantinyurldataEntity>> GetAllByPages(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        [OperationContract]
        Task<long> SaveMasterDettrantinyurlaccessinfo(trantinyurldataEntity Master, List<trantinyurlaccessinfoEntity> DetailList, CancellationToken cancellationToken);

        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<trantinyurldataEntity> GetSingle(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<trantinyurldataEntity>> GAPgListView(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
