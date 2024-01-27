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
    public sealed partial class TranTinyURLDataUseCase : ITranTinyURLDataUseCase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IJwtFactory _jwtFactory;
        private readonly IStringLocalizer _sharedLocalizer;
        private readonly TinyURLPassThroughSettings _tinyURLPassThroughSettings;
        private readonly ILogger<TranTinyURLDataUseCase> _logger;
        private dataTableButtonPanel objDTBtnPanel = new dataTableButtonPanel();
        public Error _errors { get; set; }
        private readonly IConfiguration _configuration;

        public TranTinyURLDataUseCase(
            IHttpContextAccessor contextAccessor,
            IJwtFactory jwtFactory,
            IStringLocalizerFactory factory,
            ILoggerFactory loggerFactory,
        IConfiguration config)
        {
            _contextAccessor = contextAccessor;
            _jwtFactory = jwtFactory;
            _logger = loggerFactory.CreateLogger<TranTinyURLDataUseCase>();

            _configuration = config;

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
            _tinyURLPassThroughSettings =  config.GetSection(nameof(TinyURLPassThroughSettings)).Get<TinyURLPassThroughSettings>();
        }

        public Task<bool> Handle(TranTinyURLDataRequest message, IOutputPort<TranTinyURLDataResponse> outputPort)
        {
            throw new Exception("Not Implemented");
        }

        public async Task<bool> GetAll(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {
                IList<trantinyurldataEntity> oblist = await BFC.Core.FacadeCreatorObjects.General.trantinyurldataFCC.GetFacadeCreate(_contextAccessor)
                .GetAll(message.Objtrantinyurldata, cancellationToken);

                if (oblist != null && oblist.Count > 0)
                {
                    outputPort.GetAll(new TranTinyURLDataResponse(oblist.ToList(), true));
                    return true;
                }
                else
                {
                    TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
                     "404",
                     _sharedLocalizer["NO_DATA_FOUND"]));
                    _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                    outputPort.GetAll(objResponse);
                    return false;
                }                
            }
            catch (Exception ex)
            {
                TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetAll(objResponse);
                return true;
            }
        }

        public async Task<bool> GetAllPaged(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {
                IList<trantinyurldataEntity> oblist = await BFC.Core.FacadeCreatorObjects.General.trantinyurldataFCC.GetFacadeCreate(_contextAccessor)
                .GetAllByPages(message.Objtrantinyurldata, cancellationToken);

                if (oblist != null && oblist.Count > 0)
                {
                    outputPort.GetAllPaged(new TranTinyURLDataResponse(oblist.ToList(), true));
                    return true;
                }
                else
                {
                    TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
                     "404",
                     _sharedLocalizer["NO_DATA_FOUND"]));
                    _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                    outputPort.GetAllPaged(objResponse);
                    return false;
                }
            }
            catch (Exception ex)
            {
                TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetAllPaged(objResponse);
                return true;
            }
        }

        public async Task<bool> GetListView(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {

                IList<trantinyurldataEntity> oblist = await BFC.Core.FacadeCreatorObjects.General.trantinyurldataFCC.GetFacadeCreate(_contextAccessor)
                .GAPgListView(message.Objtrantinyurldata, cancellationToken);
                if (oblist != null && oblist.Count > 0)
                {
                    List<dataTableButtonModel> btnActionList = new List<dataTableButtonModel>();
                    //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.New_GET));
                    btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.Edit_GET));
                    //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.Delete_GET));
                    btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.GetSingle_GET));
                    //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.CUSTOM, _sharedLocalizer["PROCESS"], "StpOrganizationEntity/userprocess"));
                    //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.CUSTOM, _sharedLocalizer["SEARCH"], "StpOrganizationEntity/usersearch"));
                    
                    var data = (from t in oblist
                                select new
                                {
									 t.tinyurlid,
									 t.tinyurl,
									 t.tinyurlcode,
									 t.actualurl,
									 t.serviceid,
									 t.isactive,
									 t.otisonetime,
									 t.otisused,
									 t.otusedtime,
									 t.otusedfromip,
                                    servicename = BFC.Core.FacadeCreatorObjects.General.gen_serviceinfoFCC.GetFacadeCreate(_contextAccessor)
                                                .GetAll(new gen_serviceinfoEntity { serviceid = t.serviceid }, cancellationToken).Result.ToList().FirstOrDefault().servicear,
                                    datatablebuttonscode = objDTBtnPanel.genDTBtnPanel(message.Objtrantinyurldata.ControllerName, t.tinyurlid, "tinyurlid", _contextAccessor.HttpContext.User.Identity as ClaimsIdentity, btnActionList, _contextAccessor)
                                }).ToList();

                    outputPort.GetListView(new TranTinyURLDataResponse(new AjaxResponse(oblist[0].RETURN_KEY, data), true, null));
                    return true;
                }
                else
                {
                 TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
                     "404",
                     _sharedLocalizer["NO_DATA_FOUND"]));
                    _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                    outputPort.GetListView(objResponse);
                    return false;
                }
            }
            catch (Exception ex)
            {
                TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetListView(objResponse);
                return true;
            }
        }

        public async Task<bool> GetSingle(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {
                trantinyurldataEntity trantinyurldataEntity = new trantinyurldataEntity();
                if (!string.IsNullOrEmpty(message.Objtrantinyurldata.tinyurl))
                    trantinyurldataEntity.tinyurlcode = TinyUrlHelper.GetShortCodeFromTinyUrl(message.Objtrantinyurldata.tinyurl);
                
                if (message.Objtrantinyurldata.tinyurlid.HasValue) trantinyurldataEntity.tinyurlid = message.Objtrantinyurldata.tinyurlid;

                trantinyurldataEntity objSingle = await BFC.Core.FacadeCreatorObjects.General.trantinyurldataFCC.GetFacadeCreate(_contextAccessor)
                .GetSingle(message.Objtrantinyurldata, cancellationToken);
                if (objSingle != null)
                {
                    outputPort.GetSingle(new TranTinyURLDataResponse(objSingle, true));
                    return true;
                }
                else
                {
                    TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
                     "404",
                     _sharedLocalizer["NO_DATA_FOUND"]));
                    _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                    outputPort.GetSingle(objResponse);
                    return false;
                }
            }
            catch (Exception ex)
            {
                TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetSingle(objResponse);
                return true;
            }
        }

        public async Task<bool> Save(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(message));
            CancellationToken cancellationToken = new CancellationToken();
            long? i = null;
            try
            {
                
                i = await BFC.Core.FacadeCreatorObjects.General.trantinyurldataFCC.GetFacadeCreate(_contextAccessor)
                    .Add(message.Objtrantinyurldata, cancellationToken);
                
                //FIX
                //return message.Objtrantinyurldata

                outputPort.Save(new TranTinyURLDataResponse(new AjaxResponse("200", _sharedLocalizer["DATA_SAVE_CONFIRMATION"].Value, CLL.LLClasses._Status._statusSuccess, CLL.LLClasses._Status._titleInformation, "/"
                ), true, null));
                return true;
            }
            catch (Exception ex)
            {
                TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["DATA_SAVE_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.Save(objResponse);
                return true;
            }
        }

        public async Task<bool> Update(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            long? i = null;
            try
            {
                i = await BFC.Core.FacadeCreatorObjects.General.trantinyurldataFCC.GetFacadeCreate(_contextAccessor)
                    .Update(message.Objtrantinyurldata, cancellationToken);
                
                outputPort.Update(new TranTinyURLDataResponse(new AjaxResponse("200", _sharedLocalizer["DATA_UPDATE_CONFIRMATION"].Value, CLL.LLClasses._Status._statusSuccess, CLL.LLClasses._Status._titleInformation, "/"
                        ), true, null));
                return true;
            }
            catch (Exception ex)
            {
                TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["DATA_UPDATE_ERROR"], new Error(
                       "500",
                       ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.Update(objResponse);
                return true;
            }
        }

        public async Task<bool> Delete(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            long? i = null;
            try
            {
                i = await BFC.Core.FacadeCreatorObjects.General.trantinyurldataFCC.GetFacadeCreate(_contextAccessor)
                    .Delete(message.Objtrantinyurldata, cancellationToken);
                outputPort.Delete(new TranTinyURLDataResponse(new AjaxResponse("200", _sharedLocalizer["DATA_DELETE_CONFIRMATION"].Value, CLL.LLClasses._Status._statusSuccess, CLL.LLClasses._Status._titleInformation, "/"
                       ), true, null));
                return true;
            }
            catch (Exception ex)
            {
                TranTinyURLDataResponse objResponse = new TranTinyURLDataResponse(false, _sharedLocalizer["DATA_DELETE_ERROR"], new Error(
                         "500",
                         ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.Delete(objResponse);
                return true;
            }
        }

        


    }
}