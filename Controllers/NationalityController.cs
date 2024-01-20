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
    public class NationalityController : ControllerBase
    {
        private readonly NetflixContext _context;

        public NationalityController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/Nationality
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nationality>>> GetNationality()
        {
            return await _context.Nationality.ToListAsync();
        }

        // GET: api/Nationality/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nationality>> GetNationality(int id)
        {
            var nationality = await _context.Nationality.FindAsync(id);

            if (nationality == null)
            {
                return NotFound();
            }

            return nationality;
        }

        // PUT: api/Nationality/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNationality(int id, Nationality nationality)
        {
            if (id != nationality.Id)
            {
                return BadRequest();
            }

            _context.Entry(nationality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationalityExists(id))
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

        // POST: api/Nationality
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nationality>> PostNationality(Nationality nationality)
        {
            _context.Nationality.Add(nationality);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNationality), new { id = nationality.Id }, nationality);
        }

        // DELETE: api/Nationality/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNationality(int id)
        {
            var nationality = await _context.Nationality.FindAsync(id);
            if (nationality == null)
            {
                return NotFound();
            }

            _context.Nationality.Remove(nationality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NationalityExists(int id)
        {
            return _context.Nationality.Any(e => e.Id == id);
        }
    }
}
