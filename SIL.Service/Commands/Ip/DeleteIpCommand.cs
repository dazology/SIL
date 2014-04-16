using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;

namespace SIL.Service.Commands.Ip
{
    public class DeleteIpCommand : ICommand
    {
        public int IpId { get; set; }
    }
}
