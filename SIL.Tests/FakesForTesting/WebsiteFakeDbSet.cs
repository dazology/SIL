using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.Domain;

namespace SIL.Tests
{
    public class WebsiteFakeDbSet : FakeDbSet<Website>
    {
        public override Website Find(params object[] keyValues)
        {
            var keyValue = (int)keyValues.FirstOrDefault();
            return this.SingleOrDefault(w => w.WebsiteId == keyValue);
        }
    }
}
