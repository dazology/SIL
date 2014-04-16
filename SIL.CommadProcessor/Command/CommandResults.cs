using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL.CommadProcessor.Command
{
    public class CommandResults : ICommandResults
    {
        private readonly List<ICommandResult> results = new List<ICommandResult>();
        private bool p;

        public CommandResults(bool p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public void AddResult(ICommandResult result)
        {
            this.results.Add(result);
        }

        public ICommandResult[] Results
        {
            get
            {
                return this.results.ToArray();
            }
        }

        public bool Success
        {
            get
            {
                return this.results.All<ICommandResult>(result => result.Success);
            }
        }
    }
}
