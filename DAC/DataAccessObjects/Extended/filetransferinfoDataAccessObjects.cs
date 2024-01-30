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
	
	internal sealed partial class filetransferinfoDataAccessObjects 
	{


        async Task<long> IfiletransferinfoDataAccessObjects.UpdatePopUpData(BDO.Core.DataAccessObjects.Models.filetransferinfoEntity filetransferinfo, System.Threading.CancellationToken cancellationToken)
        {
            long returnCode = -99;
            const string SP = "filetransferinfo_Upd_PopUp";

            using (DbCommand cmd = Database.GetStoredProcCommand(SP))
            {
                FillParameters(filetransferinfo, cmd, Database);
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
                    throw GetDataAccessException(ex, SourceOfException("IfiletransferinfoDataAccess.UpdatePopUpData"));
                }
                cmd.Dispose();
            }
            return returnCode;
        }


        async Task<IList<filetransferinfoEntity>> IfiletransferinfoDataAccessObjects.GetAllMyNotificaiton(filetransferinfoEntity filetransferinfo, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "filetransferinfo_GA_Ext";
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
                throw GetDataAccessException(ex, SourceOfException("IfiletransferinfoDataAccess.GetAllMyNotificaiton"));
            }	
        }
		
        
            
	}
}