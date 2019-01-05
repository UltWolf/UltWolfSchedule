using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UltWolfScheduleAPI.Models;
using UltWolfScheduleAPI.Models.Context;

namespace UltWolfScheduleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdinaryTasksController : ControllerBase
    {
        private readonly ScheduleContext _context;

        public OrdinaryTasksController(ScheduleContext context)
        {
            _context = context;
        }

        // GET: api/OrdinaryTasks
        [HttpGet]
        public IEnumerable<OrdinaryTask> GetOrdTasks()
        {
            return _context.OrdTasks;
        }

        // GET: api/OrdinaryTasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdinaryTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ordinaryTask = await _context.OrdTasks.FindAsync(id);

            if (ordinaryTask == null)
            {
                return NotFound();
            }

            return Ok(ordinaryTask);
        }

        // PUT: api/OrdinaryTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdinaryTask([FromRoute] int id, [FromBody] OrdinaryTask ordinaryTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ordinaryTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordinaryTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdinaryTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrdinaryTasks
        [HttpPost]
        public async Task<IActionResult> PostOrdinaryTask([FromBody] OrdinaryTask ordinaryTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrdTasks.Add(ordinaryTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdinaryTask", new { id = ordinaryTask.Id }, ordinaryTask);
        }

        // DELETE: api/OrdinaryTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdinaryTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ordinaryTask = await _context.OrdTasks.FindAsync(id);
            if (ordinaryTask == null)
            {
                return NotFound();
            }

            _context.OrdTasks.Remove(ordinaryTask);
            await _context.SaveChangesAsync();

            return Ok(ordinaryTask);
        }

        private bool OrdinaryTaskExists(int id)
        {
            return _context.OrdTasks.Any(e => e.Id == id);
        }
    }
}