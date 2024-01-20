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
    public class APIKeyController : ControllerBase
    {
        private readonly NetflixContext _context;

        public APIKeyController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/APIKey
        [HttpGet]
        public async Task<ActionResult<IEnumerable<APIKey>>> GetAPIKey()
        {
            return await _context.APIKey.ToListAsync();
        }

        // GET: api/APIKey/5
        [HttpGet("{id}")]
        public async Task<ActionResult<APIKey>> GetAPIKey(int id)
        {
            var aPIKey = await _context.APIKey.FindAsync(id);

            if (aPIKey == null)
            {
                return NotFound();
            }

            return aPIKey;
        }

        // PUT: api/APIKey/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAPIKey(int id, APIKey aPIKey)
        {
            if (id != aPIKey.Id)
            {
                return BadRequest();
            }

            _context.Entry(aPIKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APIKeyExists(id))
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

        // POST: api/APIKey
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<APIKey>> PostAPIKey(APIKey aPIKey)
        {
            _context.APIKey.Add(aPIKey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAPIKey", new { id = aPIKey.Id }, aPIKey);
        }

        // DELETE: api/APIKey/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAPIKey(int id)
        {
            var aPIKey = await _context.APIKey.FindAsync(id);
            if (aPIKey == null)
            {
                return NotFound();
            }

            _context.APIKey.Remove(aPIKey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool APIKeyExists(int id)
        {
            return _context.APIKey.Any(e => e.Id == id);
        }
    }
}
