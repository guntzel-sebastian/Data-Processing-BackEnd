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
    public class PersonalOfferController : ControllerBase
    {
        private readonly NetflixContext _context;

        public PersonalOfferController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/PersonalOffer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WatchableContent>>> GetPersonalOffer()
        {
            return await _context.WatchableContent.ToListAsync();
        }

        // GET: api/PersonalOffer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WatchableContent>> GetPersonalOffer(int id)
        {
            var personalOffer = await _context.WatchableContent.FindAsync(id);

            if (personalOffer == null)
            {
                return NotFound("Offer does not exist");
            }

            return personalOffer;
        }

        // DELETE: api/PersonalOffer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalOffer(int id)
        {
            var personalOffer = await _context.WatchableContent.FindAsync(id);
            if (personalOffer == null)
            {
                return NotFound("Offer does not exist");
            }

            _context.WatchableContent.Remove(personalOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalOfferExists(int id)
        {
            return _context.WatchableContent.Any(e => e.content_id == id);
        }
    }
}
