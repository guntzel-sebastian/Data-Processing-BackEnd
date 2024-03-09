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
            var APIKey = await _context.APIKey.FindAsync(id);

            if (APIKey == null)
            {
                return NotFound("API key does not exist");
            }

            return APIKey;
        }

        // PUT: api/APIKey/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAPIKey(int id, APIKey APIKey)
        {
            if (id != APIKey.api_key_id)
            {
                return BadRequest("Entered ID does not match recieved APIKey, please ensure this information matches");
            }

            _context.Entry(APIKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APIKeyExists(id))
                {
                    return NotFound("API key does not exist");
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
        public async Task<ActionResult<APIKey>> PostAPIKey(APIKey APIKey)
        {
            _context.APIKey.Add(APIKey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAPIKey", new { id = APIKey.api_key_id }, APIKey);
        }

        // DELETE: api/APIKey/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAPIKey(int id)
        {
            var APIKey = await _context.APIKey.FindAsync(id);
            if (APIKey == null)
            {
                return NotFound("API key does not exist");
            }

            _context.APIKey.Remove(APIKey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool APIKeyExists(int id)
        {
            return _context.APIKey.Any(e => e.api_key_id == id);
        }
    }
}
