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
	
	internal sealed partial class trantinyurldataDataAccessObjects 
	{
        #region SetActualURLByTinyURL Operation

        async Task<long> ItrantinyurldataDataAccessObjects.SetActualURLByTinyURL(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
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

        #endregion SetActualURLByTinyURL Operation

        #region GetActualURLByTinyURL
        async Task<trantinyurldataEntity> ItrantinyurldataDataAccessObjects.GetActualURLByTinyURL(trantinyurldataEntity trantinyurldata, CancellationToken cancellationToken)
        {
           try
            {
				const string SP = "KAF_GetActualURLByTinyURL";
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
        
        
        
        
        
            
	}
}