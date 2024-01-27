using CLL.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.Interfaces.Services;
using Web.Core.Frame.Interfaces.UseCases;
using Web.Core.Frame.Dto;
using AppConfig.HelperClasses;
using Web.Core.Frame.Helpers;
using System.Security.Claims;
using static AppConfig.HelperClasses.applicationEnamNConstants;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.SecurityModels;
using BDO.DataAccessObjects.ExtendedEntities;
using Microsoft.Extensions.Configuration;

namespace Web.Core.Frame.UseCases
{
    public sealed partial class TranTinyURLDataUseCase
    {
        public async Task<bool> SetActualURLByTinyURL(TranTinyURLDataRequest message, ITranTinyURLDataRequestHandler<TranTinyURLDataResponse> outputPort)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(message));
            CancellationToken cancellationToken = new CancellationToken();
            long? i = null;
            try
            {
                AppConfig.HelperClasses.transactioncodeGen codeGen = new AppConfig.HelperClasses.transactioncodeGen();
                AppConfig.EncryptionHandler.EncryptionHelper objEnc = new AppConfig.EncryptionHandler.EncryptionHelper();
                await Task.Delay(300);

                DateTime dot = DateTime.Now;
                message.Objtrantinyurldata.tinyurlcode = codeGen.GetRandomAlphaNumericStringForTransactionActivity("TNU",dot)+"|"+ message.Objtrantinyurldata.serviceid.GetValueOrDefault().ToString();
                message.Objtrantinyurldata.tinyurlcode = objEnc.base64Encode(message.Objtrantinyurldata.tinyurlcode);
                message.Objtrantinyurldata.tinyurl = _tinyURLPassThroughSettings.WebApiAddress + message.Objtrantinyurldata.tinyurlcode;

                i = await BFC.Core.FacadeCreatorObjects.General.trantinyurldataFCC.GetFacadeCreate(_contextAccessor)
                    .SetActualURLByTinyURL(message.Objtrantinyurldata, cancellationToken);

                if (i > 0)
                {
                    var objEntity = message.Objtrantinyurldata;
                    outputPort.customOutputProcess(new TranTinyURLDataResponse(objEntity, true));
                }
                return true;
            }
            catch (Exception ex)
            {
                TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["DATA_SAVE_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.customOutputProcess(objResponse);
                return true;
            }
        }
        public async Task<bool> GetActualURLByTinyURL(TranTinyURLDataRequest message, ITranTinyURLDataRequestHandler<TranTinyURLDataResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {
                trantinyurldataEntity objSingle = await BFC.Core.FacadeCreatorObjects.General.trantinyurldataFCC.GetFacadeCreate(_contextAccessor)
                .GetActualURLByTinyURL(message.Objtrantinyurldata, cancellationToken);
                if (objSingle != null)
                {
                    outputPort.customOutputProcess(new TranTinyURLDataResponse(objSingle, true));
                    return true;
                }
                else
                {
                    TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
                     "404",
                     _sharedLocalizer["NO_DATA_FOUND"]));
                    _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                    outputPort.customOutputProcess(objResponse);
                    return false;
                }
            }
            catch (Exception ex)
            {
                TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.customOutputProcess(objResponse);
                return true;
            }
        }
    }
}