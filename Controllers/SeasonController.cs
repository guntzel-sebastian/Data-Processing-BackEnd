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
    public class SeasonController : ControllerBase
    {
        private readonly NetflixContext _context;

        public SeasonController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/Season
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Season>>> GetSeason_1()
        {
            return await _context.Season_1.ToListAsync();
        }

        // GET: api/Season/5
        [HttpGet("{season_id}")]
        public async Task<ActionResult<Season>> GetSeason(int season_id)
        {
            var season = await _context.Season_1.FindAsync(season_id);

            if (season == null)
            {
                return NotFound();
            }

            return season;
        }

        // PUT: api/Season/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{season_id}")]
        public async Task<IActionResult> PutSeason(int season_id, Season season)
        {
            if (season_id != season.season_id)
            {
                return BadRequest();
            }

            _context.Entry(season).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeasonExists(season_id))
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

        // POST: api/Season
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Season>> PostSeason(Season season)
        {
            _context.Season_1.Add(season);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeason), new { season_id = season.season_id }, season);
        }

        // DELETE: api/Season/5
        [HttpDelete("{season_id}")]
        public async Task<IActionResult> DeleteSeason(int season_id)
        {
            var season = await _context.Season_1.FindAsync(season_id);
            if (season == null)
            {
                return NotFound();
            }

            _context.Season_1.Remove(season);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeasonExists(int season_id)
        {
            return _context.Season_1.Any(e => e.season_id == season_id);
        }
    }
}
