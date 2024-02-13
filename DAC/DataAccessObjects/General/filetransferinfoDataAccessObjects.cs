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
	
	internal sealed partial class filetransferinfoDataAccessObjects : BaseDataAccess, IfiletransferinfoDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "filetransferinfoDataAccessObjects";
        
		public filetransferinfoDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(filetransferinfoEntity filetransferinfo, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (filetransferinfo.filetransid.HasValue)
				Database.AddInParameter(cmd, "@FileTransID", DbType.Int64, filetransferinfo.filetransid);
            if (forDelete) return;
			if (!(string.IsNullOrEmpty(filetransferinfo.fromusername)))
				Database.AddInParameter(cmd, "@FromUsername", DbType.String, filetransferinfo.fromusername);
			
				Database.AddInParameter(cmd, "@FromUserID", DbType.Guid, filetransferinfo.fromuserid);
			if (!(string.IsNullOrEmpty(filetransferinfo.tousername)))
				Database.AddInParameter(cmd, "@ToUsername", DbType.String, filetransferinfo.tousername);
			
				Database.AddInParameter(cmd, "@ToUserID", DbType.Guid, filetransferinfo.touserid);


            if (!(string.IsNullOrEmpty(filetransferinfo.fromuserremark)))
                Database.AddInParameter(cmd, "@FromUserRemark", DbType.String, filetransferinfo.fromuserremark);
            if (!(string.IsNullOrEmpty(filetransferinfo.documentblock)))
                Database.AddInParameter(cmd, "@DocumentBlock", DbType.String, filetransferinfo.documentblock);

            if ((filetransferinfo.sentdate.HasValue))
				Database.AddInParameter(cmd, "@SentDate", DbType.DateTime, filetransferinfo.sentdate);
			if ((filetransferinfo.showedpopup != null))
				Database.AddInParameter(cmd, "@ShowedPopUP", DbType.Boolean, filetransferinfo.showedpopup);
			if ((filetransferinfo.showeddate.HasValue))
				Database.AddInParameter(cmd, "@ShowedDate", DbType.DateTime, filetransferinfo.showeddate);
			if ((filetransferinfo.isreceived != null))
				Database.AddInParameter(cmd, "@IsReceived", DbType.Boolean, filetransferinfo.isreceived);
			if ((filetransferinfo.receiveddate.HasValue))
				Database.AddInParameter(cmd, "@ReceivedDate", DbType.DateTime, filetransferinfo.receiveddate);
			if ((filetransferinfo.isopen != null))
				Database.AddInParameter(cmd, "@IsOpen", DbType.Boolean, filetransferinfo.isopen);
			if ((filetransferinfo.opendate.HasValue))
				Database.AddInParameter(cmd, "@OpenDate", DbType.DateTime, filetransferinfo.opendate);
			if (!(string.IsNullOrEmpty(filetransferinfo.filename)))
				Database.AddInParameter(cmd, "@FileName", DbType.String, filetransferinfo.filename);
			if (filetransferinfo.fileversion.HasValue)
				Database.AddInParameter(cmd, "@FileVersion", DbType.Int32, filetransferinfo.fileversion);
			if (!(string.IsNullOrEmpty(filetransferinfo.fullpath)))
				Database.AddInParameter(cmd, "@FullPath", DbType.String, filetransferinfo.fullpath);
			if (filetransferinfo.priority.HasValue)
				Database.AddInParameter(cmd, "@Priority", DbType.Int32, filetransferinfo.priority);
			if (!(string.IsNullOrEmpty(filetransferinfo.filejsondata)))
				Database.AddInParameter(cmd, "@FileJsonData", DbType.String, filetransferinfo.filejsondata);
			if (filetransferinfo.status.HasValue)
				Database.AddInParameter(cmd, "@Status", DbType.Int32, filetransferinfo.status);
			if ((filetransferinfo.expecteddate.HasValue))
				Database.AddInParameter(cmd, "@ExpectedDate", DbType.DateTime, filetransferinfo.expecteddate);

        }
		
        
		#region Add Operation

        async Task<long> IfiletransferinfoDataAccessObjects.Add(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "filetransferinfo_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(filetransferinfo, cmd,Database);
                FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfiletransferinfoDataAccess.Addfiletransferinfo"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> IfiletransferinfoDataAccessObjects.Update(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "filetransferinfo_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(filetransferinfo, cmd,Database);
                FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfiletransferinfoDataAccess.Updatefiletransferinfo"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> IfiletransferinfoDataAccessObjects.Delete(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "filetransferinfo_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(filetransferinfo, cmd,Database, true);
                FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, Database);
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
                   throw GetDataAccessException(ex, SourceOfException("IfiletransferinfoDataAccess.Deletefiletransferinfo"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> IfiletransferinfoDataAccessObjects.SaveList(IList<filetransferinfoEntity> listAdded, IList<filetransferinfoEntity> listUpdated, IList<filetransferinfoEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "filetransferinfo_Ins";
            const string SPUpdate = "filetransferinfo_Upd";
            const string SPDelete = "filetransferinfo_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (filetransferinfoEntity filetransferinfo in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(filetransferinfo, cmd, Database, true);
                            FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, Database);
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
                    foreach (filetransferinfoEntity filetransferinfo in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(filetransferinfo, cmd, Database);
                            FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, Database);
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
                    foreach (filetransferinfoEntity filetransferinfo in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(filetransferinfo, cmd, Database);
                            FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, Database);
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
                throw GetDataAccessException(ex, SourceOfException("IfiletransferinfoDataAccess.Save_filetransferinfo"));
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
       IList<filetransferinfoEntity> listAdded, 
       IList<filetransferinfoEntity> listUpdated, 
       IList<filetransferinfoEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "filetransferinfo_Ins";
            const string SPUpdate = "filetransferinfo_Upd";
            const string SPDelete = "filetransferinfo_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (filetransferinfoEntity filetransferinfo in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(filetransferinfo, cmd, db, true);
                            FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, db);
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
                    foreach (filetransferinfoEntity filetransferinfo in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(filetransferinfo, cmd, db);
                            FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, db);
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
                    foreach (filetransferinfoEntity filetransferinfo in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(filetransferinfo, cmd, db);
                            FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, db);
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
               
                throw GetDataAccessException(ex, SourceOfException("IfiletransferinfoDataAccess.Save_filetransferinfo"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<filetransferinfoEntity>> IfiletransferinfoDataAccessObjects.GetAll(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "filetransferinfo_GA";
                IList<filetransferinfoEntity> itemList = new List<filetransferinfoEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					AddSortExpressionParameter(cmd, filetransferinfo.SortExpression);
                    FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, Database);
                    FillParameters(filetransferinfo, cmd, Database);
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new filetransferinfoEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfiletransferinfoDataAccess.GetAllfiletransferinfo"));
            }	
        }
		
        async Task<IList<filetransferinfoEntity>> IfiletransferinfoDataAccessObjects.GetAllByPages(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "filetransferinfo_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, filetransferinfo.SortExpression);
                    AddPageSizeParameter(cmd, filetransferinfo.PageSize);
                    AddCurrentPageParameter(cmd, filetransferinfo.CurrentPage);                    
                    FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, Database);
                    
					FillParameters(filetransferinfo, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (filetransferinfo.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+filetransferinfo.strCommonSerachParam+"%");

                    IList<filetransferinfoEntity> itemList = new List<filetransferinfoEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new filetransferinfoEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						filetransferinfo.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfiletransferinfoDataAccess.GetAllByPagesfiletransferinfo"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        #endregion
        
        
        #region Simple load Single Row
        async Task<filetransferinfoEntity> IfiletransferinfoDataAccessObjects.GetSingle(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "filetransferinfo_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, Database);
                    FillParameters(filetransferinfo, cmd, Database);
                    
                    IList<filetransferinfoEntity> itemList = new List<filetransferinfoEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new filetransferinfoEntity(reader));
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
                throw GetDataAccessException(ex, SourceOfException("IfiletransferinfoDataAccess.GetSinglefiletransferinfo"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<filetransferinfoEntity>> IfiletransferinfoDataAccessObjects.GAPgListView(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "filetransferinfo_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, filetransferinfo.SortExpression);
                    AddPageSizeParameter(cmd, filetransferinfo.PageSize);
                    AddCurrentPageParameter(cmd, filetransferinfo.CurrentPage);                    
                    FillSequrityParameters(filetransferinfo.BaseSecurityParam, cmd, Database);
                    
					FillParameters(filetransferinfo, cmd,Database);
                    
					if (!string.IsNullOrEmpty (filetransferinfo.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+filetransferinfo.strCommonSerachParam+"%");

                    IList<filetransferinfoEntity> itemList = new List<filetransferinfoEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new filetransferinfoEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						filetransferinfo.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IfiletransferinfoDataAccess.GAPgListViewfiletransferinfo"));
            }
        }
        #endregion

        #region Extras Reviewed, Published, Archived
        #endregion




    }
}