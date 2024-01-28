﻿using CLL.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace WebAdmin.ViewComponents.Select2
{
    /// <summary>
    /// S2Owin_Role ViewComponent
    /// </summary>
    public class S2Owin_RoleViewComponent : ViewComponent
    {
        private readonly ILogger<S2Owin_RoleViewComponent> _logger;
        private readonly IStringLocalizer _sharedLocalizer;
        /// <summary>
        /// S2Gen_NewsCategoryViewComponent
        /// </summary>
        public S2Owin_RoleViewComponent(
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory
            )
        {
            _logger = loggerFactory.CreateLogger<S2Owin_RoleViewComponent>();
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }

        /// <summary>
        /// IViewComponentResult
        /// </summary>
        /// <param name="selectid"></param>
        /// <param name="preloaded"></param>
        /// <param name="isReadOnly"></param>
        /// <param name="multiple"></param>
        /// <param name="isRequired"></param>
        /// <param name="pkey"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(
            string selectid,
            string preloaded,
            bool isReadOnly = false,
            bool multiple = false,
            bool isRequired = false,
            int? pkey = null)
        {
            ViewBag.selectid = selectid;
            ViewBag.Owin_RoleData = preloaded;
            ViewBag.isReadOnly = isReadOnly;
            ViewBag.multiple = multiple;
            ViewBag.isRequired = isRequired;
            ViewBag.pkey = pkey == null ? "" : pkey.GetValueOrDefault().ToString();
            return View();
        }

    }
}