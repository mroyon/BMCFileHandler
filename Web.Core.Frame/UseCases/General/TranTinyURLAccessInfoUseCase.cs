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

namespace Web.Core.Frame.UseCases
{
    public sealed partial class TranTinyURLAccessInfoUseCase : ITranTinyURLAccessInfoUseCase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IJwtFactory _jwtFactory;
        private readonly IStringLocalizer _sharedLocalizer;
        private readonly ILogger<TranTinyURLAccessInfoUseCase> _logger;
        private dataTableButtonPanel objDTBtnPanel = new dataTableButtonPanel();
        public Error _errors { get; set; }

        public TranTinyURLAccessInfoUseCase(
            IHttpContextAccessor contextAccessor,
            IJwtFactory jwtFactory,
            IStringLocalizerFactory factory,
            ILoggerFactory loggerFactory)
        {
            _contextAccessor = contextAccessor;
            _jwtFactory = jwtFactory;
            _logger = loggerFactory.CreateLogger<TranTinyURLAccessInfoUseCase>();

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public Task<bool> Handle(TranTinyURLAccessInfoRequest message, IOutputPort<TranTinyURLAccessInfoResponse> outputPort)
        {
            throw new Exception("Not Implemented");
        }

        public async Task<bool> GetAll(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {
                IList<trantinyurlaccessinfoEntity> oblist = await BFC.Core.FacadeCreatorObjects.General.trantinyurlaccessinfoFCC.GetFacadeCreate(_contextAccessor)
                .GetAll(message.Objtrantinyurlaccessinfo, cancellationToken);

                if (oblist != null && oblist.Count > 0)
                {
                    outputPort.GetAll(new TranTinyURLAccessInfoResponse(oblist.ToList(), true));
                    return true;
                }
                else
                {
                    TranTinyURLAccessInfoResponse objResponse = new TranTinyURLAccessInfoResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
                     "404",
                     _sharedLocalizer["NO_DATA_FOUND"]));
                    _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                    outputPort.GetAll(objResponse);
                    return false;
                }                
            }
            catch (Exception ex)
            {
                TranTinyURLAccessInfoResponse objResponse = new TranTinyURLAccessInfoResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetAll(objResponse);
                return true;
            }
        }

        public async Task<bool> GetAllPaged(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {
                IList<trantinyurlaccessinfoEntity> oblist = await BFC.Core.FacadeCreatorObjects.General.trantinyurlaccessinfoFCC.GetFacadeCreate(_contextAccessor)
                .GetAllByPages(message.Objtrantinyurlaccessinfo, cancellationToken);

                if (oblist != null && oblist.Count > 0)
                {
                    outputPort.GetAllPaged(new TranTinyURLAccessInfoResponse(oblist.ToList(), true));
                    return true;
                }
                else
                {
                    TranTinyURLAccessInfoResponse objResponse = new TranTinyURLAccessInfoResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
                     "404",
                     _sharedLocalizer["NO_DATA_FOUND"]));
                    _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                    outputPort.GetAllPaged(objResponse);
                    return false;
                }
            }
            catch (Exception ex)
            {
                TranTinyURLAccessInfoResponse objResponse = new TranTinyURLAccessInfoResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetAllPaged(objResponse);
                return true;
            }
        }

        public async Task<bool> GetListView(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {

                IList<trantinyurlaccessinfoEntity> oblist = await BFC.Core.FacadeCreatorObjects.General.trantinyurlaccessinfoFCC.GetFacadeCreate(_contextAccessor)
                .GAPgListView(message.Objtrantinyurlaccessinfo, cancellationToken);
                if (oblist != null && oblist.Count > 0)
                {
                    List<dataTableButtonModel> btnActionList = new List<dataTableButtonModel>();
                    //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.New_GET));
                    btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.Edit_GET));
                    btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.Delete_GET));
                    btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.GetSingle_GET));
                    //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.CUSTOM, _sharedLocalizer["PROCESS"], "StpOrganizationEntity/userprocess"));
                    //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.CUSTOM, _sharedLocalizer["SEARCH"], "StpOrganizationEntity/usersearch"));
                    
                    var data = (from t in oblist
                                select new
                                {
									 t.tinyurlacceessid,
									 t.tinyurlid,
									 t.otisused,
									 t.otusedtime,
									 t.otusedfromip,                                    datatablebuttonscode = objDTBtnPanel.genDTBtnPanel(message.Objtrantinyurlaccessinfo.ControllerName, t.tinyurlacceessid, "tinyurlacceessid", _contextAccessor.HttpContext.User.Identity as ClaimsIdentity, btnActionList, _contextAccessor)
                                }).ToList();

                    outputPort.GetListView(new TranTinyURLAccessInfoResponse(new AjaxResponse(oblist[0].RETURN_KEY, data), true, null));
                    return true;
                }
                else
                {
                 TranTinyURLAccessInfoResponse objResponse = new TranTinyURLAccessInfoResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
                     "404",
                     _sharedLocalizer["NO_DATA_FOUND"]));
                    _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                    outputPort.GetListView(objResponse);
                    return false;
                }
            }
            catch (Exception ex)
            {
                TranTinyURLAccessInfoResponse objResponse = new TranTinyURLAccessInfoResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetListView(objResponse);
                return true;
            }
        }

        public async Task<bool> GetSingle(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {
                trantinyurlaccessinfoEntity objSingle = await BFC.Core.FacadeCreatorObjects.General.trantinyurlaccessinfoFCC.GetFacadeCreate(_contextAccessor)
                .GetSingle(message.Objtrantinyurlaccessinfo, cancellationToken);
                if (objSingle != null)
                {
                    outputPort.GetSingle(new TranTinyURLAccessInfoResponse(objSingle, true));
                    return true;
                }
                else
                {
                    TranTinyURLAccessInfoResponse objResponse = new TranTinyURLAccessInfoResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
                     "404",
                     _sharedLocalizer["NO_DATA_FOUND"]));
                    _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                    outputPort.GetSingle(objResponse);
                    return false;
                }
            }
            catch (Exception ex)
            {
                TranTinyURLAccessInfoResponse objResponse = new TranTinyURLAccessInfoResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetSingle(objResponse);
                return true;
            }
        }

        public async Task<bool> Save(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(message));
            CancellationToken cancellationToken = new CancellationToken();
            long? i = null;
            try
            {
                i = await BFC.Core.FacadeCreatorObjects.General.trantinyurlaccessinfoFCC.GetFacadeCreate(_contextAccessor)
                    .Add(message.Objtrantinyurlaccessinfo, cancellationToken);
                    
                outputPort.Save(new TranTinyURLAccessInfoResponse(new AjaxResponse("200", _sharedLocalizer["DATA_SAVE_CONFIRMATION"].Value, CLL.LLClasses._Status._statusSuccess, CLL.LLClasses._Status._titleInformation, "/"
                ), true, null));
                return true;
            }
            catch (Exception ex)
            {
                TranTinyURLAccessInfoResponse objResponse = new TranTinyURLAccessInfoResponse(false, _sharedLocalizer["DATA_SAVE_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.Save(objResponse);
                return true;
            }
        }

        public async Task<bool> Update(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            long? i = null;
            try
            {
                i = await BFC.Core.FacadeCreatorObjects.General.trantinyurlaccessinfoFCC.GetFacadeCreate(_contextAccessor)
                    .Update(message.Objtrantinyurlaccessinfo, cancellationToken);
                
                outputPort.Update(new TranTinyURLAccessInfoResponse(new AjaxResponse("200", _sharedLocalizer["DATA_UPDATE_CONFIRMATION"].Value, CLL.LLClasses._Status._statusSuccess, CLL.LLClasses._Status._titleInformation, "/"
                        ), true, null));
                return true;
            }
            catch (Exception ex)
            {
                TranTinyURLAccessInfoResponse objResponse = new TranTinyURLAccessInfoResponse(false, _sharedLocalizer["DATA_UPDATE_ERROR"], new Error(
                       "500",
                       ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.Update(objResponse);
                return true;
            }
        }

        public async Task<bool> Delete(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            long? i = null;
            try
            {
                i = await BFC.Core.FacadeCreatorObjects.General.trantinyurlaccessinfoFCC.GetFacadeCreate(_contextAccessor)
                    .Delete(message.Objtrantinyurlaccessinfo, cancellationToken);
                outputPort.Delete(new TranTinyURLAccessInfoResponse(new AjaxResponse("200", _sharedLocalizer["DATA_DELETE_CONFIRMATION"].Value, CLL.LLClasses._Status._statusSuccess, CLL.LLClasses._Status._titleInformation, "/"
                       ), true, null));
                return true;
            }
            catch (Exception ex)
            {
                TranTinyURLAccessInfoResponse objResponse = new TranTinyURLAccessInfoResponse(false, _sharedLocalizer["DATA_DELETE_ERROR"], new Error(
                         "500",
                         ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.Delete(objResponse);
                return true;
            }
        }
        
        
        
        
        
    }
}