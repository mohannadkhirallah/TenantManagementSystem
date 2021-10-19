using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TMS.BusinessLayer.Core;
using TMS.Common.Facade;

namespace TMS.ServiceApp.Controllers
{
    public class BaseController : Controller
    {
        private readonly IActionManager manager;
        private readonly ILogger logger;

        public BaseController(IActionManager manager, ILogger logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        public IActionManager ActionManager { get { return manager; } }
        public ILogger  Logger { get { return logger; } }

        public HttpResponseException LogException(Exception ex)
        {
            string errorMessage = LoggerHelper.GetExceptionDetails(ex);
            logger.LogError(LoggingEvents.SERVICE_ERROR, ex, errorMessage);
            HttpResponseMessage message = new HttpResponseMessage();
            message.Content = new StringContent(errorMessage);
            message.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
            throw new HttpResponseException(message);
        }
    }
}
