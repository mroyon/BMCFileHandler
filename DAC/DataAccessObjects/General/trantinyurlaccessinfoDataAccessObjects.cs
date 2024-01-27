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
	
	internal sealed partial class trantinyurlaccessinfoDataAccessObjects : BaseDataAccess, ItrantinyurlaccessinfoDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "trantinyurlaccessinfoDataAccessObjects";
        
		public trantinyurlaccessinfoDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(trantinyurlaccessinfoEntity trantinyurlaccessinfo, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (trantinyurlaccessinfo.tinyurlacceessid.HasValue)
				Database.AddInParameter(cmd, "@TinyURLAcceessID", DbType.Int64, trantinyurlaccessinfo.tinyurlacceessid);
            if (forDelete) return;
			if (trantinyurlaccessinfo.tinyurlid.HasValue)
				Database.AddInParameter(cmd, "@TinyURLId", DbType.Int64, trantinyurlaccessinfo.tinyurlid);
			if ((trantinyurlaccessinfo.otisused != null))
				Database.AddInParameter(cmd, "@OTIsUsed", DbType.Boolean, trantinyurlaccessinfo.otisused);
			if ((trantinyurlaccessinfo.otusedtime.HasValue))
				Database.AddInParameter(cmd, "@OTUsedTime", DbType.DateTime, trantinyurlaccessinfo.otusedtime);
			if (!(string.IsNullOrEmpty(trantinyurlaccessinfo.otusedfromip)))
				Database.AddInParameter(cmd, "@OTUsedFromIP", DbType.String, trantinyurlaccessinfo.otusedfromip);

        }
		
        
		#region Add Operation

        async Task<long> ItrantinyurlaccessinfoDataAccessObjects.Add(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "trantinyurlaccessinfo_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(trantinyurlaccessinfo, cmd,Database);
                FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("ItrantinyurlaccessinfoDataAccess.Addtrantinyurlaccessinfo"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> ItrantinyurlaccessinfoDataAccessObjects.Update(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "trantinyurlaccessinfo_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(trantinyurlaccessinfo, cmd,Database);
                FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("ItrantinyurlaccessinfoDataAccess.Updatetrantinyurlaccessinfo"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> ItrantinyurlaccessinfoDataAccessObjects.Delete(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "trantinyurlaccessinfo_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(trantinyurlaccessinfo, cmd,Database, true);
                FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, Database);
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
                   throw GetDataAccessException(ex, SourceOfException("ItrantinyurlaccessinfoDataAccess.Deletetrantinyurlaccessinfo"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> ItrantinyurlaccessinfoDataAccessObjects.SaveList(IList<trantinyurlaccessinfoEntity> listAdded, IList<trantinyurlaccessinfoEntity> listUpdated, IList<trantinyurlaccessinfoEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "trantinyurlaccessinfo_Ins";
            const string SPUpdate = "trantinyurlaccessinfo_Upd";
            const string SPDelete = "trantinyurlaccessinfo_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (trantinyurlaccessinfoEntity trantinyurlaccessinfo in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(trantinyurlaccessinfo, cmd, Database, true);
                            FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, Database);
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
                    foreach (trantinyurlaccessinfoEntity trantinyurlaccessinfo in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(trantinyurlaccessinfo, cmd, Database);
                            FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, Database);
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
                    foreach (trantinyurlaccessinfoEntity trantinyurlaccessinfo in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(trantinyurlaccessinfo, cmd, Database);
                            FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, Database);
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
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurlaccessinfoDataAccess.Save_trantinyurlaccessinfo"));
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
       IList<trantinyurlaccessinfoEntity> listAdded, 
       IList<trantinyurlaccessinfoEntity> listUpdated, 
       IList<trantinyurlaccessinfoEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "trantinyurlaccessinfo_Ins";
            const string SPUpdate = "trantinyurlaccessinfo_Upd";
            const string SPDelete = "trantinyurlaccessinfo_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (trantinyurlaccessinfoEntity trantinyurlaccessinfo in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(trantinyurlaccessinfo, cmd, db, true);
                            FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, db);
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
                    foreach (trantinyurlaccessinfoEntity trantinyurlaccessinfo in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(trantinyurlaccessinfo, cmd, db);
                            FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, db);
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
                    foreach (trantinyurlaccessinfoEntity trantinyurlaccessinfo in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(trantinyurlaccessinfo, cmd, db);
                            FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, db);
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
               
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurlaccessinfoDataAccess.Save_trantinyurlaccessinfo"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<trantinyurlaccessinfoEntity>> ItrantinyurlaccessinfoDataAccessObjects.GetAll(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "trantinyurlaccessinfo_GA";
                IList<trantinyurlaccessinfoEntity> itemList = new List<trantinyurlaccessinfoEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, trantinyurlaccessinfo.SortExpression);
                    FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, Database);
                    FillParameters(trantinyurlaccessinfo, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new trantinyurlaccessinfoEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurlaccessinfoDataAccess.GetAlltrantinyurlaccessinfo"));
            }	
        }
		
        async Task<IList<trantinyurlaccessinfoEntity>> ItrantinyurlaccessinfoDataAccessObjects.GetAllByPages(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "trantinyurlaccessinfo_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, trantinyurlaccessinfo.SortExpression);
                    AddPageSizeParameter(cmd, trantinyurlaccessinfo.PageSize);
                    AddCurrentPageParameter(cmd, trantinyurlaccessinfo.CurrentPage);                    
                    FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, Database);
                    
					FillParameters(trantinyurlaccessinfo, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (trantinyurlaccessinfo.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+trantinyurlaccessinfo.strCommonSerachParam+"%");

                    IList<trantinyurlaccessinfoEntity> itemList = new List<trantinyurlaccessinfoEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new trantinyurlaccessinfoEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						trantinyurlaccessinfo.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurlaccessinfoDataAccess.GetAllByPagestrantinyurlaccessinfo"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        #endregion
        
        
        #region Simple load Single Row
        async Task<trantinyurlaccessinfoEntity> ItrantinyurlaccessinfoDataAccessObjects.GetSingle(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "trantinyurlaccessinfo_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, Database);
                    FillParameters(trantinyurlaccessinfo, cmd, Database);
                    
                    IList<trantinyurlaccessinfoEntity> itemList = new List<trantinyurlaccessinfoEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new trantinyurlaccessinfoEntity(reader));
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
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurlaccessinfoDataAccess.GetSingletrantinyurlaccessinfo"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<trantinyurlaccessinfoEntity>> ItrantinyurlaccessinfoDataAccessObjects.GAPgListView(trantinyurlaccessinfoEntity trantinyurlaccessinfo, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "trantinyurlaccessinfo_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, trantinyurlaccessinfo.SortExpression);
                    AddPageSizeParameter(cmd, trantinyurlaccessinfo.PageSize);
                    AddCurrentPageParameter(cmd, trantinyurlaccessinfo.CurrentPage);                    
                    FillSequrityParameters(trantinyurlaccessinfo.BaseSecurityParam, cmd, Database);
                    
					FillParameters(trantinyurlaccessinfo, cmd,Database);
                    
					if (!string.IsNullOrEmpty (trantinyurlaccessinfo.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+trantinyurlaccessinfo.strCommonSerachParam+"%");

                    IList<trantinyurlaccessinfoEntity> itemList = new List<trantinyurlaccessinfoEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new trantinyurlaccessinfoEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						trantinyurlaccessinfo.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("ItrantinyurlaccessinfoDataAccess.GAPgListViewtrantinyurlaccessinfo"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
            
	}
}