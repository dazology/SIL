using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;

namespace SIL.Service.Commands.Contact
{
    public class CreateOrUpdateContactCommand : ICommand
    {
        public int ContactId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsSecondary { get; set; }

        public CreateOrUpdateContactCommand(int ContactId, int CustomerId, string Name, string EmailAddress, bool IsPrimary, bool IsSecondary)
        {
            this.ContactId = ContactId;
            this.CustomerId = CustomerId;
            this.Name = Name;
            this.EmailAddress = EmailAddress;
            this.IsPrimary = IsPrimary;
            this.IsSecondary = IsSecondary;

        }
   
    }
}
