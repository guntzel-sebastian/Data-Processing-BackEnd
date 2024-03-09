using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetflixAPI.Models;

namespace NetflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WatchableContentController : ControllerBase
    {
        private readonly NetflixContext _context;

        public WatchableContentController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/WatchableContent
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<WatchableContent>>> GetWatchableContent_1()
        {
            return await _context.WatchableContent_1.ToListAsync();
        }

        // GET: api/WatchableContent/5
        [HttpGet("{content_id}")]
        [AllowAnonymous]
        public async Task<ActionResult<WatchableContent>> GetWatchableContent(int content_id)
        {
            var watchableContent = await _context.WatchableContent_1.FindAsync(content_id);

            if (watchableContent == null)
            {
                return NotFound("Watchable content does not exist");
            }

            return watchableContent;
        }

        // PUT: api/WatchableContent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{content_id}")]
        public async Task<IActionResult> PutWatchableContent(int content_id, WatchableContent watchableContent)
        {
            if (content_id != watchableContent.content_id)
            {
                return BadRequest("ID does not match with watchable content");
            }

            _context.Entry(watchableContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchableContentExists(content_id))
                {
                    return NotFound("Watchable content does not exist");
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

            if(!watchableContent.Validate())
            {
                return BadRequest("Invalid data, please check your input");
            }

            _context.WatchableContent_1.Add(watchableContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWatchableContent), new { content_id = watchableContent.content_id }, watchableContent);
        }

        // DELETE: api/WatchableContent/5
        [HttpDelete("{content_id}")]
        public async Task<IActionResult> DeleteWatchableContent(int content_id)
        {
            var watchableContent = await _context.WatchableContent_1.FindAsync(content_id);
            if (watchableContent == null)
            {
                return NotFound("Watchable content does not exist");
            }

            _context.WatchableContent_1.Remove(watchableContent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WatchableContentExists(int content_id)
        {
            return _context.WatchableContent_1.Any(e => e.content_id == content_id);
        }
    }
}
