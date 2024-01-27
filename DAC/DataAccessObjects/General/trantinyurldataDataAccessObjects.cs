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
	
	internal sealed partial class trantinyurldataDataAccessObjects : BaseDataAccess, ItrantinyurldataDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "trantinyurldataDataAccessObjects";
        
		public trantinyurldataDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(trantinyurldataEntity trantinyurldata, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (trantinyurldata.tinyurlid.HasValue)
				Database.AddInParameter(cmd, "@TinyURLId", DbType.Int64, trantinyurldata.tinyurlid);
            if (forDelete) return;
			if (!(string.IsNullOrEmpty(trantinyurldata.tinyurl)))
				Database.AddInParameter(cmd, "@TinyURL", DbType.String, trantinyurldata.tinyurl);
			if (!(string.IsNullOrEmpty(trantinyurldata.tinyurlcode)))
				Database.AddInParameter(cmd, "@TinyURLCode", DbType.String, trantinyurldata.tinyurlcode);
			if (!(string.IsNullOrEmpty(trantinyurldata.actualurl)))
				Database.AddInParameter(cmd, "@ActualURL", DbType.String, trantinyurldata.actualurl);
			if (trantinyurldata.serviceid.HasValue)
				Database.AddInParameter(cmd, "@ServiceID", DbType.Int64, trantinyurldata.serviceid);
			if ((trantinyurldata.isactive != null))
				Database.AddInParameter(cmd, "@IsActive", DbType.Boolean, trantinyurldata.isactive);
			if ((trantinyurldata.otisonetime != null))
				Database.AddInParameter(cmd, "@OTIsOneTime", DbType.Boolean, trantinyurldata.otisonetime);
			if ((trantinyurldata.otisused != null))
				Database.AddInParameter(cmd, "@OTIsUsed", DbType.Boolean, trantinyurldata.otisused);
			if ((trantinyurldata.otusedtime.HasValue))
				Database.AddInParameter(cmd, "@OTUsedTime", DbType.DateTime, trantinyurldata.otusedtime);
			if (!(string.IsNullOrEmpty(trantinyurldata.otusedfromip)))
				Database.AddInParameter(cmd, "@OTUsedFromIP", DbType.String, trantinyurldata.otusedfromip);

        }
		
        
		#region Add Operation

        async Task<long> ItrantinyurldataDataAccessObjects.Add(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "trantinyurldata_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(trantinyurldata, cmd,Database);
                FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("ItrantinyurldataDataAccess.Addtrantinyurldata"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> ItrantinyurldataDataAccessObjects.Update(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "trantinyurldata_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(trantinyurldata, cmd,Database);
                FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("ItrantinyurldataDataAccess.Updatetrantinyurldata"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> ItrantinyurldataDataAccessObjects.Delete(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "trantinyurldata_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(trantinyurldata, cmd,Database, true);
                FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, Database);
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
                   throw GetDataAccessException(ex, SourceOfException("ItrantinyurldataDataAccess.Deletetrantinyurldata"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> ItrantinyurldataDataAccessObjects.SaveList(IList<trantinyurldataEntity> listAdded, IList<trantinyurldataEntity> listUpdated, IList<trantinyurldataEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "trantinyurldata_Ins";
            const string SPUpdate = "trantinyurldata_Upd";
            const string SPDelete = "trantinyurldata_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (trantinyurldataEntity trantinyurldata in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(trantinyurldata, cmd, Database, true);
                            FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, Database);
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
                    foreach (trantinyurldataEntity trantinyurldata in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(trantinyurldata, cmd, Database);
                            FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, Database);
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
                    foreach (trantinyurldataEntity trantinyurldata in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(trantinyurldata, cmd, Database);
                            FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, Database);
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
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurldataDataAccess.Save_trantinyurldata"));
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
       IList<trantinyurldataEntity> listAdded, 
       IList<trantinyurldataEntity> listUpdated, 
       IList<trantinyurldataEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "trantinyurldata_Ins";
            const string SPUpdate = "trantinyurldata_Upd";
            const string SPDelete = "trantinyurldata_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (trantinyurldataEntity trantinyurldata in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(trantinyurldata, cmd, db, true);
                            FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, db);
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
                    foreach (trantinyurldataEntity trantinyurldata in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(trantinyurldata, cmd, db);
                            FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, db);
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
                    foreach (trantinyurldataEntity trantinyurldata in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(trantinyurldata, cmd, db);
                            FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, db);
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
               
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurldataDataAccess.Save_trantinyurldata"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<trantinyurldataEntity>> ItrantinyurldataDataAccessObjects.GetAll(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "trantinyurldata_GA";
                IList<trantinyurldataEntity> itemList = new List<trantinyurldataEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, trantinyurldata.SortExpression);
                    FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, Database);
                    FillParameters(trantinyurldata, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new trantinyurldataEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurldataDataAccess.GetAlltrantinyurldata"));
            }	
        }
		
        async Task<IList<trantinyurldataEntity>> ItrantinyurldataDataAccessObjects.GetAllByPages(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "trantinyurldata_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, trantinyurldata.SortExpression);
                    AddPageSizeParameter(cmd, trantinyurldata.PageSize);
                    AddCurrentPageParameter(cmd, trantinyurldata.CurrentPage);                    
                    FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, Database);
                    
					FillParameters(trantinyurldata, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (trantinyurldata.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+trantinyurldata.strCommonSerachParam+"%");

                    IList<trantinyurldataEntity> itemList = new List<trantinyurldataEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new trantinyurldataEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						trantinyurldata.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurldataDataAccess.GetAllByPagestrantinyurldata"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        
        async Task<long> ItrantinyurldataDataAccessObjects.SaveMasterDettrantinyurlaccessinfo(trantinyurldataEntity masterEntity, 
        IList<trantinyurlaccessinfoEntity> listAdded, 
        IList<trantinyurlaccessinfoEntity> listUpdated,
        IList<trantinyurlaccessinfoEntity> listDeleted, 
        CancellationToken cancellationToken)
        {
			long returnCode = -99;
                Int64 PrimaryKeyMaster = -99;
            
            string SP = "";
            const string MasterSPInsert = "trantinyurldata_Ins";
            const string MasterSPUpdate = "trantinyurldata_Upd";
            const string MasterSPDelete = "trantinyurldata_Del";
            
			
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
                                item.tinyurlid=PrimaryKeyMaster;
                            }
                        }
                        trantinyurlaccessinfoDataAccessObjects objtrantinyurlaccessinfo=new trantinyurlaccessinfoDataAccessObjects(this.Context);
                        objtrantinyurlaccessinfo.SaveList(Database, transaction, listAdded, listUpdated, listDeleted, cancellationToken);
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
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurldataDataAccess.SaveDstrantinyurldata"));
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
        async Task<trantinyurldataEntity> ItrantinyurldataDataAccessObjects.GetSingle(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "trantinyurldata_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, Database);
                    FillParameters(trantinyurldata, cmd, Database);
                    
                    IList<trantinyurldataEntity> itemList = new List<trantinyurldataEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new trantinyurldataEntity(reader));
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
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurldataDataAccess.GetSingletrantinyurldata"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<trantinyurldataEntity>> ItrantinyurldataDataAccessObjects.GAPgListView(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "trantinyurldata_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, trantinyurldata.SortExpression);
                    AddPageSizeParameter(cmd, trantinyurldata.PageSize);
                    AddCurrentPageParameter(cmd, trantinyurldata.CurrentPage);                    
                    FillSequrityParameters(trantinyurldata.BaseSecurityParam, cmd, Database);
                    
					FillParameters(trantinyurldata, cmd,Database);
                    
					if (!string.IsNullOrEmpty (trantinyurldata.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+trantinyurldata.strCommonSerachParam+"%");

                    IList<trantinyurldataEntity> itemList = new List<trantinyurldataEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new trantinyurldataEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						trantinyurldata.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurldataDataAccess.GAPgListViewtrantinyurldata"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
            
	}
}