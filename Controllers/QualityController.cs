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
    public class QualityController : ControllerBase
    {
        private readonly NetflixContext _context;

        public QualityController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/Quality
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quality>>> GetQuality()
        {
            return await _context.Quality.ToListAsync();
        }

        // GET: api/Quality/5
        [HttpGet("{quality_id}")]
        public async Task<ActionResult<Quality>> GetQuality(int quality_id)
        {
            var quality = await _context.Quality.FindAsync(quality_id);

            if (quality == null)
            {
                return NotFound();
            }

            return quality;
        }

        // PUT: api/Quality/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{quality_id}")]
        public async Task<IActionResult> PutQuality(int quality_id, Quality quality)
        {
            if (quality_id != quality.quality_id)
            {
                return BadRequest();
            }

            _context.Entry(quality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QualityExists(quality_id))
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

        // POST: api/Quality
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quality>> PostQuality(Quality quality)
        {
            _context.Quality.Add(quality);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuality), new { quality_id = quality.quality_id }, quality);
        }

        // DELETE: api/Quality/5
        [HttpDelete("{quality_id}")]
        public async Task<IActionResult> DeleteQuality(int quality_id)
        {
            var quality = await _context.Quality.FindAsync(quality_id);
            if (quality == null)
            {
                return NotFound();
            }

            _context.Quality.Remove(quality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QualityExists(int quality_id)
        {
            return _context.Quality.Any(e => e.quality_id == quality_id);
        }
    }
}
