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
	
	internal sealed partial class folderstructureDataAccessObjects : BaseDataAccess, IfolderstructureDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "folderstructureDataAccessObjects";
        
		public folderstructureDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(folderstructureEntity folderstructure, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (folderstructure.folderid.HasValue)
				Database.AddInParameter(cmd, "@FolderID", DbType.Int64, folderstructure.folderid);
            if (forDelete) return;
			if (!(string.IsNullOrEmpty(folderstructure.foldername)))
				Database.AddInParameter(cmd, "@FolderName", DbType.String, folderstructure.foldername);
			if (!(string.IsNullOrEmpty(folderstructure.physicalpath)))
				Database.AddInParameter(cmd, "@PhysicalPath", DbType.String, folderstructure.physicalpath);
			if (folderstructure.parentfolderid.HasValue)
				Database.AddInParameter(cmd, "@ParentFolderID", DbType.Int64, folderstructure.parentfolderid);
			if ((folderstructure.isdeleted != null))
				Database.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, folderstructure.isdeleted);
			if (!(string.IsNullOrEmpty(folderstructure.deletedbyuser)))
				Database.AddInParameter(cmd, "@DeletedByUser", DbType.String, folderstructure.deletedbyuser);
			if ((folderstructure.deleteddate.HasValue))
				Database.AddInParameter(cmd, "@DeletedDate", DbType.DateTime, folderstructure.deleteddate);

        }
		
        
		#region Add Operation

        async Task<long> IfolderstructureDataAccessObjects.Add(folderstructureEntity folderstructure, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "folderstructure_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(folderstructure, cmd,Database);
                FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfolderstructureDataAccess.Addfolderstructure"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> IfolderstructureDataAccessObjects.Update(folderstructureEntity folderstructure, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "folderstructure_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(folderstructure, cmd,Database);
                FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfolderstructureDataAccess.Updatefolderstructure"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> IfolderstructureDataAccessObjects.Delete(folderstructureEntity folderstructure, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "folderstructure_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(folderstructure, cmd,Database, true);
                FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, Database);
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
                   throw GetDataAccessException(ex, SourceOfException("IfolderstructureDataAccess.Deletefolderstructure"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> IfolderstructureDataAccessObjects.SaveList(IList<folderstructureEntity> listAdded, IList<folderstructureEntity> listUpdated, IList<folderstructureEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "folderstructure_Ins";
            const string SPUpdate = "folderstructure_Upd";
            const string SPDelete = "folderstructure_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (folderstructureEntity folderstructure in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(folderstructure, cmd, Database, true);
                            FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, Database);
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
                    foreach (folderstructureEntity folderstructure in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(folderstructure, cmd, Database);
                            FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, Database);
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
                    foreach (folderstructureEntity folderstructure in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(folderstructure, cmd, Database);
                            FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, Database);
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
                throw GetDataAccessException(ex, SourceOfException("IfolderstructureDataAccess.Save_folderstructure"));
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
       IList<folderstructureEntity> listAdded, 
       IList<folderstructureEntity> listUpdated, 
       IList<folderstructureEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "folderstructure_Ins";
            const string SPUpdate = "folderstructure_Upd";
            const string SPDelete = "folderstructure_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (folderstructureEntity folderstructure in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(folderstructure, cmd, db, true);
                            FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, db);
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
                    foreach (folderstructureEntity folderstructure in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(folderstructure, cmd, db);
                            FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, db);
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
                    foreach (folderstructureEntity folderstructure in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(folderstructure, cmd, db);
                            FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, db);
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
               
                throw GetDataAccessException(ex, SourceOfException("IfolderstructureDataAccess.Save_folderstructure"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<folderstructureEntity>> IfolderstructureDataAccessObjects.GetAll(folderstructureEntity folderstructure, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "folderstructure_GA";
                IList<folderstructureEntity> itemList = new List<folderstructureEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, folderstructure.SortExpression);
                    FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, Database);
                    FillParameters(folderstructure, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new folderstructureEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfolderstructureDataAccess.GetAllfolderstructure"));
            }	
        }
		
        async Task<IList<folderstructureEntity>> IfolderstructureDataAccessObjects.GetAllByPages(folderstructureEntity folderstructure, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "folderstructure_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, folderstructure.SortExpression);
                    AddPageSizeParameter(cmd, folderstructure.PageSize);
                    AddCurrentPageParameter(cmd, folderstructure.CurrentPage);                    
                    FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, Database);
                    
					FillParameters(folderstructure, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (folderstructure.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+folderstructure.strCommonSerachParam+"%");

                    IList<folderstructureEntity> itemList = new List<folderstructureEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new folderstructureEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						folderstructure.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfolderstructureDataAccess.GetAllByPagesfolderstructure"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        
        async Task<long> IfolderstructureDataAccessObjects.SaveMasterDetfilestructure(folderstructureEntity masterEntity, 
        IList<filestructureEntity> listAdded, 
        IList<filestructureEntity> listUpdated,
        IList<filestructureEntity> listDeleted, 
        CancellationToken cancellationToken)
        {
			long returnCode = -99;
                Int64 PrimaryKeyMaster = -99;
            
            string SP = "";
            const string MasterSPInsert = "folderstructure_Ins";
            const string MasterSPUpdate = "folderstructure_Upd";
            const string MasterSPDelete = "folderstructure_Del";
            
			
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
                                item.folderid=PrimaryKeyMaster;
                            }
                        }
                        filestructureDataAccessObjects objfilestructure=new filestructureDataAccessObjects(this.Context);
                        objfilestructure.SaveList(Database, transaction, listAdded, listUpdated, listDeleted, cancellationToken);
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
                throw GetDataAccessException(ex, SourceOfException("IfolderstructureDataAccess.SaveDsfolderstructure"));
            }
            finally
            {
                transaction.Dispose();
                connection.Close();
                connection = null;
            }
            return returnCode;
		}
        
        
        async Task<long> IfolderstructureDataAccessObjects.SaveMasterDetfolderuserrelation(folderstructureEntity masterEntity, 
        IList<folderuserrelationEntity> listAdded, 
        IList<folderuserrelationEntity> listUpdated,
        IList<folderuserrelationEntity> listDeleted, 
        CancellationToken cancellationToken)
        {
			long returnCode = -99;
                Int64 PrimaryKeyMaster = -99;
            
            string SP = "";
            const string MasterSPInsert = "folderstructure_Ins";
            const string MasterSPUpdate = "folderstructure_Upd";
            const string MasterSPDelete = "folderstructure_Del";
            
			
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
                                item.folderid=PrimaryKeyMaster;
                            }
                        }
                        folderuserrelationDataAccessObjects objfolderuserrelation=new folderuserrelationDataAccessObjects(this.Context);
                        objfolderuserrelation.SaveList(Database, transaction, listAdded, listUpdated, listDeleted, cancellationToken);
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
                throw GetDataAccessException(ex, SourceOfException("IfolderstructureDataAccess.SaveDsfolderstructure"));
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
        async Task<folderstructureEntity> IfolderstructureDataAccessObjects.GetSingle(folderstructureEntity folderstructure, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "folderstructure_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, Database);
                    FillParameters(folderstructure, cmd, Database);
                    
                    IList<folderstructureEntity> itemList = new List<folderstructureEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new folderstructureEntity(reader));
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
                throw GetDataAccessException(ex, SourceOfException("IfolderstructureDataAccess.GetSinglefolderstructure"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<folderstructureEntity>> IfolderstructureDataAccessObjects.GAPgListView(folderstructureEntity folderstructure, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "folderstructure_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, folderstructure.SortExpression);
                    AddPageSizeParameter(cmd, folderstructure.PageSize);
                    AddCurrentPageParameter(cmd, folderstructure.CurrentPage);                    
                    FillSequrityParameters(folderstructure.BaseSecurityParam, cmd, Database);
                    
					FillParameters(folderstructure, cmd,Database);
                    
					if (!string.IsNullOrEmpty (folderstructure.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+folderstructure.strCommonSerachParam+"%");

                    IList<folderstructureEntity> itemList = new List<folderstructureEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new folderstructureEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						folderstructure.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfolderstructureDataAccess.GAPgListViewfolderstructure"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
            
	}
}