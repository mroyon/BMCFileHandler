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
	
	internal sealed partial class folderstructurehistDataAccessObjects : BaseDataAccess, IfolderstructurehistDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "folderstructurehistDataAccessObjects";
        
		public folderstructurehistDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(folderstructurehistEntity folderstructurehist, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (folderstructurehist.folderhistid.HasValue)
				Database.AddInParameter(cmd, "@FolderHistID", DbType.Int64, folderstructurehist.folderhistid);
            if (forDelete) return;
			if (folderstructurehist.folderid.HasValue)
				Database.AddInParameter(cmd, "@FolderID", DbType.Int64, folderstructurehist.folderid);
			if (!(string.IsNullOrEmpty(folderstructurehist.foldername)))
				Database.AddInParameter(cmd, "@FolderName", DbType.String, folderstructurehist.foldername);
			if (!(string.IsNullOrEmpty(folderstructurehist.physicalpath)))
				Database.AddInParameter(cmd, "@PhysicalPath", DbType.String, folderstructurehist.physicalpath);
			if (folderstructurehist.parentfolderid.HasValue)
				Database.AddInParameter(cmd, "@ParentFolderID", DbType.Int64, folderstructurehist.parentfolderid);
			if ((folderstructurehist.isdeleted != null))
				Database.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, folderstructurehist.isdeleted);
			if (!(string.IsNullOrEmpty(folderstructurehist.deletedbyuser)))
				Database.AddInParameter(cmd, "@DeletedByUser", DbType.String, folderstructurehist.deletedbyuser);
			if ((folderstructurehist.deleteddate.HasValue))
				Database.AddInParameter(cmd, "@DeletedDate", DbType.DateTime, folderstructurehist.deleteddate);

        }
		
        
		#region Add Operation

        async Task<long> IfolderstructurehistDataAccessObjects.Add(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "folderstructurehist_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(folderstructurehist, cmd,Database);
                FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfolderstructurehistDataAccess.Addfolderstructurehist"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> IfolderstructurehistDataAccessObjects.Update(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "folderstructurehist_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(folderstructurehist, cmd,Database);
                FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfolderstructurehistDataAccess.Updatefolderstructurehist"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> IfolderstructurehistDataAccessObjects.Delete(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "folderstructurehist_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(folderstructurehist, cmd,Database, true);
                FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, Database);
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
                   throw GetDataAccessException(ex, SourceOfException("IfolderstructurehistDataAccess.Deletefolderstructurehist"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> IfolderstructurehistDataAccessObjects.SaveList(IList<folderstructurehistEntity> listAdded, IList<folderstructurehistEntity> listUpdated, IList<folderstructurehistEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "folderstructurehist_Ins";
            const string SPUpdate = "folderstructurehist_Upd";
            const string SPDelete = "folderstructurehist_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (folderstructurehistEntity folderstructurehist in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(folderstructurehist, cmd, Database, true);
                            FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, Database);
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
                    foreach (folderstructurehistEntity folderstructurehist in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(folderstructurehist, cmd, Database);
                            FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, Database);
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
                    foreach (folderstructurehistEntity folderstructurehist in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(folderstructurehist, cmd, Database);
                            FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, Database);
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
                throw GetDataAccessException(ex, SourceOfException("IfolderstructurehistDataAccess.Save_folderstructurehist"));
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
       IList<folderstructurehistEntity> listAdded, 
       IList<folderstructurehistEntity> listUpdated, 
       IList<folderstructurehistEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "folderstructurehist_Ins";
            const string SPUpdate = "folderstructurehist_Upd";
            const string SPDelete = "folderstructurehist_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (folderstructurehistEntity folderstructurehist in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(folderstructurehist, cmd, db, true);
                            FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, db);
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
                    foreach (folderstructurehistEntity folderstructurehist in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(folderstructurehist, cmd, db);
                            FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, db);
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
                    foreach (folderstructurehistEntity folderstructurehist in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(folderstructurehist, cmd, db);
                            FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, db);
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
               
                throw GetDataAccessException(ex, SourceOfException("IfolderstructurehistDataAccess.Save_folderstructurehist"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<folderstructurehistEntity>> IfolderstructurehistDataAccessObjects.GetAll(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "folderstructurehist_GA";
                IList<folderstructurehistEntity> itemList = new List<folderstructurehistEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, folderstructurehist.SortExpression);
                    FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, Database);
                    FillParameters(folderstructurehist, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new folderstructurehistEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfolderstructurehistDataAccess.GetAllfolderstructurehist"));
            }	
        }
		
        async Task<IList<folderstructurehistEntity>> IfolderstructurehistDataAccessObjects.GetAllByPages(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "folderstructurehist_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, folderstructurehist.SortExpression);
                    AddPageSizeParameter(cmd, folderstructurehist.PageSize);
                    AddCurrentPageParameter(cmd, folderstructurehist.CurrentPage);                    
                    FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, Database);
                    
					FillParameters(folderstructurehist, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (folderstructurehist.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+folderstructurehist.strCommonSerachParam+"%");

                    IList<folderstructurehistEntity> itemList = new List<folderstructurehistEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new folderstructurehistEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						folderstructurehist.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfolderstructurehistDataAccess.GetAllByPagesfolderstructurehist"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        #endregion
        
        
        #region Simple load Single Row
        async Task<folderstructurehistEntity> IfolderstructurehistDataAccessObjects.GetSingle(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "folderstructurehist_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, Database);
                    FillParameters(folderstructurehist, cmd, Database);
                    
                    IList<folderstructurehistEntity> itemList = new List<folderstructurehistEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new folderstructurehistEntity(reader));
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
                throw GetDataAccessException(ex, SourceOfException("IfolderstructurehistDataAccess.GetSinglefolderstructurehist"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<folderstructurehistEntity>> IfolderstructurehistDataAccessObjects.GAPgListView(folderstructurehistEntity folderstructurehist, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "folderstructurehist_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, folderstructurehist.SortExpression);
                    AddPageSizeParameter(cmd, folderstructurehist.PageSize);
                    AddCurrentPageParameter(cmd, folderstructurehist.CurrentPage);                    
                    FillSequrityParameters(folderstructurehist.BaseSecurityParam, cmd, Database);
                    
					FillParameters(folderstructurehist, cmd,Database);
                    
					if (!string.IsNullOrEmpty (folderstructurehist.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+folderstructurehist.strCommonSerachParam+"%");

                    IList<folderstructurehistEntity> itemList = new List<folderstructurehistEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new folderstructurehistEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						folderstructurehist.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfolderstructurehistDataAccess.GAPgListViewfolderstructurehist"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
            
	}
}