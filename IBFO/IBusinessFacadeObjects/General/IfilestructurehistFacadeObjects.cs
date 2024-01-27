

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "IfilestructurehistFacadeObjects")]
    public partial interface IfilestructurehistFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(filestructurehistEntity filestructurehist, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<filestructurehistEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<filestructurehistEntity>> GetAll(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<filestructurehistEntity>> GetAllByPages(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<filestructurehistEntity> GetSingle(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<filestructurehistEntity>> GAPgListView(filestructurehistEntity filestructurehist, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
