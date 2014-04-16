using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;

namespace SIL.Service.Commands.Checklist
{
    public class CreateOrUpdateChecklistCommand : ICommand
    {
        public int ChecklistId { get; set; }
        public int QuestionNo { get; set; }
        public string Question { get; set; }
        public string QuestionFieldType { get; set; }
        public FieldOptions QuestionFieldOptions { get; set; }

        public enum FieldOptions
        {
            MultipleChoice,
            MultipleOptions,
            SingleTextbox,
            MultipleTextboxes,
        }
    }
}
