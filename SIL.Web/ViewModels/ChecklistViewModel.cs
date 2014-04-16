using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIL.Web.ViewModels
{
    public class ChecklistViewModel
    {
        public int ChecklistId { get; set; }
        public int ReleaseTypeId { get; set; }
        public IEnumerable<SelectListItem> ReleaseTypes { get; set; }
        public int OrderNo { get; set; }
        public string Question { get; set; }
        public string QuestionFieldType { get; set; }
        public FieldOptions QuestionFieldOptions { get; set; }

        public enum FieldOptions
        {
            MultipleChoice,
            MultipleOptions,
            [Description("Single Textbox")]
            SingleTextbox,
            MultipleTextboxes,            
        }
    }
}