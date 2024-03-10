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
    public class TextItemController : ControllerBase
    {
        private readonly NetflixContext _context;

        public TextItemController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/TextItem
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<TextItem>>> GetTextItem()
        {
            return await _context.TextItem.ToListAsync();
        }

        // GET: api/TextItem/5
        [HttpGet("{text_item_id}")]
        [AllowAnonymous]
        public async Task<ActionResult<TextItem>> GetTextItem(int id)
        {
            var textItem = await _context.TextItem.FindAsync(id);

            if (textItem == null)
            {
                return NotFound("Text item not found");
            }

            return textItem;
        }

        // PUT: api/TextItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{text_item_id}")]
        public async Task<IActionResult> PutTextItem(int text_item_id, TextItem textItem)
        {
            if (text_item_id != textItem.text_item_id)
            {
                return BadRequest("ID does not match with text item object");
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
                    return NotFound("text item not found");
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
        public async Task<IActionResult> DeleteTextItem(int text_item_id)
        {
            var textItem = await _context.TextItem.FindAsync(text_item_id);
            if (textItem == null)
            {
                return NotFound("text item not found");
            }

            _context.TextItem.Remove(textItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TextItemExists(int text_item_id)
        {
            return _context.TextItem.Any(e => e.text_item_id == text_item_id);
        }
    }
}
