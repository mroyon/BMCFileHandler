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
	
	internal sealed partial class chartDataAccessObjects : BaseDataAccess, IchartDataAccessObjects
	{
		
	    #region Constructors
        
		private string ClassName = "chartDataAccessObjects";
        
		public chartDataAccessObjects(Context context): base(context)
		{
		}
		
		private string SourceOfException(string methodName)
        {
            return "Class name: " + ClassName + " and Method name: " + methodName;
        }
        
		#endregion
		
        public static void FillParameters(chartEntity chart, DbCommand cmd,Database Database,bool forDelete=false)
        {
			if (chart.chartid.HasValue)
				Database.AddInParameter(cmd, "@ChartID", DbType.Int64, chart.chartid);
            if (forDelete) return;
			if (!(string.IsNullOrEmpty(chart.charttitle)))
				Database.AddInParameter(cmd, "@ChartTitle", DbType.String, chart.charttitle);
			if (chart.chartvalues.HasValue)
				Database.AddInParameter(cmd, "@ChartValues", DbType.Int64, chart.chartvalues);

        }
		
        
		#region Add Operation

        async Task<long> IchartDataAccessObjects.Add(chartEntity chart, CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "chart_Ins";
			
			using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
                FillParameters(chart, cmd,Database);
                FillSequrityParameters(chart.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IchartDataAccess.Addchart"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }
       
        #endregion Add Operation
		
		#region Update Operation

        async Task<long> IchartDataAccessObjects.Update(chartEntity chart, CancellationToken cancellationToken)
        {
           long returnCode = -99;
            const string SP = "chart_Upd";
			
            using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
			    FillParameters(chart, cmd,Database);
                FillSequrityParameters(chart.BaseSecurityParam, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IchartDataAccess.Updatechart"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

        #endregion Update Operation
		
		#region Delete Operation

        async Task<long> IchartDataAccessObjects.Delete(chartEntity chart, CancellationToken cancellationToken)
        {
            long returnCode = -99;
           	const string SP = "chart_Del";
			
           	using (DbCommand cmd =  Database.GetStoredProcCommand(SP))
            {
				FillParameters(chart, cmd,Database, true);
                FillSequrityParameters(chart.BaseSecurityParam, cmd, Database);
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
                   throw GetDataAccessException(ex, SourceOfException("IchartDataAccess.Deletechart"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }

		#endregion Delete Operation
        
        #region SaveList<>
		
        async Task<long> IchartDataAccessObjects.SaveList(IList<chartEntity> listAdded, IList<chartEntity> listUpdated, IList<chartEntity> listDeleted, CancellationToken cancellationToken)
        {
            long returnCode = -99;

            const string SPInsert = "chart_Ins";
            const string SPUpdate = "chart_Upd";
            const string SPDelete = "chart_Del";

            DbConnection connection = Database.CreateConnection();
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (chartEntity chart in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(chart, cmd, Database, true);
                            FillSequrityParameters(chart.BaseSecurityParam, cmd, Database);
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
                    foreach (chartEntity chart in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(chart, cmd, Database);
                            FillSequrityParameters(chart.BaseSecurityParam, cmd, Database);
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
                    foreach (chartEntity chart in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(chart, cmd, Database);
                            FillSequrityParameters(chart.BaseSecurityParam, cmd, Database);
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
                throw GetDataAccessException(ex, SourceOfException("IchartDataAccess.Save_chart"));
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
       IList<chartEntity> listAdded, 
       IList<chartEntity> listUpdated, 
       IList<chartEntity> listDeleted, 
       CancellationToken cancellationToken) 
       {
            long returnCode = -99;

            const string SPInsert = "chart_Ins";
            const string SPUpdate = "chart_Upd";
            const string SPDelete = "chart_Del";

            
            
            try
            {
                if (listDeleted.Count > 0 )
                {
                    foreach (chartEntity chart in listDeleted)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPDelete))
                        {
                            FillParameters(chart, cmd, db, true);
                            FillSequrityParameters(chart.BaseSecurityParam, cmd, db);
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
                    foreach (chartEntity chart in listUpdated)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPUpdate))
                        {
                            FillParameters(chart, cmd, db);
                            FillSequrityParameters(chart.BaseSecurityParam, cmd, db);
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
                    foreach (chartEntity chart in listAdded)
                    {
                        using (DbCommand cmd = Database.GetStoredProcCommand(SPInsert))
                        {
                            FillParameters(chart, cmd, db);
                            FillSequrityParameters(chart.BaseSecurityParam, cmd, db);
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
               
                throw GetDataAccessException(ex, SourceOfException("IchartDataAccess.Save_chart"));
            }
            finally
            {
               
            }
            return returnCode;
        }
        
        #endregion SaveList<>
		
		#region GetAll

        async Task<IList<chartEntity>> IchartDataAccessObjects.GetAll(chartEntity chart, CancellationToken cancellationToken)
        {
           try
            {
				//const string SP = "chart_GA";
				const string SP = "filetransferinfo_PieChart01";
                IList<chartEntity> itemList = new List<chartEntity>();
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					
					//AddSortExpressionParameter(cmd, chart.SortExpression);
                    //FillSequrityParameters(chart.BaseSecurityParam, cmd, Database);
                    //FillParameters(chart, cmd, Database);

                    if (chart.userid.HasValue)
                        Database.AddInParameter(cmd, "@ToUserID", DbType.Guid, chart.userid);

                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new chartEntity(reader));
                        }
                        reader.Close();
                    }                    
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IchartDataAccess.GetAllchart"));
            }	
        }
		
        async Task<IList<chartEntity>> IchartDataAccessObjects.GetAllByPages(chartEntity chart, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "chart_GAPg";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, chart.SortExpression);
                    AddPageSizeParameter(cmd, chart.PageSize);
                    AddCurrentPageParameter(cmd, chart.CurrentPage);                    
                    FillSequrityParameters(chart.BaseSecurityParam, cmd, Database);
                    
					FillParameters(chart, cmd,Database);
                    
                    if (!string.IsNullOrEmpty (chart.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+chart.strCommonSerachParam+"%");

                    IList<chartEntity> itemList = new List<chartEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new chartEntity(reader));
                        }
                        reader.Close();
                    }
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						chart.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IchartDataAccess.GetAllByPageschart"));
            }
        }
        
        #endregion
        
        #region Save Master/Details
        
        #endregion
        
        
        #region Simple load Single Row
        async Task<chartEntity> IchartDataAccessObjects.GetSingle(chartEntity chart, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "chart_GS";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
                    FillSequrityParameters(chart.BaseSecurityParam, cmd, Database);
                    FillParameters(chart, cmd, Database);
                    
                    IList<chartEntity> itemList = new List<chartEntity>();
                    
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new chartEntity(reader));
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
                throw GetDataAccessException(ex, SourceOfException("IchartDataAccess.GetSinglechart"));
            }	
        }
        #endregion
        
        #region ForListView Paged Method
        async Task<IList<chartEntity>> IchartDataAccessObjects.GAPgListView(chartEntity chart, CancellationToken cancellationToken)
        {
        try
            {
				const string SP = "chart_GAPgListView";
				using (DbCommand cmd = Database.GetStoredProcCommand(SP))
				{
					AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, chart.SortExpression);
                    AddPageSizeParameter(cmd, chart.PageSize);
                    AddCurrentPageParameter(cmd, chart.CurrentPage);                    
                    FillSequrityParameters(chart.BaseSecurityParam, cmd, Database);
                    
					FillParameters(chart, cmd,Database);
                    
					if (!string.IsNullOrEmpty (chart.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String,  "%"+chart.strCommonSerachParam+"%");

                    IList<chartEntity> itemList = new List<chartEntity>();
					
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null,null);
                    while (!result.IsCompleted)
                    {
                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new chartEntity(reader));
                        }
                        reader.Close();
                    }
                    
                    if(itemList.Count>0)
					{
                        itemList[0].RETURN_KEY   = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
						chart.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
				}
			}
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("IchartDataAccess.GAPgListViewchart"));
            }
        }
        #endregion
        
        #region Extras Reviewed, Published, Archived
        #endregion
        
            
	}
}