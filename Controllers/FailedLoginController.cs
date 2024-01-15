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
    public class FailedLoginController : ControllerBase
    {
        private readonly NetflixContext _context;

        public FailedLoginController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/FailedLogin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FailedLoginAttempt>>> GetFailedLoginAttempt()
        {
            return await _context.FailedLoginAttempt.ToListAsync();
        }

        // GET: api/FailedLogin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FailedLoginAttempt>> GetFailedLoginAttempt(long id)
        {
            var failedLoginAttempt = await _context.FailedLoginAttempt.FindAsync(id);

            if (failedLoginAttempt == null)
            {
                return NotFound();
            }

            return failedLoginAttempt;
        }

        // PUT: api/FailedLogin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFailedLoginAttempt(long id, FailedLoginAttempt failedLoginAttempt)
        {
            if (id != failedLoginAttempt.Id)
            {
                return BadRequest();
            }

            _context.Entry(failedLoginAttempt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FailedLoginAttemptExists(id))
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

        // POST: api/FailedLogin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FailedLoginAttempt>> PostFailedLoginAttempt(FailedLoginAttempt failedLoginAttempt)
        {
            _context.FailedLoginAttempt.Add(failedLoginAttempt);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFailedLoginAttempt), new { id = failedLoginAttempt.Id }, failedLoginAttempt);
        }

        // DELETE: api/FailedLogin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFailedLoginAttempt(long id)
        {
            var failedLoginAttempt = await _context.FailedLoginAttempt.FindAsync(id);
            if (failedLoginAttempt == null)
            {
                return NotFound();
            }

            _context.FailedLoginAttempt.Remove(failedLoginAttempt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FailedLoginAttemptExists(long id)
        {
            return _context.FailedLoginAttempt.Any(e => e.Id == id);
        }
    }
}
