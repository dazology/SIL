using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIL.Domain
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string TelNo { get; set; }
        public string JobTitle { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsSecondary { get; set; }
        public ContactType Type { get; set; }

        public Contact()
        {

        }

        public enum ContactType
        {
            Website,
            Account,
            Support,
        }


    }
}
