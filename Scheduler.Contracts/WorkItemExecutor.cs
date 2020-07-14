using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Contracts
{
    public class WorkItemExecutor
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string EntryMethodName { get; set; }

        public string Source { get; set; }

        public byte[] SourceCompiled { get; set; }

        public ICollection<WorkItem> WorkItems { get; set; }
    }
}