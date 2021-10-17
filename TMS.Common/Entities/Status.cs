using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Common.Entities
{
    [Description("To Store the Status")]
    [Table ("Status")]
   public class Status
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
