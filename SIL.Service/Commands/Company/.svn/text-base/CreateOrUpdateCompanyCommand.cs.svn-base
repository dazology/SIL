using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;

namespace SIL.Service.Commands.Company
{
    public class CreateOrUpdateCompanyCommand : ICommand
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string PostCode { get; set; }


        public CreateOrUpdateCompanyCommand(int CustomerId, string Name, string Address1, string Address2, string Town, string City, string TelNo, string FaxNo)
        {
            this.CustomerId = CustomerId;
            //this.ContactId = ContactId;
            this.Name = Name;
            this.Address1 = Address1;
            this.Address2 = Address2;
            this.Town = Town;
            this.City = City;
            this.TelNo = TelNo;
            this.FaxNo = FaxNo;
        }
   
    }
}
