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
    /// CivilServiceCommViewComponent
    /// </summary>
    public class CivilServiceCommViewComponent : ViewComponent
    {
        private readonly ILogger<CivilServiceCommViewComponent> _logger;

        /// <summary>
        /// CivilServiceCommViewComponent
        /// </summary>
        public CivilServiceCommViewComponent(
            ILoggerFactory loggerFactory
            )
        {
            _logger = loggerFactory.CreateLogger<CivilServiceCommViewComponent>();
           
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="submitbutton"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(string headertag)
        {
            return View("~/Views/Shared/Components/MINServices/CivilServiceComm/CivilServiceComm.cshtml");
        }

    }
}
