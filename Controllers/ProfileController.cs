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
    public class ProfileController : ControllerBase
    {
        private readonly NetflixContext _context;

        public ProfileController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/Profile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfile()
        {
            return await _context.Profile.ToListAsync();
        }

        // GET: api/Profile/5
        [HttpGet("{profile_id}")]
        public async Task<ActionResult<Profile>> GetProfile(long profile_id)
        {
            var profile = await _context.Profile.FindAsync(profile_id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        // PUT: api/Profile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{profile_id}")]
        public async Task<IActionResult> PutProfile(long profile_id, Profile profile)
        {
            if (profile_id != profile.profile_id)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(profile_id))
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

        // POST: api/Profile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            _context.Profile.Add(profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfile), new { profile_id = profile.profile_id }, profile);
        }

        // DELETE: api/Profile/5
        [HttpDelete("{profile_id}")]
        public async Task<IActionResult> DeleteProfile(long profile_id)
        {
            var profile = await _context.Profile.FindAsync(profile_id);
            if (profile == null)
            {
                return NotFound();
            }

            _context.Profile.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileExists(long profile_id)
        {
            return _context.Profile.Any(e => e.profile_id == profile_id);
        }
    }
}
