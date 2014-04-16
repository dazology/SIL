using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;

namespace SIL.Service.Commands.Release
{
   public class DeleteReleaseCommand : ICommand
   {
       public int ReleaseHistoryId { get; set; }
    }
}
