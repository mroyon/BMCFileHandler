

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "IfolderstructurehistFacadeObjects")]
    public partial interface IfolderstructurehistFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<folderstructurehistEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<folderstructurehistEntity>> GetAll(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<folderstructurehistEntity>> GetAllByPages(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<folderstructurehistEntity> GetSingle(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<folderstructurehistEntity>> GAPgListView(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
