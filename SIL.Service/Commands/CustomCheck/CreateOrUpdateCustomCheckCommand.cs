using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;

namespace SIL.Service.Commands.CustomChecks
{
    public class CreateOrUpdateCustomCheckCommand : ICommand
    {
        public int CustomChecksId { get; set; }
        public int WebsiteId { get; set; }
        public int OrderNo { get; set; }
        public string Question { get; set; }
        public string QuestionFieldType { get; set; }
    }
}
