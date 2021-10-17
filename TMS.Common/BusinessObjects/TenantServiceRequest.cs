using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.Core;

namespace TMS.Common.BusinessObjects
{
    public class TenantServiceRequest:BaseEntity
    {
        public string Description { get; set; }
        public string EmployeeComments { get; set; }
        public string Status { get; set; }

        public long TenantID { get; set; }
        public string TenantName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
