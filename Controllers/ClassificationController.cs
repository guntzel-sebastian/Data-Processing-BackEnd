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
    public class ClassificationController : ControllerBase
    {
        private readonly NetflixContext _context;

        public ClassificationController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/Classification
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Classification>>> GetClassification()
        {
            return await _context.Classification.ToListAsync();
        }

        // GET: api/Classification/5
        [HttpGet("{classification_id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Classification>> GetClassification(int classification_id)
        {
            var classification = await _context.Classification.FindAsync(classification_id);

            if (classification == null)
            {
                return NotFound("classification does not exist");
            }

            return classification;
        }

        // PUT: api/Classification/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{classification_id}")]
        public async Task<IActionResult> PutClassification(int classification_id, Classification classification)
        {
            if (classification_id != classification.classification_id)
            {
                return BadRequest("ID does not match classification, please ensure these match");
            }

            _context.Entry(classification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassificationExists(classification_id))
                {
                    return NotFound("classification does not exist");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Classification
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Classification>> PostClassification(Classification classification)
        {
            _context.Classification.Add(classification);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClassification), new { classification_id = classification.classification_id }, classification);
        }

        // DELETE: api/Classification/5
        [HttpDelete("{classification_id}")]
        public async Task<IActionResult> DeleteClassification(int classification_id)
        {
            var classification = await _context.Classification.FindAsync(classification_id);
            if (classification == null)
            {
                return NotFound("classification does not exist");
            }

            _context.Classification.Remove(classification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassificationExists(int classification_id)
        {
            return _context.Classification.Any(e => e.classification_id == classification_id);
        }
    }
}
