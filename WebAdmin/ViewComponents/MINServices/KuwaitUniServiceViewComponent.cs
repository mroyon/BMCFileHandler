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
    /// KuwaitUniServiceViewComponent
    /// </summary>
    public class KuwaitUniServiceViewComponent : ViewComponent
    {
        private readonly ILogger<KuwaitUniServiceViewComponent> _logger;

        /// <summary>
        /// KuwaitUniServiceViewComponent
        /// </summary>
        public KuwaitUniServiceViewComponent(
            ILoggerFactory loggerFactory
            )
        {
            _logger = loggerFactory.CreateLogger<KuwaitUniServiceViewComponent>();
           
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="submitbutton"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(string headertag)
        {
            return View("~/Views/Shared/Components/MINServices/KuwaitUniService/KuwaitUniService.cshtml");
        }

    }
}
