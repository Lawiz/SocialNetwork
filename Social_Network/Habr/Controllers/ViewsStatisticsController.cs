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
    public class ViewsStatisticsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ViewsStatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ViewsStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewsStatistics>>> GetViewsStatistics()
        {
            return await _context.ViewsStatistics.ToListAsync();
        }

        // GET: api/ViewsStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewsStatistics>> GetViewsStatistics(int id)
        {
            var viewsStatistics = await _context.ViewsStatistics.FindAsync(id);

            if (viewsStatistics == null)
            {
                return NotFound();
            }

            return viewsStatistics;
        }

        // PUT: api/ViewsStatistics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViewsStatistics(int id, ViewsStatistics viewsStatistics)
        {
            if (id != viewsStatistics.Id)
            {
                return BadRequest();
            }

            _context.Entry(viewsStatistics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewsStatisticsExists(id))
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

        // POST: api/ViewsStatistics
        [HttpPost]
        public async Task<ActionResult<ViewsStatistics>> PostViewsStatistics(ViewsStatistics viewsStatistics)
        {
            _context.ViewsStatistics.Add(viewsStatistics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViewsStatistics", new { id = viewsStatistics.Id }, viewsStatistics);
        }

        // DELETE: api/ViewsStatistics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewsStatistics>> DeleteViewsStatistics(int id)
        {
            var viewsStatistics = await _context.ViewsStatistics.FindAsync(id);
            if (viewsStatistics == null)
            {
                return NotFound();
            }

            _context.ViewsStatistics.Remove(viewsStatistics);
            await _context.SaveChangesAsync();

            return viewsStatistics;
        }

        private bool ViewsStatisticsExists(int id)
        {
            return _context.ViewsStatistics.Any(e => e.Id == id);
        }
    }
}
