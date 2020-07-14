using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Scheduler.Contracts
{
    [Table("WorkItems")]
    public class WorkItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public WorkItemStatus Status { get; set; }
        [Required]
        public WorkItemExecutionType ExecutionType { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? LastRunTime { get; set; }
        public float? Interval { get; set; }
        public IntervalType? IntervalType { get; set; }
        //public WorkItemExecutor Executor { get; set; }
    }

    public enum WorkItemStatus
    {
        Prepared = 0,
        Processing,
        Processed,
        Cancelled,
        Deleted,
        Failed
    }

    public enum WorkItemExecutionType
    {
        OneTime = 0,
        Repeat
    }

    public enum IntervalType
    {
        Milliseconds = 0,
        Seconds,
        Minutes,
        Hours,
        Days,
        Weeks,
        Month,
        Years
    }
}
