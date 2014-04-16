using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SIL.Domain
{
   public class ChecklistQuestion
    {
       public virtual ICollection<Checklist> Checklists { get; set; }
       public int ChecklistQuestionId { get; set; }
       public string Question { get; set; }
       public string QuestionFieldType { get; set; }
       public string QuestionDescription { get; set; }
       public int OrderNo { get; set; }
    }
}
