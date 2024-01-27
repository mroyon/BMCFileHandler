using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using CLL.Localization;
using Web.Core.Frame.Interfaces.UseCases;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.Presenters;
using Microsoft.Extensions.Configuration;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.CommonEntities;
using WebAdmin.Providers;
using Newtonsoft.Json;
using System.Linq;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using Microsoft.Extensions.Options;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.UseCases;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace WebAdmin.Controllers
{
    /// <summary>
    /// TranTinyURLDataController
    /// </summary>
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class TranTinyURLDataController : BaseController
    {
        private readonly ITranTinyURLDataUseCase _trantinyurldata_UseCase;
        private readonly TranTinyURLDataPresenter _trantinyurldata_Presenter;
        private readonly IGen_ServiceInfoUseCase _gen_ServiceInfoUseCase;
        private readonly Gen_ServiceInfoPresenter _gen_ServiceInfoPresenter;
        private readonly ICacheProvider _cacheProvider;
        private readonly IOptions<ApplicationGlobalSettings> _applicationGlobalSettings;
		private readonly TinyURLPassThroughSettings _tinyURLPassThroughSettings;





		private readonly ILogger<TranTinyURLDataController> _logger;
        private readonly IStringLocalizer _sharedLocalizer;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        
        
        //to Enable SignalR Inj
        //private readonly IHubContext<HubUserContext> _hubuserContext;
        //private readonly IUserConnectionManager _userConnectionManager;

        /// <summary>
        /// _configuration
        /// </summary>
        public IConfiguration _configuration { get; }

        /// <summary>
        /// TranTinyURLDataController
        /// </summary>
        /// <param name="trantinyurldata_UseCase"></param>
        /// <param name="trantinyurldata_Presenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>        
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>
       
        public TranTinyURLDataController(
            ITranTinyURLDataUseCase trantinyurldata_UseCase,
            TranTinyURLDataPresenter trantinyurldata_Presenter,
            IGen_ServiceInfoUseCase gen_ServiceInfoUseCase,
            Gen_ServiceInfoPresenter gen_ServiceInfoPresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider
            //,IHubContext<HubUserContext> hubuserContext
            //,IUserConnectionManager userConnectionManager
            ,ICacheProvider cacheProvider,
            IOptions<ApplicationGlobalSettings> applicationGlobalSettings, IConfiguration config



			)
        {
            _trantinyurldata_UseCase = trantinyurldata_UseCase;
            _trantinyurldata_Presenter = trantinyurldata_Presenter;
            _gen_ServiceInfoUseCase = gen_ServiceInfoUseCase;
            _gen_ServiceInfoPresenter = gen_ServiceInfoPresenter;
            _logger = loggerFactory.CreateLogger<TranTinyURLDataController>();
            _schemeProvider = schemeProvider;


			_configuration = config;
			_applicationGlobalSettings = applicationGlobalSettings;
			_tinyURLPassThroughSettings = config.GetSection(nameof(TinyURLPassThroughSettings)).Get<TinyURLPassThroughSettings>();



			//_hubuserContext = hubuserContext;
			//_userConnectionManager = userConnectionManager;
			_cacheProvider = cacheProvider;
            
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }


        /// <summary>
        /// LandingTranTinyURLData
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingTranTinyURLData(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/TranTinyURLData/LandingTranTinyURLData", new trantinyurldataEntity());
        }

        /// <summary>
        /// ListTranTinyURLData
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListTranTinyURLData(DtParameters request)
        {
            try
            {
                var draw = request.Draw;
                trantinyurldataEntity objrequest = new trantinyurldataEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression = request.SortOrder + " " + request.Order[0].Dir;
                objrequest.strCommonSerachParam = request.Search.Value;
                objrequest.ControllerName = "TranTinyURLData";
                await _trantinyurldata_UseCase.GetListView(new TranTinyURLDataRequest(objrequest), _trantinyurldata_Presenter);
                return Json(_trantinyurldata_Presenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get View AddTranTinyURLData
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddTranTinyURLData(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/TranTinyURLData/AddTranTinyURLData", new trantinyurldataEntity());
        }

        /// <summary>
        /// POST AddTranTinyURLData
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTranTinyURLData([FromBody] trantinyurldataEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            
            await _trantinyurldata_UseCase.Save(new TranTinyURLDataRequest(request), _trantinyurldata_Presenter);
            return _trantinyurldata_Presenter.ContentResult;
        }

        /// <summary>
        /// Get View EditTranTinyURLData
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditTranTinyURLData([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            trantinyurldataEntity objEntity = new trantinyurldataEntity();
            objEntity.tinyurlid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("tinyurlid", input).ToString());
            await _trantinyurldata_UseCase.GetSingle(new TranTinyURLDataRequest(objEntity), _trantinyurldata_Presenter);
            objEntity = _trantinyurldata_Presenter.Result as trantinyurldataEntity;

            if (objEntity!= null && objEntity.serviceid != null)
            {
                gen_serviceinfoEntity objServicerEntity = new gen_serviceinfoEntity();
                objServicerEntity.serviceid = objEntity.serviceid;
                await _gen_ServiceInfoUseCase.GetSingle(new Gen_ServiceInfoRequest(objServicerEntity), _gen_ServiceInfoPresenter);
                objServicerEntity = _gen_ServiceInfoPresenter.Result as gen_serviceinfoEntity;
                var dataService = new { Id = objServicerEntity.serviceid, Text = objServicerEntity.servicear };
                ViewBag.preloadedDataService = JsonConvert.SerializeObject(dataService);
            }

            return View("../General/TranTinyURLData/EditTranTinyURLData", _trantinyurldata_Presenter.Result);
        }

        /// <summary>
        /// Post EditTranTinyURLData
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTranTinyURLData([FromBody] trantinyurldataEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _trantinyurldata_UseCase.Update(new TranTinyURLDataRequest(request), _trantinyurldata_Presenter);
            return _trantinyurldata_Presenter.ContentResult;
        }

        /// <summary>
        /// Get View GetSingleTranTinyURLData
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleTranTinyURLData([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            trantinyurldataEntity objEntity = new trantinyurldataEntity();
            objEntity.tinyurlid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("tinyurlid", input).ToString());
            await _trantinyurldata_UseCase.GetSingle(new TranTinyURLDataRequest(objEntity), _trantinyurldata_Presenter);
            objEntity = _trantinyurldata_Presenter.Result as trantinyurldataEntity;

            if (objEntity != null && objEntity.serviceid != null)
            {
                gen_serviceinfoEntity objServicerEntity = new gen_serviceinfoEntity();
                objServicerEntity.serviceid = objEntity.serviceid;
                await _gen_ServiceInfoUseCase.GetSingle(new Gen_ServiceInfoRequest(objServicerEntity), _gen_ServiceInfoPresenter);
                objServicerEntity = _gen_ServiceInfoPresenter.Result as gen_serviceinfoEntity;
                var dataService = new { Id = objServicerEntity.serviceid, Text = objServicerEntity.servicear };
                ViewBag.preloadedDataService = JsonConvert.SerializeObject(dataService);
            }

            return View("../General/TranTinyURLData/GetSingleTranTinyURLData", objEntity);
        }

        /// <summary>
        /// Get View DeleteTranTinyURLData
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteTranTinyURLData([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            trantinyurldataEntity objEntity = new trantinyurldataEntity();
            objEntity.tinyurlid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("tinyurlid", input).ToString());
            await _trantinyurldata_UseCase.GetSingle(new TranTinyURLDataRequest(objEntity), _trantinyurldata_Presenter);
            objEntity = _trantinyurldata_Presenter.Result as trantinyurldataEntity;
            
            
            
            return View("../General/TranTinyURLData/DeleteTranTinyURLData", _trantinyurldata_Presenter.Result);
        }

        /// <summary>
        /// Post DeleteTranTinyURLData
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteTranTinyURLData([FromBody] trantinyurldataEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
           /*				 ModelState.Remove("tinyurlid");
				 ModelState.Remove("tinyurl");
				 ModelState.Remove("tinyurlcode");
				 ModelState.Remove("actualurl");
				 ModelState.Remove("serviceid");
				 ModelState.Remove("isactive");
				 ModelState.Remove("otisonetime");
				 ModelState.Remove("otisused");
				 ModelState.Remove("otusedtime");
				 ModelState.Remove("otusedfromip");
*/
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _trantinyurldata_UseCase.Delete(new TranTinyURLDataRequest(request), _trantinyurldata_Presenter);
            return _trantinyurldata_Presenter.ContentResult;
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetURLShortCode(string serviceid)
        {
			trantinyurldataEntity objEntity = new trantinyurldataEntity();
			try
            {
				AppConfig.HelperClasses.transactioncodeGen codeGen = new AppConfig.HelperClasses.transactioncodeGen();
				AppConfig.EncryptionHandler.EncryptionHelper objEnc = new AppConfig.EncryptionHandler.EncryptionHelper();
				await Task.Delay(300);

                string _serviceid = !string.IsNullOrEmpty(serviceid) ? serviceid : "-99";
				DateTime dot = DateTime.Now;
				objEntity.tinyurlcode = codeGen.GetRandomAlphaNumericStringForTransactionActivity("TNU", dot) + "|" + _serviceid;
				objEntity.tinyurlcode = objEnc.base64Encode(objEntity.tinyurlcode);
				objEntity.tinyurl = _tinyURLPassThroughSettings.WebApiAddress + objEntity.tinyurlcode;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
            return Json(objEntity);
        }
        
        
    }
}
