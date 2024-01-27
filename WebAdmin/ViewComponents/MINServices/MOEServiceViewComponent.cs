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
    /// MOEServiceViewComponent
    /// </summary>
    public class MOEServiceViewComponent : ViewComponent
    {
        private readonly ILogger<MOEServiceViewComponent> _logger;

        /// <summary>
        /// MOEServiceViewComponent
        /// </summary>
        public MOEServiceViewComponent(
            ILoggerFactory loggerFactory
            )
        {
            _logger = loggerFactory.CreateLogger<MOEServiceViewComponent>();
           
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="submitbutton"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(string headertag)
        {
            return View("~/Views/Shared/Components/MINServices/MOEService/MOEService.cshtml");
        }

    }
}
