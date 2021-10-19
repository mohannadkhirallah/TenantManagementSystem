using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.BusinessLayer.Core;
using TMS.Common.BusinessObjects;

namespace TMS.BusinessLayer.Managers.ServiceRequestManagement
{
   public interface IServiceRequestManager :IActionManager
    {
        IEnumerable<TenantServiceRequest> GetAllTenantServiceRequests();
    }
}
