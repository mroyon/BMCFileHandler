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

    internal sealed partial class gen_serviceinfoDataAccessObjects
    {

        async Task<IList<gen_dropdownEntity>> Igen_serviceinfoDataAccessObjects.GetMappedDataForDropDown(gen_serviceinfoEntity gen_serviceinfo, CancellationToken cancellationToken)
        {
            try
            {
                string SP = "gen_serviceinfo_GAPgDropDown";

                using (DbCommand cmd = Database.GetStoredProcCommand(SP))
                {
                    AddTotalRecordParameter(cmd);
                    AddSortExpressionParameter(cmd, gen_serviceinfo.SortExpression);
                    AddPageSizeParameter(cmd, gen_serviceinfo.PageSize);
                    AddCurrentPageParameter(cmd, gen_serviceinfo.CurrentPage);
                    FillSequrityParameters(gen_serviceinfo.BaseSecurityParam, cmd, Database);
                    FillParameters(gen_serviceinfo, cmd, Database);

                    if (!string.IsNullOrEmpty(gen_serviceinfo.strCommonSerachParam))
                        Database.AddInParameter(cmd, "@CommonSerachParam", DbType.String, " % " + gen_serviceinfo.strCommonSerachParam + " % ");

                    IList<gen_dropdownEntity> itemList = new List<gen_dropdownEntity>();
                    IAsyncResult result = Database.BeginExecuteReader(cmd, null, null);
                    while (!result.IsCompleted)
                    {

                    }
                    using (IDataReader reader = Database.EndExecuteReader(result))
                    {
                        while (reader.Read())
                        {
                            itemList.Add(new gen_dropdownEntity(reader));
                        }
                        reader.Close();
                    }
                    if (itemList.Count > 0)
                    {
                        itemList[0].RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                        gen_serviceinfo.RETURN_KEY = Convert.ToInt64(cmd.Parameters["@TotalRecord"].Value.ToString());
                    }
                    cmd.Dispose();
                    return itemList;
                }
            }
            catch (Exception ex)
            {
                throw GetDataAccessException(ex, SourceOfException("Igen_serviceinfoDataAccess.GetDataForDropDownRefWithService"));
            }
        }

    }
}