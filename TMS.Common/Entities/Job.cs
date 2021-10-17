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
    [Description("To store Job Information")]
    [Table("Job")]
    public class Job : BaseEntity
    {
        [Key]
        public long ID { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int StatusID { get; set; }

        [ForeignKey("StatusID")]
        public Status Status { get; set; }

    }
}
