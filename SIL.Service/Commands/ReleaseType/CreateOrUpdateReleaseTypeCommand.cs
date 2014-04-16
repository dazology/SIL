using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;

namespace SIL.Service.Commands.ReleaseType
{
    public class CreateOrUpdateReleaseTypeCommand : ICommand
    {
        public int ReleaseTypeId { get; set; }
        public string Name { get; set; }


        public CreateOrUpdateReleaseTypeCommand(int ReleaseTypeId, string Name)
        {
            this.ReleaseTypeId = ReleaseTypeId;
            this.Name = Name;
        }
    }
}
