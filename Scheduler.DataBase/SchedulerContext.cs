using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Scheduler.Contracts;

namespace Scheduler.DataBase
{
    public class SchedulerContext : DbContext
    {
        public SchedulerContext(DbContextOptions<SchedulerContext> options)
            : base(options)
        {
            
        }

        public DbSet<WorkItem> WorkItems { get; set; }
    }
}
