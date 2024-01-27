

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "IfolderuserrelationFacadeObjects")]
    public partial interface IfolderuserrelationFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<folderuserrelationEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<folderuserrelationEntity>> GetAll(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<folderuserrelationEntity>> GetAllByPages(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<folderuserrelationEntity> GetSingle(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<folderuserrelationEntity>> GAPgListView(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
