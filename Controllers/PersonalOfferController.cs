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
        public async Task<ActionResult<IEnumerable<PersonalOffer>>> GetPersonalOffer()
        {
            return await _context.PersonalOffer.ToListAsync();
        }

        // GET: api/PersonalOffer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalOffer>> GetPersonalOffer(int id)
        {
            var personalOffer = await _context.PersonalOffer.FindAsync(id);

            if (personalOffer == null)
            {
                return NotFound();
            }

            return personalOffer;
        }

        // DELETE: api/PersonalOffer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalOffer(int id)
        {
            var personalOffer = await _context.PersonalOffer.FindAsync(id);
            if (personalOffer == null)
            {
                return NotFound();
            }

            _context.PersonalOffer.Remove(personalOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalOfferExists(int id)
        {
            return _context.PersonalOffer.Any(e => e.Id == id);
        }
    }
}
