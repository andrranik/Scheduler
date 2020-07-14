using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Contracts;
using Scheduler.DataBase;
using Scheduler.Service.Services;

namespace Scheduler.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly SchedulerContext _context;

        public WorkController( SchedulerContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<WorkItem> GetByIdAsync(int id)
        {
            return await _context.WorkItems.SingleAsync(x => x.Id == id);
        }

        [HttpGet]
        public async Task<IEnumerable<WorkItem>> GetByFilter([FromQuery]WorkItemFilter filter)
        {
            return _context.WorkItems.Where(filter.GetPredicate());
        }

        [HttpPost]
        public async Task<ActionResult<WorkItem>> AddWorkItemAsync(WorkItem workItem)
        {
            if (ModelState.IsValid)
            {
                await _context.WorkItems.AddAsync(workItem);
                await _context.SaveChangesAsync();
                return Ok(workItem);
            }
            return BadRequest(workItem);
        }
    }
}