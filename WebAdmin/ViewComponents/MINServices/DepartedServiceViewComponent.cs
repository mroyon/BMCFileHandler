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
    /// DepartedServiceViewComponent
    /// </summary>
    public class DepartedServiceViewComponent : ViewComponent
    {
        private readonly ILogger<DepartedServiceViewComponent> _logger;

        /// <summary>
        /// DepartedServiceViewComponent
        /// </summary>
        public DepartedServiceViewComponent(
            ILoggerFactory loggerFactory
            )
        {
            _logger = loggerFactory.CreateLogger<DepartedServiceViewComponent>();
           
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="submitbutton"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(string headertag)
        {
            return View("~/Views/Shared/Components/MINServices/DepartedService/DepartedService.cshtml");
        }

    }
}
