

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "Ikaf_hr_militarysvcinfoFacadeObjects")]
    public partial interface Ikaf_hr_militarysvcinfoFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(kaf_hr_militarysvcinfoEntity kaf_hr_militarysvcinfo, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(kaf_hr_militarysvcinfoEntity kaf_hr_militarysvcinfo, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(kaf_hr_militarysvcinfoEntity kaf_hr_militarysvcinfo, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<kaf_hr_militarysvcinfoEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<kaf_hr_militarysvcinfoEntity>> GetAll(kaf_hr_militarysvcinfoEntity kaf_hr_militarysvcinfo, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<kaf_hr_militarysvcinfoEntity>> GetAllByPages(kaf_hr_militarysvcinfoEntity kaf_hr_militarysvcinfo, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<kaf_hr_militarysvcinfoEntity> GetSingle(kaf_hr_militarysvcinfoEntity kaf_hr_militarysvcinfo, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<kaf_hr_militarysvcinfoEntity>> GAPgListView(kaf_hr_militarysvcinfoEntity kaf_hr_militarysvcinfo, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
