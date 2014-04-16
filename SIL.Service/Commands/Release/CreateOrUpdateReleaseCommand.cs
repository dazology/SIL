using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;

namespace SIL.Service.Commands.Release
{
    public class CreateOrUpdateReleaseCommand : ICommand
    {
        public int ReleaseId { get; set; }
        public int ReleaseTypeId { get; set; }
        public int WebsiteId { get; set; }
        public DateTime DevDate { get; set; }
        public DateTime StagingDate { get; set; }
        public DateTime LiveDate { get; set; }
        public string Notes { get; set; }
        public string ReleaseStatus { get; set; }
        public StatusList Statuses { get; set; }
        public string BuildVersionNo { get; set; }
        public string ReleaseDescription1 { get; set; }
        public string ReleaseDescription2 { get; set; }
        public string ReleaseDescription3 { get; set; }
        public string DbVersionNo { get; set; }
        public bool Build { get; set; }
        public bool DB { get; set; }
        public bool Script { get; set; }
        public bool Design { get; set; }
        public bool Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public enum StatusList
        {
            prerelease = 1,
            release = 2
        }

    }
}
