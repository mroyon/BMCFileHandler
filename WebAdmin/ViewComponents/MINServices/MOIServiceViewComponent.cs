using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Web.Core.Frame.CustomIdentityManagers;
using CLL.Localization;
using BDO.Core.DataAccessObjects.ExtendedEntities;


namespace WebAdmin.ViewComponents
{
    /// <summary>
    /// MOIServiceViewComponent
    /// </summary>
    public class MOIServiceViewComponent : ViewComponent
    {
        private readonly ILogger<MOIServiceViewComponent> _logger;

        /// <summary>
        /// MOIServiceViewComponent
        /// </summary>
        public MOIServiceViewComponent(
            ILoggerFactory loggerFactory
            )
        {
            _logger = loggerFactory.CreateLogger<MOIServiceViewComponent>();
           
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="submitbutton"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(string headertag)
        {
            return View("~/Views/Shared/Components/MINServices/MOIService/MOIService.cshtml");
        }

    }
}
