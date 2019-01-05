using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UltWolfScheduleAPI.Models;
using UltWolfScheduleAPI.Models.Context;

namespace UltWolfScheduleAPI.Controllers
{
    [Authorize]
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
        public IEnumerable<OrdinaryTask> GetOrdTasksForToday()
        {
            return _context.OrdTasks.Where(m=>m.User.Id.ToString() == User.Identity.Name).Where(m=>m.Date.Date==DateTime.Now.Date);
        }
        [HttpGet("all")]
        public IEnumerable<OrdinaryTask> GetallOrdTasksy()
        {
            return _context.OrdTasks.Where(m => m.User.Id.ToString() == User.Identity.Name);
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
            if (ordinaryTask.UserId.ToString() != User.Identity.Name)
            {
                ModelState.AddModelError("error", "Sorry you don`t have enought permision for that");
                return BadRequest(ModelState);
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
            ordinaryTask.UserId = int.Parse(User.Identity.Name);
            _context.OrdTasks.Add(ordinaryTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdinaryTask", new { id = ordinaryTask.Id }, ordinaryTask);
        }
         
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
            if(ordinaryTask.UserId.ToString() != User.Identity.Name)
            {
                ModelState.AddModelError("error", "Sorry you don`t have enought permision for that");
                return BadRequest(ModelState);
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