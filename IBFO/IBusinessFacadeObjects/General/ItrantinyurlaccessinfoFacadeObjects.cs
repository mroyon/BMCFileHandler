

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "ItrantinyurlaccessinfoFacadeObjects")]
    public partial interface ItrantinyurlaccessinfoFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<trantinyurlaccessinfoEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<trantinyurlaccessinfoEntity>> GetAll(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<trantinyurlaccessinfoEntity>> GetAllByPages(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<trantinyurlaccessinfoEntity> GetSingle(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<trantinyurlaccessinfoEntity>> GAPgListView(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
