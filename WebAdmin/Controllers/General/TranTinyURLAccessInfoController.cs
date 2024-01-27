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

namespace WebAdmin.Controllers
{
    /// <summary>
    /// TranTinyURLAccessInfoController
    /// </summary>
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class TranTinyURLAccessInfoController : BaseController
    {
        private readonly ITranTinyURLAccessInfoUseCase _trantinyurlaccessinfo_UseCase;
        private readonly TranTinyURLAccessInfoPresenter _trantinyurlaccessinfo_Presenter;
        private readonly ICacheProvider _cacheProvider;


        
        

        private readonly ILogger<TranTinyURLAccessInfoController> _logger;
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
        /// TranTinyURLAccessInfoController
        /// </summary>
        /// <param name="trantinyurlaccessinfo_UseCase"></param>
        /// <param name="trantinyurlaccessinfo_Presenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>        
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>
       
        public TranTinyURLAccessInfoController(
            ITranTinyURLAccessInfoUseCase trantinyurlaccessinfo_UseCase,
            TranTinyURLAccessInfoPresenter trantinyurlaccessinfo_Presenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider
            //,IHubContext<HubUserContext> hubuserContext
            //,IUserConnectionManager userConnectionManager
            ,ICacheProvider cacheProvider
            
             
            )
        {
            _trantinyurlaccessinfo_UseCase = trantinyurlaccessinfo_UseCase;
            _trantinyurlaccessinfo_Presenter = trantinyurlaccessinfo_Presenter;
            _logger = loggerFactory.CreateLogger<TranTinyURLAccessInfoController>();
            _schemeProvider = schemeProvider;
            
            
             
             
             
            //_hubuserContext = hubuserContext;
            //_userConnectionManager = userConnectionManager;
            _cacheProvider = cacheProvider;
            
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }


        /// <summary>
        /// LandingTranTinyURLAccessInfo
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingTranTinyURLAccessInfo(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/TranTinyURLAccessInfo/LandingTranTinyURLAccessInfo", new trantinyurlaccessinfoEntity());
        }

        /// <summary>
        /// ListTranTinyURLAccessInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListTranTinyURLAccessInfo(DtParameters request)
        {
            try
            {
                var draw = request.Draw;
                trantinyurlaccessinfoEntity objrequest = new trantinyurlaccessinfoEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression = request.SortOrder + " " + request.Order[0].Dir;
                objrequest.strCommonSerachParam = request.Search.Value;
                objrequest.ControllerName = "TranTinyURLAccessInfo";
                await _trantinyurlaccessinfo_UseCase.GetListView(new TranTinyURLAccessInfoRequest(objrequest), _trantinyurlaccessinfo_Presenter);
                return Json(_trantinyurlaccessinfo_Presenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get View AddTranTinyURLAccessInfo
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddTranTinyURLAccessInfo(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/TranTinyURLAccessInfo/AddTranTinyURLAccessInfo", new trantinyurlaccessinfoEntity());
        }

        /// <summary>
        /// POST AddTranTinyURLAccessInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTranTinyURLAccessInfo([FromBody] trantinyurlaccessinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _trantinyurlaccessinfo_UseCase.Save(new TranTinyURLAccessInfoRequest(request), _trantinyurlaccessinfo_Presenter);
            return _trantinyurlaccessinfo_Presenter.ContentResult;
        }

        /// <summary>
        /// Get View EditTranTinyURLAccessInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditTranTinyURLAccessInfo([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            trantinyurlaccessinfoEntity objEntity = new trantinyurlaccessinfoEntity();
            objEntity.tinyurlacceessid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("tinyurlacceessid", input).ToString());
            await _trantinyurlaccessinfo_UseCase.GetSingle(new TranTinyURLAccessInfoRequest(objEntity), _trantinyurlaccessinfo_Presenter);
            objEntity = _trantinyurlaccessinfo_Presenter.Result as trantinyurlaccessinfoEntity;
            
            
            
            
            return View("../General/TranTinyURLAccessInfo/EditTranTinyURLAccessInfo", _trantinyurlaccessinfo_Presenter.Result);
        }

        /// <summary>
        /// Post EditTranTinyURLAccessInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTranTinyURLAccessInfo([FromBody] trantinyurlaccessinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _trantinyurlaccessinfo_UseCase.Update(new TranTinyURLAccessInfoRequest(request), _trantinyurlaccessinfo_Presenter);
            return _trantinyurlaccessinfo_Presenter.ContentResult;
        }

        /// <summary>
        /// Get View GetSingleTranTinyURLAccessInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleTranTinyURLAccessInfo([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            trantinyurlaccessinfoEntity objEntity = new trantinyurlaccessinfoEntity();
            objEntity.tinyurlacceessid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("tinyurlacceessid", input).ToString());
            await _trantinyurlaccessinfo_UseCase.GetSingle(new TranTinyURLAccessInfoRequest(objEntity), _trantinyurlaccessinfo_Presenter);
            objEntity = _trantinyurlaccessinfo_Presenter.Result as trantinyurlaccessinfoEntity;
            
            
            
            return View("../General/TranTinyURLAccessInfo/GetSingleTranTinyURLAccessInfo", _trantinyurlaccessinfo_Presenter.Result);
        }

        /// <summary>
        /// Get View DeleteTranTinyURLAccessInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteTranTinyURLAccessInfo([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            trantinyurlaccessinfoEntity objEntity = new trantinyurlaccessinfoEntity();
            objEntity.tinyurlacceessid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("tinyurlacceessid", input).ToString());
            await _trantinyurlaccessinfo_UseCase.GetSingle(new TranTinyURLAccessInfoRequest(objEntity), _trantinyurlaccessinfo_Presenter);
            objEntity = _trantinyurlaccessinfo_Presenter.Result as trantinyurlaccessinfoEntity;
            
            
            
            return View("../General/TranTinyURLAccessInfo/DeleteTranTinyURLAccessInfo", _trantinyurlaccessinfo_Presenter.Result);
        }

        /// <summary>
        /// Post DeleteTranTinyURLAccessInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteTranTinyURLAccessInfo([FromBody] trantinyurlaccessinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
           /*				 ModelState.Remove("tinyurlacceessid");
				 ModelState.Remove("tinyurlid");
				 ModelState.Remove("otisused");
				 ModelState.Remove("otusedtime");
				 ModelState.Remove("otusedfromip");
*/
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _trantinyurlaccessinfo_UseCase.Delete(new TranTinyURLAccessInfoRequest(request), _trantinyurlaccessinfo_Presenter);
            return _trantinyurlaccessinfo_Presenter.ContentResult;
        }
        
      
        
        
        
    }
}
