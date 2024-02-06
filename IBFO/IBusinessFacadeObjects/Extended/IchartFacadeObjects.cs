

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "IchartFacadeObjects")]
    public partial interface IchartFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(chartEntity chart, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(chartEntity chart, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(chartEntity chart, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<chartEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<chartEntity>> GetAll(chartEntity chart, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<chartEntity>> GetAllByPages(chartEntity chart, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<chartEntity> GetSingle(chartEntity chart, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<chartEntity>> GAPgListView(chartEntity chart, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
