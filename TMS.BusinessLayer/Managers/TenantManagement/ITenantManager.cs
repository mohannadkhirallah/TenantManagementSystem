using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.BusinessLayer.Core;
using TMS.Common.Entities;

namespace TMS.BusinessLayer.Managers.TenantManagement
{
    public interface ITenantManager :IActionManager
    {
        Tenant GetTenant(long tenantId);
    }
}
