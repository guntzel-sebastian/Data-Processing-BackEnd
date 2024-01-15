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
    public class TextItemController : ControllerBase
    {
        private readonly NetflixContext _context;

        public TextItemController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/TextItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TextItem>>> GetTextItem()
        {
            return await _context.TextItem.ToListAsync();
        }

        // GET: api/TextItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TextItem>> GetTextItem(long id)
        {
            var textItem = await _context.TextItem.FindAsync(id);

            if (textItem == null)
            {
                return NotFound();
            }

            return textItem;
        }

        // PUT: api/TextItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTextItem(long id, TextItem textItem)
        {
            if (id != textItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(textItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextItemExists(id))
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

        // POST: api/TextItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TextItem>> PostTextItem(TextItem textItem)
        {
            _context.TextItem.Add(textItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTextItem), new { id = textItem.Id }, textItem);
        }

        // DELETE: api/TextItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTextItem(long id)
        {
            var textItem = await _context.TextItem.FindAsync(id);
            if (textItem == null)
            {
                return NotFound();
            }

            _context.TextItem.Remove(textItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TextItemExists(long id)
        {
            return _context.TextItem.Any(e => e.Id == id);
        }
    }
}
