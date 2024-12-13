using JobSearchPortal.Data;
using JobSearchPortal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchLogsController : ControllerBase
    {
        private readonly JobSearchPortalContext _context;

        public SearchLogsController(JobSearchPortalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SearchLog>>> GetSearchLogs()
        {
            return await _context.SearchLogs
                .Include(s => s.User)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SearchLog>> GetSearchLog(int id)
        {
            var searchLog = await _context.SearchLogs
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.SearchId == id);

            if (searchLog == null)
            {
                return NotFound();
            }

            return searchLog;
        }

        [HttpPost]
        public async Task<ActionResult<SearchLog>> PostSearchLog(SearchLog searchLog)
        {
            _context.SearchLogs.Add(searchLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSearchLog", new { id = searchLog.SearchId }, searchLog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSearchLog(int id, SearchLog searchLog)
        {
            if (id != searchLog.SearchId)
            {
                return BadRequest();
            }

            _context.Entry(searchLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SearchLogExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSearchLog(int id)
        {
            var searchLog = await _context.SearchLogs.FindAsync(id);
            if (searchLog == null)
            {
                return NotFound();
            }

            _context.SearchLogs.Remove(searchLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SearchLogExists(int id)
        {
            return _context.SearchLogs.Any(e => e.SearchId == id);
        }
    }
}

