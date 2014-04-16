using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;

namespace SIL.Service.Commands.Company
{
    public class DeleteCustomerCommand : ICommand
    {
        public int CustomerId { get; set; }
    }
}
