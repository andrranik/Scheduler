using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Scheduler.Contracts
{
    public class WorkItemFilter
    {
        public ICollection<int> Ids { get; set; }
        public ICollection<WorkItemStatus> Statuses { get; set; }
        public ICollection<WorkItemExecutionType> ExecutionTypes { get; set; }

        public Func<WorkItem, bool> GetPredicate()
        {
            return x =>
            {
                bool result = true;
                if (Ids != null)
                    result = Ids.Contains(x.Id);
                if (Statuses != null)
                    result = result && Statuses.Contains(x.Status);
                if (ExecutionTypes != null)
                    result = result && ExecutionTypes.Contains(x.ExecutionType);
                return result;
            };
        }
    }
}
