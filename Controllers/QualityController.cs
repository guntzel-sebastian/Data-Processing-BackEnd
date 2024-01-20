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
        [HttpGet("{id}")]
        public async Task<ActionResult<Quality>> GetQuality(int id)
        {
            var quality = await _context.Quality.FindAsync(id);

            if (quality == null)
            {
                return NotFound();
            }

            return quality;
        }

        // PUT: api/Quality/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuality(int id, Quality quality)
        {
            if (id != quality.Id)
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
                if (!QualityExists(id))
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

            return CreatedAtAction(nameof(GetQuality), new { id = quality.Id }, quality);
        }

        // DELETE: api/Quality/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuality(int id)
        {
            var quality = await _context.Quality.FindAsync(id);
            if (quality == null)
            {
                return NotFound();
            }

            _context.Quality.Remove(quality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QualityExists(int id)
        {
            return _context.Quality.Any(e => e.Id == id);
        }
    }
}
