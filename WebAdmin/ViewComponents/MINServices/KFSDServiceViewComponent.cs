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
    /// KFSDServiceViewComponent
    /// </summary>
    public class KFSDServiceViewComponent : ViewComponent
    {
        private readonly ILogger<KFSDServiceViewComponent> _logger;

        /// <summary>
        /// KFSDServiceViewComponent
        /// </summary>
        public KFSDServiceViewComponent(
            ILoggerFactory loggerFactory
            )
        {
            _logger = loggerFactory.CreateLogger<KFSDServiceViewComponent>();
           
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="submitbutton"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(string headertag)
        {
            return View("~/Views/Shared/Components/MINServices/KFSDService/KFSDService.cshtml");
        }

    }
}
