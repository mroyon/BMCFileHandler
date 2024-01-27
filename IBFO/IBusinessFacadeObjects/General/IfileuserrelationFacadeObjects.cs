

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "IfileuserrelationFacadeObjects")]
    public partial interface IfileuserrelationFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<fileuserrelationEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<fileuserrelationEntity>> GetAll(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<fileuserrelationEntity>> GetAllByPages(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<fileuserrelationEntity> GetSingle(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<fileuserrelationEntity>> GAPgListView(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
