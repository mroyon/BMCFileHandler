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
	
	internal sealed partial class folderuserrelationDataAccessObjects : BaseDataAccess, IfolderuserrelationDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "folderuserrelationDataAccessObjects";
        
		public folderuserrelationDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(folderuserrelationEntity folderuserrelation, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (folderuserrelation.serial.HasValue)
				Database.AddInParameter(cmd, "@Serial", DbType.Int64, folderuserrelation.serial);
            if (forDelete) return;
			if (folderuserrelation.folderid.HasValue)
				Database.AddInParameter(cmd, "@FolderID", DbType.Int64, folderuserrelation.folderid);
			
				Database.AddInParameter(cmd, "@UserID", DbType.Guid, folderuserrelation.userid);

        }
		
        
		#region Add Operation

        async Task<long> IfolderuserrelationDataAccessObjects.Add(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "folderuserrelation_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(folderuserrelation, cmd,Database);
                FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfolderuserrelationDataAccess.Addfolderuserrelation"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> IfolderuserrelationDataAccessObjects.Update(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "folderuserrelation_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(folderuserrelation, cmd,Database);
                FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfolderuserrelationDataAccess.Updatefolderuserrelation"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> IfolderuserrelationDataAccessObjects.Delete(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "folderuserrelation_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(folderuserrelation, cmd,Database, true);
                FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, Database);
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
                   throw GetDataAccessException(ex, SourceOfException("IfolderuserrelationDataAccess.Deletefolderuserrelation"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> IfolderuserrelationDataAccessObjects.SaveList(IList<folderuserrelationEntity> listAdded, IList<folderuserrelationEntity> listUpdated, IList<folderuserrelationEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "folderuserrelation_Ins";
            const string SPUpdate = "folderuserrelation_Upd";
            const string SPDelete = "folderuserrelation_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (folderuserrelationEntity folderuserrelation in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(folderuserrelation, cmd, Database, true);
                            FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, Database);
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
                    foreach (folderuserrelationEntity folderuserrelation in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(folderuserrelation, cmd, Database);
                            FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, Database);
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
                    foreach (folderuserrelationEntity folderuserrelation in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(folderuserrelation, cmd, Database);
                            FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, Database);
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
                throw GetDataAccessException(ex, SourceOfException("IfolderuserrelationDataAccess.Save_folderuserrelation"));
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
       IList<folderuserrelationEntity> listAdded, 
       IList<folderuserrelationEntity> listUpdated, 
       IList<folderuserrelationEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "folderuserrelation_Ins";
            const string SPUpdate = "folderuserrelation_Upd";
            const string SPDelete = "folderuserrelation_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (folderuserrelationEntity folderuserrelation in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(folderuserrelation, cmd, db, true);
                            FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, db);
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
                    foreach (folderuserrelationEntity folderuserrelation in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(folderuserrelation, cmd, db);
                            FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, db);
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
                    foreach (folderuserrelationEntity folderuserrelation in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(folderuserrelation, cmd, db);
                            FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, db);
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
               
                throw GetDataAccessException(ex, SourceOfException("IfolderuserrelationDataAccess.Save_folderuserrelation"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<folderuserrelationEntity>> IfolderuserrelationDataAccessObjects.GetAll(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "folderuserrelation_GA";
                IList<folderuserrelationEntity> itemList = new List<folderuserrelationEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, folderuserrelation.SortExpression);
                    FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, Database);
                    FillParameters(folderuserrelation, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new folderuserrelationEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfolderuserrelationDataAccess.GetAllfolderuserrelation"));
            }	
        }
		
        async Task<IList<folderuserrelationEntity>> IfolderuserrelationDataAccessObjects.GetAllByPages(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "folderuserrelation_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, folderuserrelation.SortExpression);
                    AddPageSizeParameter(cmd, folderuserrelation.PageSize);
                    AddCurrentPageParameter(cmd, folderuserrelation.CurrentPage);                    
                    FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, Database);
                    
					FillParameters(folderuserrelation, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (folderuserrelation.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+folderuserrelation.strCommonSerachParam+"%");

                    IList<folderuserrelationEntity> itemList = new List<folderuserrelationEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new folderuserrelationEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						folderuserrelation.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfolderuserrelationDataAccess.GetAllByPagesfolderuserrelation"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        #endregion
        
        
        #region Simple load Single Row
        async Task<folderuserrelationEntity> IfolderuserrelationDataAccessObjects.GetSingle(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "folderuserrelation_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, Database);
                    FillParameters(folderuserrelation, cmd, Database);
                    
                    IList<folderuserrelationEntity> itemList = new List<folderuserrelationEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new folderuserrelationEntity(reader));
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
                throw GetDataAccessException(ex, SourceOfException("IfolderuserrelationDataAccess.GetSinglefolderuserrelation"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<folderuserrelationEntity>> IfolderuserrelationDataAccessObjects.GAPgListView(folderuserrelationEntity folderuserrelation, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "folderuserrelation_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, folderuserrelation.SortExpression);
                    AddPageSizeParameter(cmd, folderuserrelation.PageSize);
                    AddCurrentPageParameter(cmd, folderuserrelation.CurrentPage);                    
                    FillSequrityParameters(folderuserrelation.BaseSecurityParam, cmd, Database);
                    
					FillParameters(folderuserrelation, cmd,Database);
                    
					if (!string.IsNullOrEmpty (folderuserrelation.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+folderuserrelation.strCommonSerachParam+"%");

                    IList<folderuserrelationEntity> itemList = new List<folderuserrelationEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new folderuserrelationEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						folderuserrelation.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfolderuserrelationDataAccess.GAPgListViewfolderuserrelation"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
            
	}
}