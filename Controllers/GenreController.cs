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
    public class GenreController : ControllerBase
    {
        private readonly NetflixContext _context;

        public GenreController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/Genre
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenre()
        {
            return await _context.Genre.ToListAsync();
        }

        // GET: api/Genre/5
        [HttpGet("{genre_id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Genre>> GetGenre(int genre_id)
        {
            var genre = await _context.Genre.FindAsync(genre_id);

            if (genre == null)
            {
                return NotFound("genre does not exist");
            }

            return genre;
        }

        // PUT: api/Genre/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{genre_id}")]
        public async Task<IActionResult> PutGenre(int genre_id, Genre genre)
        {
            if (genre_id != genre.genre_id)
            {
                return BadRequest("ID does not match with genre object");
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(genre_id))
                {
                    return NotFound("genre does not exist");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Genre
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            _context.Genre.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { genre_id = genre.genre_id }, genre);
        }

        // DELETE: api/Genre/5
        [HttpDelete("{genre_id}")]
        public async Task<IActionResult> DeleteGenre(int genre_id)
        {
            var genre = await _context.Genre.FindAsync(genre_id);
            if (genre == null)
            {
                return NotFound("genre does not exist");
            }

            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenreExists(int genre_id)
        {
            return _context.Genre.Any(e => e.genre_id == genre_id);
        }
    }
}
