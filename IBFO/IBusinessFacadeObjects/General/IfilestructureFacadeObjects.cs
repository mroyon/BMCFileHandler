

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "IfilestructureFacadeObjects")]
    public partial interface IfilestructureFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(filestructureEntity filestructure, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(filestructureEntity filestructure, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(filestructureEntity filestructure, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<filestructureEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<filestructureEntity>> GetAll(filestructureEntity filestructure, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<filestructureEntity>> GetAllByPages(filestructureEntity filestructure, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        [OperationContract]
        Task<long> SaveMasterDetfileuserrelation(filestructureEntity Master, List<fileuserrelationEntity> DetailList, CancellationToken cancellationToken);

        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<filestructureEntity> GetSingle(filestructureEntity filestructure, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<filestructureEntity>> GAPgListView(filestructureEntity filestructure, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
