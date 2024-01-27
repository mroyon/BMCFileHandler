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
	
	internal sealed partial class filestructureDataAccessObjects : BaseDataAccess, IfilestructureDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "filestructureDataAccessObjects";
        
		public filestructureDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(filestructureEntity filestructure, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (filestructure.fileid.HasValue)
				Database.AddInParameter(cmd, "@FileID", DbType.Int64, filestructure.fileid);
            if (forDelete) return;
			if (filestructure.folderid.HasValue)
				Database.AddInParameter(cmd, "@FolderID", DbType.Int64, filestructure.folderid);
			if (!(string.IsNullOrEmpty(filestructure.filename)))
				Database.AddInParameter(cmd, "@FileName", DbType.String, filestructure.filename);
			if (!(string.IsNullOrEmpty(filestructure.userfilename)))
				Database.AddInParameter(cmd, "@UserFileName", DbType.String, filestructure.userfilename);
			if (!(string.IsNullOrEmpty(filestructure.filepath)))
				Database.AddInParameter(cmd, "@FilePath", DbType.String, filestructure.filepath);
			if ((filestructure.isdeleted != null))
				Database.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, filestructure.isdeleted);
			if (!(string.IsNullOrEmpty(filestructure.deletedbyuser)))
				Database.AddInParameter(cmd, "@DeletedByUser", DbType.String, filestructure.deletedbyuser);
			if ((filestructure.deleteddate.HasValue))
				Database.AddInParameter(cmd, "@DeletedDate", DbType.DateTime, filestructure.deleteddate);

        }
		
        
		#region Add Operation

        async Task<long> IfilestructureDataAccessObjects.Add(filestructureEntity filestructure, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "filestructure_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(filestructure, cmd,Database);
                FillSequrityParameters(filestructure.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfilestructureDataAccess.Addfilestructure"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> IfilestructureDataAccessObjects.Update(filestructureEntity filestructure, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "filestructure_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(filestructure, cmd,Database);
                FillSequrityParameters(filestructure.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfilestructureDataAccess.Updatefilestructure"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> IfilestructureDataAccessObjects.Delete(filestructureEntity filestructure, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "filestructure_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(filestructure, cmd,Database, true);
                FillSequrityParameters(filestructure.BaseSecurityParam, cmd, Database);
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
                   throw GetDataAccessException(ex, SourceOfException("IfilestructureDataAccess.Deletefilestructure"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> IfilestructureDataAccessObjects.SaveList(IList<filestructureEntity> listAdded, IList<filestructureEntity> listUpdated, IList<filestructureEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "filestructure_Ins";
            const string SPUpdate = "filestructure_Upd";
            const string SPDelete = "filestructure_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (filestructureEntity filestructure in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(filestructure, cmd, Database, true);
                            FillSequrityParameters(filestructure.BaseSecurityParam, cmd, Database);
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
                    foreach (filestructureEntity filestructure in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(filestructure, cmd, Database);
                            FillSequrityParameters(filestructure.BaseSecurityParam, cmd, Database);
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
                    foreach (filestructureEntity filestructure in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(filestructure, cmd, Database);
                            FillSequrityParameters(filestructure.BaseSecurityParam, cmd, Database);
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
                throw GetDataAccessException(ex, SourceOfException("IfilestructureDataAccess.Save_filestructure"));
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
       IList<filestructureEntity> listAdded, 
       IList<filestructureEntity> listUpdated, 
       IList<filestructureEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "filestructure_Ins";
            const string SPUpdate = "filestructure_Upd";
            const string SPDelete = "filestructure_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (filestructureEntity filestructure in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(filestructure, cmd, db, true);
                            FillSequrityParameters(filestructure.BaseSecurityParam, cmd, db);
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
                    foreach (filestructureEntity filestructure in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(filestructure, cmd, db);
                            FillSequrityParameters(filestructure.BaseSecurityParam, cmd, db);
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
                    foreach (filestructureEntity filestructure in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(filestructure, cmd, db);
                            FillSequrityParameters(filestructure.BaseSecurityParam, cmd, db);
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
               
                throw GetDataAccessException(ex, SourceOfException("IfilestructureDataAccess.Save_filestructure"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<filestructureEntity>> IfilestructureDataAccessObjects.GetAll(filestructureEntity filestructure, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "filestructure_GA";
                IList<filestructureEntity> itemList = new List<filestructureEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, filestructure.SortExpression);
                    FillSequrityParameters(filestructure.BaseSecurityParam, cmd, Database);
                    FillParameters(filestructure, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new filestructureEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfilestructureDataAccess.GetAllfilestructure"));
            }	
        }
		
        async Task<IList<filestructureEntity>> IfilestructureDataAccessObjects.GetAllByPages(filestructureEntity filestructure, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "filestructure_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, filestructure.SortExpression);
                    AddPageSizeParameter(cmd, filestructure.PageSize);
                    AddCurrentPageParameter(cmd, filestructure.CurrentPage);                    
                    FillSequrityParameters(filestructure.BaseSecurityParam, cmd, Database);
                    
					FillParameters(filestructure, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (filestructure.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+filestructure.strCommonSerachParam+"%");

                    IList<filestructureEntity> itemList = new List<filestructureEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new filestructureEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						filestructure.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfilestructureDataAccess.GetAllByPagesfilestructure"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        
        async Task<long> IfilestructureDataAccessObjects.SaveMasterDetfileuserrelation(filestructureEntity masterEntity, 
        IList<fileuserrelationEntity> listAdded, 
        IList<fileuserrelationEntity> listUpdated,
        IList<fileuserrelationEntity> listDeleted, 
        CancellationToken cancellationToken)
        {
			long returnCode = -99;
                Int64 PrimaryKeyMaster = -99;
            
            string SP = "";
            const string MasterSPInsert = "filestructure_Ins";
            const string MasterSPUpdate = "filestructure_Upd";
            const string MasterSPDelete = "filestructure_Del";
            
			
            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
			
            if (masterEntity.CurrentState == BaseEntity.EntityState.Added)
                SP = MasterSPInsert;
            else if (masterEntity.CurrentState == BaseEntity.EntityState.Changed)
                SP = MasterSPUpdate;
            else if (masterEntity.CurrentState == BaseEntity.EntityState.Deleted)
                 SP = MasterSPDelete;
            else
            {
                throw new Exception("Nothing to save.");
            }
            DateTime dt = DateTime.Now;
            
            try
            {
                using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    if (masterEntity.CurrentState == BaseEntity.EntityState.Added || masterEntity.CurrentState == BaseEntity.EntityState.Changed)
                    {
                        FillParameters(masterEntity, cmd, Database);
                    }
                    else
                    {
                        FillParameters(masterEntity, cmd, Database, true);
                    }
                    FillSequrityParameters(masterEntity.BaseSecurityParam, cmd, Database);                    
                    AddOutputParameter(cmd, Database);
					
					if (masterEntity.CurrentState != BaseEntity.EntityState.Deleted)
                    {
                        IAsyncResult result = Database.BeginExecuteNonQuery(cmd, transaction, null, null);
                        while (!result.IsCompleted)
                        {
                        }
                        returnCode = Database.EndExecuteNonQuery(result);
                                PrimaryKeyMaster = (Int64)(cmd.Parameters["@RETURN_KEY"].Value);
                                masterEntity.RETURN_KEY = PrimaryKeyMaster;
                        
                    }
                    else
                    {
                        returnCode = 1;
                    }
				
                    if (returnCode>0)
                    {
                        if (masterEntity.CurrentState != BaseEntity.EntityState.Deleted)
                        {
                            foreach (var item in listAdded)
                            {
                                item.fileid=PrimaryKeyMaster;
                            }
                        }
                        fileuserrelationDataAccessObjects objfileuserrelation=new fileuserrelationDataAccessObjects(this.Context);
                        objfileuserrelation.SaveList(Database, transaction, listAdded, listUpdated, listDeleted, cancellationToken);
                    }
                    if (masterEntity.CurrentState == BaseEntity.EntityState.Deleted)
                        returnCode = Database.ExecuteNonQuery(cmd, transaction);
                        cmd.Dispose();
                }
				transaction.Commit();                
			}
			catch (Exception ex)
            {
                transaction.Rollback();
                throw GetDataAccessException(ex, SourceOfException("IfilestructureDataAccess.SaveDsfilestructure"));
            }
            finally
            {
                transaction.Dispose();
                connection.Close();
                connection = null;
            }
            return returnCode;
		}
        
        #endregion
        
        
        #region Simple load Single Row
        async Task<filestructureEntity> IfilestructureDataAccessObjects.GetSingle(filestructureEntity filestructure, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "filestructure_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(filestructure.BaseSecurityParam, cmd, Database);
                    FillParameters(filestructure, cmd, Database);
                    
                    IList<filestructureEntity> itemList = new List<filestructureEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new filestructureEntity(reader));
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
                throw GetDataAccessException(ex, SourceOfException("IfilestructureDataAccess.GetSinglefilestructure"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<filestructureEntity>> IfilestructureDataAccessObjects.GAPgListView(filestructureEntity filestructure, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "filestructure_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, filestructure.SortExpression);
                    AddPageSizeParameter(cmd, filestructure.PageSize);
                    AddCurrentPageParameter(cmd, filestructure.CurrentPage);                    
                    FillSequrityParameters(filestructure.BaseSecurityParam, cmd, Database);
                    
					FillParameters(filestructure, cmd,Database);
                    
					if (!string.IsNullOrEmpty (filestructure.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+filestructure.strCommonSerachParam+"%");

                    IList<filestructureEntity> itemList = new List<filestructureEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new filestructureEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						filestructure.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfilestructureDataAccess.GAPgListViewfilestructure"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
            
	}
}