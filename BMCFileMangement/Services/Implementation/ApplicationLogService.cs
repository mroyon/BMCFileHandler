using BMCFileMangement.forms;
using BMCFileMangement.Models;
using BMCFileMangement.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMCFileMangement.Services.Implementation
{
    public class ApplicationLogService : IApplicationLogService
    {
        private readonly IConfigurationRoot _config;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<ApplicationLogService> _logger;

        public ApplicationLogService(
             IConfigurationRoot config,
            ILoggerFactory loggerFactory)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<ApplicationLogService>();
        }

        public void SetLog(string msg)
        {
            _logger.LogInformation(msg + " logged at: " + DateTimeOffset.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }
    }
}
