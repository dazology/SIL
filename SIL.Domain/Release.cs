using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SIL.Domain
{
    public class Release
    {
        public int ReleaseId { get; set; }
        public int ReleaseTypeId { get; set; }
        [MaxLength(10)]
        public string BuildVersionNo { get; set; }
        public string ReleaseDescription1 { get; set; }
        public string ReleaseDescription2 { get; set; }
        public string ReleaseDescription3 { get; set; }
        public string DbVersionNo { get; set; }
        public DateTime DevDate { get; set; }
        public DateTime StagingDate { get; set; }
        public DateTime LiveDate { get; set; }
        public string Notes { get; set; }
        public string ReleaseStatus { get; set; }
        public int WebsiteId { get; set; }
        public bool Build { get; set; }
        public bool DB { get; set; }
        public bool Script { get; set; }
        public bool Design { get; set; }
        public bool Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public Release()
        {

        }


        public enum Status
        {
            prerelease =  1,
            release = 2
        }
    }
}
