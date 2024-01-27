using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using AppConfig.ConfigDAAC;
using DAC.Core.Base;
using System.Threading.Tasks;
using System.Threading;
using IDAC.Core.IDataAccessObjects.General;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.Base;
using BDO.Core.DataAccessObjects.ExtendedEntities;

namespace DAC.Core.DataAccessObjects.General
{
	/// <summary>
    /// Un touched: From Generator
    /// KAF Information Center
    /// </summary>
	
	internal sealed partial class fileuserrelationDataAccessObjects : BaseDataAccess, IfileuserrelationDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "fileuserrelationDataAccessObjects";
        
		public fileuserrelationDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(fileuserrelationEntity fileuserrelation, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (fileuserrelation.serial.HasValue)
				Database.AddInParameter(cmd, "@Serial", DbType.Int64, fileuserrelation.serial);
            if (forDelete) return;
			if (fileuserrelation.fileid.HasValue)
				Database.AddInParameter(cmd, "@FileID", DbType.Int64, fileuserrelation.fileid);
			
				Database.AddInParameter(cmd, "@UserID", DbType.Guid, fileuserrelation.userid);

        }
		
        
		#region Add Operation

        async Task<long> IfileuserrelationDataAccessObjects.Add(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "fileuserrelation_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(fileuserrelation, cmd,Database);
                FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, Database);
				AddOutputParameter(cmd);
				try
                {
                    IAsyncResult result = Database.BeginExecuteNonQuery(cmd, null, null);
                    while (!result.IsCompleted)
                    {
                    }
                    returnCode = Database.EndExecuteNonQuery(result);
                    returnCode = (Int64)(cmd.Parameters["@RETURN_KEY"].Value);
                }
                catch (Exception ex)
                {
                    throw GetDataAccessException(ex, SourceOfException("IfileuserrelationDataAccess.Addfileuserrelation"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> IfileuserrelationDataAccessObjects.Update(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "fileuserrelation_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(fileuserrelation, cmd,Database);
                FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, Database);
				AddOutputParameter(cmd);
                try
                {
                  	IAsyncResult result = Database.BeginExecuteNonQuery(cmd, null, null);
                    while (!result.IsCompleted)
                    {
                    }
                    returnCode = Database.EndExecuteNonQuery(result);
                    returnCode = (Int64)(cmd.Parameters["@RETURN_KEY"].Value);
                }
                catch (Exception ex)
                {
                    throw GetDataAccessException(ex, SourceOfException("IfileuserrelationDataAccess.Updatefileuserrelation"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> IfileuserrelationDataAccessObjects.Delete(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "fileuserrelation_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(fileuserrelation, cmd,Database, true);
                FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, Database);
				AddOutputParameter(cmd);
				try
                {
                   	IAsyncResult result = Database.BeginExecuteNonQuery(cmd, null, null);
                    while (!result.IsCompleted)
                    {
                    }
                    returnCode = Database.EndExecuteNonQuery(result);
                    returnCode = (Int64)(cmd.Parameters["@RETURN_KEY"].Value);
                }
                catch (Exception ex)
                {
                   throw GetDataAccessException(ex, SourceOfException("IfileuserrelationDataAccess.Deletefileuserrelation"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> IfileuserrelationDataAccessObjects.SaveList(IList<fileuserrelationEntity> listAdded, IList<fileuserrelationEntity> listUpdated, IList<fileuserrelationEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "fileuserrelation_Ins";
            const string SPUpdate = "fileuserrelation_Upd";
            const string SPDelete = "fileuserrelation_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (fileuserrelationEntity fileuserrelation in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(fileuserrelation, cmd, Database, true);
                            FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, Database);
                            AddOutputParameter(cmd);
                            
                            IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                            while (!result.IsCompleted)
                            {
                            }
                            returnCode = Database.EndExecuteNonQuery(result);
                            if (returnCode < 0)
                            { 
                                throw new ArgumentException("Error in transaction.");
                            }
                            cmd.Dispose();
                        }
                    }
                }
                if (listUpdated.Count > 0 )
                {
                    foreach (fileuserrelationEntity fileuserrelation in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(fileuserrelation, cmd, Database);
                            FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, Database);
                            AddOutputParameter(cmd);
                            IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                            while (!result.IsCompleted)
                            {
                            }
                            returnCode = Database.EndExecuteNonQuery(result);
                            if (returnCode < 0)
                            {
                                 throw new ArgumentException("Error in transaction.");
                            }
                            cmd.Dispose();
                        }
                    }
                }
                if (listAdded.Count > 0 )
                {
                    foreach (fileuserrelationEntity fileuserrelation in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(fileuserrelation, cmd, Database);
                            FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, Database);
                            AddOutputParameter(cmd);
                            
                            IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                            while (!result.IsCompleted)
                            {
                            }
                            returnCode = Database.EndExecuteNonQuery(result);
                            if (returnCode < 0)
                            {
                                 throw new ArgumentException("Error in transaction.");
                            }
                            cmd.Dispose();
                        }
                    }
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw GetDataAccessException(ex, SourceOfException("IfileuserrelationDataAccess.Save_fileuserrelation"));
            }
            finally
            {
                transaction.Dispose();
                connection.Close();
                connection = null;
            }
            return returnCode;
        }
        
        
       public async Task<long> SaveList(
       Database db , 
       DbTransaction transaction,
       IList<fileuserrelationEntity> listAdded, 
       IList<fileuserrelationEntity> listUpdated, 
       IList<fileuserrelationEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "fileuserrelation_Ins";
            const string SPUpdate = "fileuserrelation_Upd";
            const string SPDelete = "fileuserrelation_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (fileuserrelationEntity fileuserrelation in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(fileuserrelation, cmd, db, true);
                            FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, db);
                            AddOutputParameter(cmd);
                            IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                            while (!result.IsCompleted)
                            {
                            }
                            returnCode = Database.EndExecuteNonQuery(result);
                            if (returnCode < 0)
                            { 
                                  throw new ArgumentException("Error in transaction.");
                            }
                            cmd.Dispose();
                        }
                    }
                }
                if (listUpdated.Count > 0 )
                {
                    foreach (fileuserrelationEntity fileuserrelation in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(fileuserrelation, cmd, db);
                            FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, db);
                            AddOutputParameter(cmd);
                            IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                            while (!result.IsCompleted)
                            {
                            }
                            returnCode = Database.EndExecuteNonQuery(result);
                            if (returnCode < 0)
                            {
                                 throw new ArgumentException("Error in transaction.");
                            }
                            cmd.Dispose();
                        }
                    }
                }
                if (listAdded.Count > 0 )
                {
                    foreach (fileuserrelationEntity fileuserrelation in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(fileuserrelation, cmd, db);
                            FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, db);
                            AddOutputParameter(cmd);
                            
                            IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                            while (!result.IsCompleted)
                            {
                            }
                            returnCode = Database.EndExecuteNonQuery(result);
                            if (returnCode < 0)
                            {
                                 throw new ArgumentException("Error in transaction.");
                            }
                            cmd.Dispose();
                        }
                    }
                }

              
            }
            catch (Exception ex)
            {
               
                throw GetDataAccessException(ex, SourceOfException("IfileuserrelationDataAccess.Save_fileuserrelation"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<fileuserrelationEntity>> IfileuserrelationDataAccessObjects.GetAll(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "fileuserrelation_GA";
                IList<fileuserrelationEntity> itemList = new List<fileuserrelationEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, fileuserrelation.SortExpression);
                    FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, Database);
                    FillParameters(fileuserrelation, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new fileuserrelationEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfileuserrelationDataAccess.GetAllfileuserrelation"));
            }	
        }
		
        async Task<IList<fileuserrelationEntity>> IfileuserrelationDataAccessObjects.GetAllByPages(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "fileuserrelation_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, fileuserrelation.SortExpression);
                    AddPageSizeParameter(cmd, fileuserrelation.PageSize);
                    AddCurrentPageParameter(cmd, fileuserrelation.CurrentPage);                    
                    FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, Database);
                    
					FillParameters(fileuserrelation, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (fileuserrelation.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+fileuserrelation.strCommonSerachParam+"%");

                    IList<fileuserrelationEntity> itemList = new List<fileuserrelationEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new fileuserrelationEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						fileuserrelation.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfileuserrelationDataAccess.GetAllByPagesfileuserrelation"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        #endregion
        
        
        #region Simple load Single Row
        async Task<fileuserrelationEntity> IfileuserrelationDataAccessObjects.GetSingle(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "fileuserrelation_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, Database);
                    FillParameters(fileuserrelation, cmd, Database);
                    
                    IList<fileuserrelationEntity> itemList = new List<fileuserrelationEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new fileuserrelationEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    
                    if(itemList != null && itemList.Count > 0)
                        return itemList[0];
                    else
                        return null;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfileuserrelationDataAccess.GetSinglefileuserrelation"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<fileuserrelationEntity>> IfileuserrelationDataAccessObjects.GAPgListView(fileuserrelationEntity fileuserrelation, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "fileuserrelation_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, fileuserrelation.SortExpression);
                    AddPageSizeParameter(cmd, fileuserrelation.PageSize);
                    AddCurrentPageParameter(cmd, fileuserrelation.CurrentPage);                    
                    FillSequrityParameters(fileuserrelation.BaseSecurityParam, cmd, Database);
                    
					FillParameters(fileuserrelation, cmd,Database);
                    
					if (!string.IsNullOrEmpty (fileuserrelation.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+fileuserrelation.strCommonSerachParam+"%");

                    IList<fileuserrelationEntity> itemList = new List<fileuserrelationEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new fileuserrelationEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						fileuserrelation.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfileuserrelationDataAccess.GAPgListViewfileuserrelation"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
            
	}
}