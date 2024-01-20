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
        [HttpGet("{text_item_id}")]
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
        [HttpPut("{text_item_id}")]
        public async Task<IActionResult> PutTextItem(long text_item_id, TextItem textItem)
        {
            if (text_item_id != textItem.text_item_id)
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
                if (!TextItemExists(text_item_id))
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

            return CreatedAtAction(nameof(GetTextItem), new { text_item_id = textItem.text_item_id }, textItem);
        }

        // DELETE: api/TextItem/5
        [HttpDelete("{text_item_id}")]
        public async Task<IActionResult> DeleteTextItem(long text_item_id)
        {
            var textItem = await _context.TextItem.FindAsync(text_item_id);
            if (textItem == null)
            {
                return NotFound();
            }

            _context.TextItem.Remove(textItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TextItemExists(long text_item_id)
        {
            return _context.TextItem.Any(e => e.text_item_id == text_item_id);
        }
    }
}
