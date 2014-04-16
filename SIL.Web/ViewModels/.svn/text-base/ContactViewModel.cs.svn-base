using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIL.Web.ViewModels
{
    public class ContactViewModel    
    {
        public int ContactId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsSecondary { get; set; }
        public ContactType Type { get; set; }
        public IEnumerable<SelectListItem> Customers{ get; set; }    
        public enum ContactType
        {
            Website,
            Account,
            Support,
        }          
    }
}
