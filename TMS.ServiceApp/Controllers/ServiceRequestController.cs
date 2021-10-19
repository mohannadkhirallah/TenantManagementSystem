using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.BusinessLayer.Managers.ServiceRequestManagement;
using TMS.Common.BusinessObjects;
using TMS.Common.Entities;
using TMS.ServiceApp.Filters;

namespace TMS.ServiceApp.Controllers
{
    [LoggingActionFilter]
    [Route("api/[controller]")]
    public class ServiceRequestController : BaseController
    {
        private readonly IServiceRequestManager _manager;
        private readonly ILogger<ServiceRequestController> _logger;

        public ServiceRequestController(IServiceRequestManager manager, ILogger<ServiceRequestController> logger)
            :base(manager,logger)
        {
            this._manager = manager;
            this._logger = logger;
        }

        [TransactionActionFilter]
        [HttpPost]
        public void Post(ServiceRequest serviceRequest)
        {
            try
            {
                _manager.Create(serviceRequest);
            }
            catch (Exception ex)
            {
                throw LogException(ex);
            }
        }

        [HttpGet]
        public IEnumerable<TenantServiceRequest> GetTenantsRequests()
        {
            return _manager.GetAllTenantServiceRequests();
        }
    }
}
