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
	
	internal sealed partial class filestructurehistDataAccessObjects : BaseDataAccess, IfilestructurehistDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "filestructurehistDataAccessObjects";
        
		public filestructurehistDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(filestructurehistEntity filestructurehist, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (filestructurehist.filehistid.HasValue)
				Database.AddInParameter(cmd, "@FileHistID", DbType.Int64, filestructurehist.filehistid);
            if (forDelete) return;
			if (filestructurehist.fileid.HasValue)
				Database.AddInParameter(cmd, "@FileID", DbType.Int64, filestructurehist.fileid);
			if (filestructurehist.folderid.HasValue)
				Database.AddInParameter(cmd, "@FolderID", DbType.Int64, filestructurehist.folderid);
			if (!(string.IsNullOrEmpty(filestructurehist.filename)))
				Database.AddInParameter(cmd, "@FileName", DbType.String, filestructurehist.filename);
			if (!(string.IsNullOrEmpty(filestructurehist.userfilename)))
				Database.AddInParameter(cmd, "@UserFileName", DbType.String, filestructurehist.userfilename);
			if (!(string.IsNullOrEmpty(filestructurehist.filepath)))
				Database.AddInParameter(cmd, "@FilePath", DbType.String, filestructurehist.filepath);
			if ((filestructurehist.isdeleted != null))
				Database.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, filestructurehist.isdeleted);
			if (!(string.IsNullOrEmpty(filestructurehist.deletedbyuser)))
				Database.AddInParameter(cmd, "@DeletedByUser", DbType.String, filestructurehist.deletedbyuser);
			if ((filestructurehist.deleteddate.HasValue))
				Database.AddInParameter(cmd, "@DeletedDate", DbType.DateTime, filestructurehist.deleteddate);

        }
		
        
		#region Add Operation

        async Task<long> IfilestructurehistDataAccessObjects.Add(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "filestructurehist_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(filestructurehist, cmd,Database);
                FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfilestructurehistDataAccess.Addfilestructurehist"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> IfilestructurehistDataAccessObjects.Update(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "filestructurehist_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(filestructurehist, cmd,Database);
                FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfilestructurehistDataAccess.Updatefilestructurehist"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> IfilestructurehistDataAccessObjects.Delete(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "filestructurehist_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(filestructurehist, cmd,Database, true);
                FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, Database);
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
                   throw GetDataAccessException(ex, SourceOfException("IfilestructurehistDataAccess.Deletefilestructurehist"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> IfilestructurehistDataAccessObjects.SaveList(IList<filestructurehistEntity> listAdded, IList<filestructurehistEntity> listUpdated, IList<filestructurehistEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "filestructurehist_Ins";
            const string SPUpdate = "filestructurehist_Upd";
            const string SPDelete = "filestructurehist_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (filestructurehistEntity filestructurehist in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(filestructurehist, cmd, Database, true);
                            FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, Database);
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
                    foreach (filestructurehistEntity filestructurehist in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(filestructurehist, cmd, Database);
                            FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, Database);
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
                    foreach (filestructurehistEntity filestructurehist in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(filestructurehist, cmd, Database);
                            FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, Database);
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
                throw GetDataAccessException(ex, SourceOfException("IfilestructurehistDataAccess.Save_filestructurehist"));
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
       IList<filestructurehistEntity> listAdded, 
       IList<filestructurehistEntity> listUpdated, 
       IList<filestructurehistEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "filestructurehist_Ins";
            const string SPUpdate = "filestructurehist_Upd";
            const string SPDelete = "filestructurehist_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (filestructurehistEntity filestructurehist in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(filestructurehist, cmd, db, true);
                            FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, db);
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
                    foreach (filestructurehistEntity filestructurehist in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(filestructurehist, cmd, db);
                            FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, db);
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
                    foreach (filestructurehistEntity filestructurehist in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(filestructurehist, cmd, db);
                            FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, db);
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
               
                throw GetDataAccessException(ex, SourceOfException("IfilestructurehistDataAccess.Save_filestructurehist"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<filestructurehistEntity>> IfilestructurehistDataAccessObjects.GetAll(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "filestructurehist_GA";
                IList<filestructurehistEntity> itemList = new List<filestructurehistEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, filestructurehist.SortExpression);
                    FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, Database);
                    FillParameters(filestructurehist, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new filestructurehistEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfilestructurehistDataAccess.GetAllfilestructurehist"));
            }	
        }
		
        async Task<IList<filestructurehistEntity>> IfilestructurehistDataAccessObjects.GetAllByPages(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "filestructurehist_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, filestructurehist.SortExpression);
                    AddPageSizeParameter(cmd, filestructurehist.PageSize);
                    AddCurrentPageParameter(cmd, filestructurehist.CurrentPage);                    
                    FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, Database);
                    
					FillParameters(filestructurehist, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (filestructurehist.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+filestructurehist.strCommonSerachParam+"%");

                    IList<filestructurehistEntity> itemList = new List<filestructurehistEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new filestructurehistEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						filestructurehist.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfilestructurehistDataAccess.GetAllByPagesfilestructurehist"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        #endregion
        
        
        #region Simple load Single Row
        async Task<filestructurehistEntity> IfilestructurehistDataAccessObjects.GetSingle(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "filestructurehist_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, Database);
                    FillParameters(filestructurehist, cmd, Database);
                    
                    IList<filestructurehistEntity> itemList = new List<filestructurehistEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new filestructurehistEntity(reader));
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
                throw GetDataAccessException(ex, SourceOfException("IfilestructurehistDataAccess.GetSinglefilestructurehist"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<filestructurehistEntity>> IfilestructurehistDataAccessObjects.GAPgListView(filestructurehistEntity filestructurehist, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "filestructurehist_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, filestructurehist.SortExpression);
                    AddPageSizeParameter(cmd, filestructurehist.PageSize);
                    AddCurrentPageParameter(cmd, filestructurehist.CurrentPage);                    
                    FillSequrityParameters(filestructurehist.BaseSecurityParam, cmd, Database);
                    
					FillParameters(filestructurehist, cmd,Database);
                    
					if (!string.IsNullOrEmpty (filestructurehist.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+filestructurehist.strCommonSerachParam+"%");

                    IList<filestructurehistEntity> itemList = new List<filestructurehistEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new filestructurehistEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						filestructurehist.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfilestructurehistDataAccess.GAPgListViewfilestructurehist"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
            
	}
}