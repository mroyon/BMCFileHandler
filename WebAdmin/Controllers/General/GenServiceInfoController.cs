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
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.UseCases;
using BDO.DataAccessObjects.ExtendedEntities;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace WebAdmin.Controllers
{
    /// <summary>
    /// Gen_ServiceInfoController
    /// </summary>
    [Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class Gen_ServiceInfoController : BaseController
    {
        private readonly IGen_ServiceInfoUseCase _gen_ServiceInfoUseCase;
        private readonly Gen_ServiceInfoPresenter _gen_ServiceInfoPresenter;
        private readonly ICacheProvider _cacheProvider;





        private readonly ILogger<Gen_ServiceInfoController> _logger;
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
        /// Gen_ServiceInfoController
        /// </summary>
        /// <param name="gen_ServiceInfoUseCase"></param>
        /// <param name="gen_ServiceInfoPresenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>        
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>

        public Gen_ServiceInfoController(
            IGen_ServiceInfoUseCase gen_ServiceInfoUseCase,
            Gen_ServiceInfoPresenter gen_ServiceInfoPresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider
            //,IHubContext<HubUserContext> hubuserContext
            //,IUserConnectionManager userConnectionManager
            , ICacheProvider cacheProvider


            )
        {
            _gen_ServiceInfoUseCase = gen_ServiceInfoUseCase;
            _gen_ServiceInfoPresenter = gen_ServiceInfoPresenter;
            _logger = loggerFactory.CreateLogger<Gen_ServiceInfoController>();
            _schemeProvider = schemeProvider;





            //_hubuserContext = hubuserContext;
            //_userConnectionManager = userConnectionManager;
            _cacheProvider = cacheProvider;

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }


        /// <summary>
        /// LandingGen_ServiceInfo
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingGen_ServiceInfo(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) 
            {
                return RedirectToAction("Account", "Login"); 
            }
            return View("../General/Gen_ServiceInfo/LandingGen_ServiceInfo", new gen_serviceinfoEntity());
        }

        /// <summary>
        /// ListGen_ServiceInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListGen_ServiceInfo(DtParameters request)
        {
            try
            {
                var draw = request.Draw;
                gen_serviceinfoEntity objrequest = new gen_serviceinfoEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression = request.SortOrder + " " + request.Order[0].Dir;
                objrequest.strCommonSerachParam = request.Search.Value;
                objrequest.ControllerName = "Gen_ServiceInfo";
                await _gen_ServiceInfoUseCase.GetListView(new Gen_ServiceInfoRequest(objrequest), _gen_ServiceInfoPresenter);
                return Json(_gen_ServiceInfoPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get View AddGen_ServiceInfo
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddGen_ServiceInfo(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) 
            { 
                return RedirectToAction("Account", "Login"); 
            }
            return View("../General/Gen_ServiceInfo/AddGen_ServiceInfo", new gen_serviceinfoEntity());
        }

        /// <summary>
        /// POST AddGen_ServiceInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGen_ServiceInfo([FromBody] gen_serviceinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_ServiceInfoUseCase.Save(new Gen_ServiceInfoRequest(request), _gen_ServiceInfoPresenter);
            return _gen_ServiceInfoPresenter.ContentResult;
        }

        /// <summary>
        /// Get View EditGen_ServiceInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditGen_ServiceInfo([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_serviceinfoEntity objEntity = new gen_serviceinfoEntity();
            objEntity.serviceid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("serviceid", input).ToString());
            await _gen_ServiceInfoUseCase.GetSingle(new Gen_ServiceInfoRequest(objEntity), _gen_ServiceInfoPresenter);
            objEntity = _gen_ServiceInfoPresenter.Result as gen_serviceinfoEntity;

            return View("../General/Gen_ServiceInfo/EditGen_ServiceInfo", _gen_ServiceInfoPresenter.Result);
        }

        /// <summary>
        /// Post EditGen_ServiceInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGen_ServiceInfo([FromBody] gen_serviceinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_ServiceInfoUseCase.Update(new Gen_ServiceInfoRequest(request), _gen_ServiceInfoPresenter);
            return _gen_ServiceInfoPresenter.ContentResult;
        }

        /// <summary>
        /// Get View GetSingleGen_ServiceInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleGen_ServiceInfo([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_serviceinfoEntity objEntity = new gen_serviceinfoEntity();
            objEntity.serviceid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("serviceid", input).ToString());
            await _gen_ServiceInfoUseCase.GetSingle(new Gen_ServiceInfoRequest(objEntity), _gen_ServiceInfoPresenter);
            objEntity = _gen_ServiceInfoPresenter.Result as gen_serviceinfoEntity;



            return View("../General/Gen_ServiceInfo/GetSingleGen_ServiceInfo", _gen_ServiceInfoPresenter.Result);
        }

        /// <summary>
        /// Get View DeleteGen_ServiceInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_ServiceInfo([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_serviceinfoEntity objEntity = new gen_serviceinfoEntity();
            objEntity.serviceid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("serviceid", input).ToString());
            await _gen_ServiceInfoUseCase.GetSingle(new Gen_ServiceInfoRequest(objEntity), _gen_ServiceInfoPresenter);
            objEntity = _gen_ServiceInfoPresenter.Result as gen_serviceinfoEntity;

            return View("../General/Gen_ServiceInfo/DeleteGen_ServiceInfo", _gen_ServiceInfoPresenter.Result);
        }

        /// <summary>
        /// Post DeleteGen_ServiceInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_ServiceInfo([FromBody] gen_serviceinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            /*				 ModelState.Remove("serviceid");
                  ModelState.Remove("servicear");
                  ModelState.Remove("serviceen");
                  ModelState.Remove("descriptionar");
                  ModelState.Remove("descriptionen");
                  ModelState.Remove("isactive");
 */
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_ServiceInfoUseCase.Delete(new Gen_ServiceInfoRequest(request), _gen_ServiceInfoPresenter);
            return _gen_ServiceInfoPresenter.ContentResult;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetDataForDropDowndGen_ServiceInfo([FromBody] s2gen_serviceinfoEntity request)
        {
            try
            {
                gen_serviceinfoEntity objrequest = new gen_serviceinfoEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.s2PageNum.GetValueOrDefault(1);
                objrequest.PageSize = request.s2PageSize.GetValueOrDefault(10);
                objrequest.SortExpression = " serviceid asc ";
                objrequest.strCommonSerachParam = request.s2SearchTerm;
                objrequest.ControllerName = "Gen_ServiceInfo";

                objrequest.isactive = true;
                objrequest.isExt= request.IsMapped==true? true: (bool?)null;
                //objrequest. =new Guid( request.BaseSecurityParam.createdbyusername);
                await _gen_ServiceInfoUseCase.GetDataForDropDownMapped(new Gen_ServiceInfoRequest(objrequest), _gen_ServiceInfoPresenter);
                return Json(_gen_ServiceInfoPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetAllDataForDropDowndGen_ServiceInfo()
        {
            try
            {
                gen_serviceinfoEntity objrequest = new gen_serviceinfoEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                //objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage =1;
                objrequest.PageSize = 500;
                objrequest.SortExpression = " serviceid asc ";
                //objrequest.strCommonSerachParam = request.s2SearchTerm;
                objrequest.ControllerName = "Gen_ServiceInfo";

                objrequest.isactive = true;

                await _gen_ServiceInfoUseCase.GetDataForDropDown(new Gen_ServiceInfoRequest(objrequest), _gen_ServiceInfoPresenter);
                return Json(_gen_ServiceInfoPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}