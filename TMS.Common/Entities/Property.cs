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
    [Description("To store Property information")]
    [Table("Property")]
    public class Property:BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
    }
}
