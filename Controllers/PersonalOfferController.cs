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
        public async Task<ActionResult<PersonalOffer>> GetPersonalOffer(long id)
        {
            var personalOffer = await _context.PersonalOffer.FindAsync(id);

            if (personalOffer == null)
            {
                return NotFound();
            }

            return personalOffer;
        }

        // PUT: api/PersonalOffer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalOffer(long id, PersonalOffer personalOffer)
        {
            if (id != personalOffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalOfferExists(id))
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

        // POST: api/PersonalOffer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonalOffer>> PostPersonalOffer(PersonalOffer personalOffer)
        {
            _context.PersonalOffer.Add(personalOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonalOffer), new { id = personalOffer.Id }, personalOffer);
        }

        // DELETE: api/PersonalOffer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalOffer(long id)
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

        private bool PersonalOfferExists(long id)
        {
            return _context.PersonalOffer.Any(e => e.Id == id);
        }
    }
}
