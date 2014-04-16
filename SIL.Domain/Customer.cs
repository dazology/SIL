using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SIL.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Website> Websites { get; set; }
        [NotMapped]
        public Contact Contact { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string PostCode { get; set; }

        public Customer()
        {
            
          
        }
    }
}
