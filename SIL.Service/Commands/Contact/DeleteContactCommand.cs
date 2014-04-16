using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;

namespace SIL.Service.Commands.Contact
{
     public class DeleteContactCommand : ICommand
    {
         public int ContacId { get; set; }
    }
}
