using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Scheduler.Contracts;
using Scheduler.DataBase;

namespace Scheduler.Service.Services
{
    
    public interface ISchedulerService
    {
        Task StartAsync(CancellationToken token);
        Task StopAsync(CancellationToken token);
        Task QueueWorkItemAsync(WorkItem item, CancellationToken token);
        Task DequeueWorkItemAsync(WorkItem item, CancellationToken token);
    }

    public class SchedulerService : /*ISchedulerService,*/ IHostedService
    {

        private SchedulerContext _context;
        private CancellationToken _token;

        public SchedulerService(SchedulerContext context)
        {
            _context = context;
        }

        public async Task StartAsync(CancellationToken token)
        {
            _token = token;
            await FindPreparedToRunWorkItems();
        }

        private Task FindPreparedToRunWorkItems()
        {
            while (_token.IsCancellationRequested)
            {
                foreach(var workItem in _context.WorkItems.Where(x => x.Status == WorkItemStatus.Prepared && x.StartTime <= DateTime.Now))
                {

                }
            }
        }

        public async Task StopAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
