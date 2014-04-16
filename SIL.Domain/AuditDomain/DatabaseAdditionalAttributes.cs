using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL.Domain.AuditDomain
{
    public class DatabaseAdditionalAttributes
    {

        [Key]
        public System.Guid DatabaseAdditionalAttributeID { get; set; }

        [Required]
        public System.Guid DatabaseId { get; set; }

        [Required]
        [MaxLength(50)]
        public string AttributeName { get; set; }

        [MaxLength(500)]
        public string AttributeValue { get; set; }

        [ForeignKey("DatabaseId")]
        public virtual Website Item { get; set; }
    }
}
