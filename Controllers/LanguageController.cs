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
    public class LanguageController : ControllerBase
    {
        private readonly NetflixContext _context;

        public LanguageController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/Language
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguage()
        {
            return await _context.Language.ToListAsync();
        }

        // GET: api/Language/5
        [HttpGet("{language_id}")]
        public async Task<ActionResult<Language>> GetLanguage(int language_id)
        {
            var language = await _context.Language.FindAsync(language_id);

            if (language == null)
            {
                return NotFound("language does not exist");
            }

            return language;
        }

        // PUT: api/Language/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{language_id}")]
        public async Task<IActionResult> PutLanguage(int language_id, Language language)
        {
            if (language_id != language.language_id)
            {
                return BadRequest("ID does not match with language object");
            }

            _context.Entry(language).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(language_id))
                {
                    return NotFound("language does not exist");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Language
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Language>> PostLanguage(Language language)
        {
            _context.Language.Add(language);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLanguage), new { language_id = language.language_id }, language);
        }

        // DELETE: api/Language/5
        [HttpDelete("{language_id}")]
        public async Task<IActionResult> DeleteLanguage(int language_id)
        {
            var language = await _context.Language.FindAsync(language_id);
            if (language == null)
            {
                return NotFound("language does not exist");
            }

            _context.Language.Remove(language);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LanguageExists(int language_id)
        {
            return _context.Language.Any(e => e.language_id == language_id);
        }
    }
}
