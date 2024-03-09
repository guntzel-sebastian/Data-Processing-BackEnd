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
    public class EpisodeController : ControllerBase
    {
        private readonly NetflixContext _context;

        public EpisodeController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/Episode
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Episode>>> GetEpisode_1()
        {
            return await _context.Episode_1.ToListAsync();
        }

        // GET: api/Episode/5
        [HttpGet("{episode_id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Episode>> GetEpisode(int episode_id)
        {
            var episode = await _context.Episode_1.FindAsync(episode_id);

            if (episode == null)
            {
                return NotFound("episode does not exist");
            }

            return episode;
        }

        // PUT: api/Episode/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{episode_id}")]
        public async Task<IActionResult> PutEpisode(int episode_id, Episode episode)
        {
            if (episode_id != episode.episode_id)
            {
                return BadRequest("ID does not match episode object");
            }

            _context.Entry(episode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpisodeExists(episode_id))
                {
                    return NotFound("episode does not exist");
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

            return CreatedAtAction(nameof(GetEpisode), new { episode_id = episode.episode_id }, episode);
        }

        // DELETE: api/Episode/5
        [HttpDelete("{episode_id}")]
        public async Task<IActionResult> DeleteEpisode(int episode_id)
        {
            var episode = await _context.Episode_1.FindAsync(episode_id);
            if (episode == null)
            {
                return NotFound("episode does not exist");
            }

            _context.Episode_1.Remove(episode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EpisodeExists(int episode_id)
        {
            return _context.Episode_1.Any(e => e.episode_id == episode_id);
        }
    }
}
