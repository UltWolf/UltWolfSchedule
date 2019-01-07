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
    [Route("api/[controller]")]
    [ApiController]
    public class MultipleTasksController : ControllerBase
    {
        private readonly ScheduleContext _context;

        public MultipleTasksController(ScheduleContext context)
        {
            _context = context;
        }

        //// GET: api/MultipleTasks
        //[HttpGet]
        //public IEnumerable<MultipleTask> GetMulTasks()
        //{
        //    return _context.MulTasks;
        //}
       
        //// GET: api/MultipleTasks/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetMultipleTask([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var multipleTask = await _context.MulTasks.FindAsync(id);

        //    if (multipleTask == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(multipleTask);
        //}

        //// PUT: api/MultipleTasks/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMultipleTask([FromRoute] int id, [FromBody] MultipleTask multipleTask)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != multipleTask.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(multipleTask).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MultipleTaskExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/MultipleTasks
        //[HttpPost]
        //public async Task<IActionResult> PostMultipleTask([FromBody] MultipleTask multipleTask)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.MulTasks.Add(multipleTask);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMultipleTask", new { id = multipleTask.Id }, multipleTask);
        //}

        //// DELETE: api/MultipleTasks/5
        //[Authorize]
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMultipleTask([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var multipleTask = await _context.MulTasks.FindAsync(id);
        //    if (multipleTask == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.MulTasks.Remove(multipleTask);
        //    await _context.SaveChangesAsync();

        //    return Ok(multipleTask);
        //}

        //private bool MultipleTaskExists(int id)
        //{
        //    return _context.MulTasks.Any(e => e.Id == id);
        //}
    }
}