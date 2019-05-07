using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BLL.Domain.Models;
using Habr.Data;

namespace Habr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryStatisticsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntryStatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EntryStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntryStatistics>>> GetEntryStatistics()
        {
            return await _context.EntryStatistics.ToListAsync();
        }

        // GET: api/EntryStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntryStatistics>> GetEntryStatistics(int id)
        {
            var entryStatistics = await _context.EntryStatistics.FindAsync(id);

            if (entryStatistics == null)
            {
                return NotFound();
            }

            return entryStatistics;
        }

        // PUT: api/EntryStatistics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntryStatistics(int id, EntryStatistics entryStatistics)
        {
            if (id != entryStatistics.Id)
            {
                return BadRequest();
            }

            _context.Entry(entryStatistics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryStatisticsExists(id))
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

        // POST: api/EntryStatistics
        [HttpPost]
        public async Task<ActionResult<EntryStatistics>> PostEntryStatistics(EntryStatistics entryStatistics)
        {
            _context.EntryStatistics.Add(entryStatistics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntryStatistics", new { id = entryStatistics.Id }, entryStatistics);
        }

        // DELETE: api/EntryStatistics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EntryStatistics>> DeleteEntryStatistics(int id)
        {
            var entryStatistics = await _context.EntryStatistics.FindAsync(id);
            if (entryStatistics == null)
            {
                return NotFound();
            }

            _context.EntryStatistics.Remove(entryStatistics);
            await _context.SaveChangesAsync();

            return entryStatistics;
        }

        private bool EntryStatisticsExists(int id)
        {
            return _context.EntryStatistics.Any(e => e.Id == id);
        }
    }
}
