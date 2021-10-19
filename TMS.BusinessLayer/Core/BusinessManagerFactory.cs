using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.BusinessLayer.Managers.ServiceRequestManagement;
using TMS.BusinessLayer.Managers.TenantManagement;

namespace TMS.BusinessLayer.Core
{
    public class BusinessManagerFactory
    {
        private readonly TenantManager _tenantManager;
        private readonly IServiceRequestManager _serviceRequestManager;

        public BusinessManagerFactory(TenantManager tenantManager, IServiceRequestManager  serviceRequestManager)
        {
            this._tenantManager = tenantManager;
            this._serviceRequestManager = serviceRequestManager;
        }

        public IServiceRequestManager GetServiceRequestManager()
        {
            return _serviceRequestManager;
        }
        public ITenantManager GetTenantManager()
        {
            return _tenantManager;
        }
    }
}
