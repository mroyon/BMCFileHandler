

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "IfolderstructureFacadeObjects")]
    public partial interface IfolderstructureFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(folderstructureEntity folderstructure, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(folderstructureEntity folderstructure, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(folderstructureEntity folderstructure, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<folderstructureEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<folderstructureEntity>> GetAll(folderstructureEntity folderstructure, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<folderstructureEntity>> GetAllByPages(folderstructureEntity folderstructure, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        [OperationContract]
        Task<long> SaveMasterDetfilestructure(folderstructureEntity Master, List<filestructureEntity> DetailList, CancellationToken cancellationToken);

        [OperationContract]
        Task<long> SaveMasterDetfolderuserrelation(folderstructureEntity Master, List<folderuserrelationEntity> DetailList, CancellationToken cancellationToken);

        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<folderstructureEntity> GetSingle(folderstructureEntity folderstructure, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<folderstructureEntity>> GAPgListView(folderstructureEntity folderstructure, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
