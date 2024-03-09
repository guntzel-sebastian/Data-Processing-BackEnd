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
    public class SubtitleContentController : ControllerBase
    {
        private readonly NetflixContext _context;

        public SubtitleContentController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/SubtitleContent
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SubtitleContent>>> GetSubtitleContent_1()
        {
            return await _context.SubtitleContent_1.ToListAsync();
        }

        // GET: api/SubtitleContent/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<SubtitleContent>> GetSubtitleContent(int id)
        {
            var subtitleContent = await _context.SubtitleContent_1.FindAsync(id);

            if (subtitleContent == null)
            {
                return NotFound("Subtitle does not exist");
            }

            return subtitleContent;
        }

        // PUT: api/SubtitleContent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{subtitle_id}")]
        public async Task<IActionResult> PutSubtitleContent(int subtitle_id, SubtitleContent subtitleContent)
        {
            if (subtitle_id != subtitleContent.subtitle_id)
            {
                return BadRequest("ID does not match subtitle object");
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
                    return NotFound("Subtitle does not exist");
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

            var episode = _context.Episode.FindAsync(subtitleContent.episode_id);
            var language = _context.Episode.FindAsync(subtitleContent.language_id);

            if(language == null || episode == null)
            {
                return BadRequest("Invalid episode or language ID");
            }

            _context.SubtitleContent_1.Add(subtitleContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubtitleContent), new { id = subtitleContent.subtitle_id }, subtitleContent);
        }

        // DELETE: api/SubtitleContent/5
        [HttpDelete("{subtitle_id}")]
        public async Task<IActionResult> DeleteSubtitleContent(int subtitle_id)
        {
            var subtitleContent = await _context.SubtitleContent_1.FindAsync(subtitle_id);
            if (subtitleContent == null)
            {
                return NotFound("Subtitle does not exist");
            }

            _context.SubtitleContent_1.Remove(subtitleContent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubtitleContentExists(int subtitle_id)
        {
            return _context.SubtitleContent_1.Any(e => e.subtitle_id == subtitle_id);
        }
    }
}
