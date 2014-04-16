using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIL.Web.ViewModels
{
    public class ReleaseViewModel
    {
        public int ReleaseId { get; set; }
    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        public DateTime LiveDate { get; set; }
  [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        public DateTime StagingDate { get; set; }
    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        public DateTime DevDate { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public StatusList Statuses { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Websites { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> RType { get; set; }

        public int ReleaseTypeId { get; set; }
        public int WebsiteId { get; set; }

        [MaxLength(10)]
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