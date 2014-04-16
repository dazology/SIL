using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL.Domain.AuditDomain
{
   public class WebsiteAdditionalAttributes
    {
        [Key]
        public System.Guid WebsiteAdditionalAttributeID { get; set; }

        [Required]
        public System.Guid WebsiteID { get; set; }

        [Required]
        [MaxLength(50)]
        public string AttributeName { get; set; }

        [MaxLength(500)]
        public string AttributeValue { get; set; }

        [ForeignKey("WebsiteId")]
        public virtual Website Item { get; set; }


    }
}
