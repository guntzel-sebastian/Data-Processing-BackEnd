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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenceController : ControllerBase
    {
        private readonly NetflixContext _context;

        public PreferenceController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/Preference
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Preference>>> GetPreference()
        {
            return await _context.Preference.ToListAsync();
        }

        // GET: api/Preference/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Preference>> GetPreference(long id)
        {
            var preference = await _context.Preference.FindAsync(id);

            if (preference == null)
            {
                return NotFound();
            }

            return preference;
        }

        // PUT: api/Preference/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreference(long id, Preference preference)
        {
            if (id != preference.Id)
            {
                return BadRequest();
            }

            _context.Entry(preference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreferenceExists(id))
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

        // POST: api/Preference
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Preference>> PostPreference(Preference preference)
        {
            _context.Preference.Add(preference);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPreference), new { id = preference.Id }, preference);
        }

        // DELETE: api/Preference/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreference(long id)
        {
            var preference = await _context.Preference.FindAsync(id);
            if (preference == null)
            {
                return NotFound();
            }

            _context.Preference.Remove(preference);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreferenceExists(long id)
        {
            return _context.Preference.Any(e => e.Id == id);
        }
    }
}
