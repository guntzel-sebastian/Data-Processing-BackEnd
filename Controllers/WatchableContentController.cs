using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetflixAPI.Models;

namespace NetflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchableContentController : ControllerBase
    {
        private readonly NetflixContext _context;

        public WatchableContentController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/WatchableContent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WatchableContent>>> GetWatchableContent_1()
        {
            return await _context.WatchableContent_1.ToListAsync();
        }

        // GET: api/WatchableContent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WatchableContent>> GetWatchableContent(long id)
        {
            var watchableContent = await _context.WatchableContent_1.FindAsync(id);

            if (watchableContent == null)
            {
                return NotFound();
            }

            return watchableContent;
        }

        // PUT: api/WatchableContent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWatchableContent(long id, WatchableContent watchableContent)
        {
            if (id != watchableContent.Id)
            {
                return BadRequest();
            }

            _context.Entry(watchableContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchableContentExists(id))
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

        // POST: api/WatchableContent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WatchableContent>> PostWatchableContent(WatchableContent watchableContent)
        {
            _context.WatchableContent_1.Add(watchableContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWatchableContent", new { id = watchableContent.Id }, watchableContent);
        }

        // DELETE: api/WatchableContent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatchableContent(long id)
        {
            var watchableContent = await _context.WatchableContent_1.FindAsync(id);
            if (watchableContent == null)
            {
                return NotFound();
            }

            _context.WatchableContent_1.Remove(watchableContent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WatchableContentExists(long id)
        {
            return _context.WatchableContent_1.Any(e => e.Id == id);
        }
    }
}
