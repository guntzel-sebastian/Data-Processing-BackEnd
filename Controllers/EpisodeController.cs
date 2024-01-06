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
    public class EpisodeController : ControllerBase
    {
        private readonly NetflixContext _context;

        public EpisodeController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/Episode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Episode>>> GetEpisode_1()
        {
            return await _context.Episode_1.ToListAsync();
        }

        // GET: api/Episode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Episode>> GetEpisode(long id)
        {
            var episode = await _context.Episode_1.FindAsync(id);

            if (episode == null)
            {
                return NotFound();
            }

            return episode;
        }

        // PUT: api/Episode/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpisode(long id, Episode episode)
        {
            if (id != episode.Id)
            {
                return BadRequest();
            }

            _context.Entry(episode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpisodeExists(id))
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

        // POST: api/Episode
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Episode>> PostEpisode(Episode episode)
        {
            _context.Episode_1.Add(episode);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEpisode), new { id = episode.Id }, episode);
        }

        // DELETE: api/Episode/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpisode(long id)
        {
            var episode = await _context.Episode_1.FindAsync(id);
            if (episode == null)
            {
                return NotFound();
            }

            _context.Episode_1.Remove(episode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EpisodeExists(long id)
        {
            return _context.Episode_1.Any(e => e.Id == id);
        }
    }
}
