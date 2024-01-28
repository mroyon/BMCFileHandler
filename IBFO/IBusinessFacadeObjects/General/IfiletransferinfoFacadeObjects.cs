

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "IfiletransferinfoFacadeObjects")]
    public partial interface IfiletransferinfoFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<filetransferinfoEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<filetransferinfoEntity>> GetAll(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<filetransferinfoEntity>> GetAllByPages(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<filetransferinfoEntity> GetSingle(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<filetransferinfoEntity>> GAPgListView(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
