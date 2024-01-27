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
    /// PUCFinancialServiceViewComponent
    /// </summary>
    public class PUCFinancialServiceViewComponent : ViewComponent
    {
        private readonly ILogger<PUCFinancialServiceViewComponent> _logger;

        /// <summary>
        /// PUCFinancialServiceViewComponent
        /// </summary>
        public PUCFinancialServiceViewComponent(
            ILoggerFactory loggerFactory
            )
        {
            _logger = loggerFactory.CreateLogger<PUCFinancialServiceViewComponent>();
           
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="submitbutton"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(string headertag)
        {
            return View("~/Views/Shared/Components/MINServices/PUCFinancialService/PUCFinancialService.cshtml");
        }

    }
}
