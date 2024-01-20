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
    public class SubtitleContentController : ControllerBase
    {
        private readonly NetflixContext _context;

        public SubtitleContentController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/SubtitleContent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubtitleContent>>> GetSubtitleContent_1()
        {
            return await _context.SubtitleContent_1.ToListAsync();
        }

        // GET: api/SubtitleContent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubtitleContent>> GetSubtitleContent(int id)
        {
            var subtitleContent = await _context.SubtitleContent_1.FindAsync(id);

            if (subtitleContent == null)
            {
                return NotFound();
            }

            return subtitleContent;
        }

        // PUT: api/SubtitleContent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{subtitle_id}")]
        public async Task<IActionResult> PutSubtitleContent(long subtitle_id, SubtitleContent subtitleContent)
        {
            if (subtitle_id != subtitleContent.subtitle_id)
            {
                return BadRequest();
            }

            _context.Entry(subtitleContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubtitleContentExists(subtitle_id))
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

        // POST: api/SubtitleContent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubtitleContent>> PostSubtitleContent(SubtitleContent subtitleContent)
        {
            _context.SubtitleContent_1.Add(subtitleContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubtitleContent), new { id = subtitleContent.subtitle_id }, subtitleContent);
        }

        // DELETE: api/SubtitleContent/5
        [HttpDelete("{subtitle_id}")]
        public async Task<IActionResult> DeleteSubtitleContent(long subtitle_id)
        {
            var subtitleContent = await _context.SubtitleContent_1.FindAsync(subtitle_id);
            if (subtitleContent == null)
            {
                return NotFound();
            }

            _context.SubtitleContent_1.Remove(subtitleContent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubtitleContentExists(long subtitle_id)
        {
            return _context.SubtitleContent_1.Any(e => e.subtitle_id == subtitle_id);
        }
    }
}
