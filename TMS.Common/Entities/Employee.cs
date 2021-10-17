using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Common.Core;

namespace TMS.Common.Entities
{
    [Description("To store Employee information")]
    [Table("Employee")]
    public class Employee : BaseEntity
    {
        [Key]
        public long ID { get; set; }

        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string PhoneNo { get; set; }

        [MaxLength(50)]
        public string MobileNo { get; set; }

    }
}
