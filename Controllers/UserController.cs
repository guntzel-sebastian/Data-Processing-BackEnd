using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using NetflixAPI.Models;
using NuGet.Common;

namespace NetflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly NetflixContext _context;

        public UserController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> UserRegister(User user)
        {

            if(user.UserHasBeenInvited)
            {
                user.UserHasBeenInvited = true;
            }

            if(!user.Validate())
            {
                return BadRequest("Invalid user data, please check your input");
            }

            var users = _context.User.ToList();

            foreach(User dbUser in users)
            {
                if(user.EmailAddress == dbUser.EmailAddress)
                {
                    return Conflict("User already exists");
                }
            }

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPost]
        public async Task<ActionResult<JsonWebToken>> UserLogin(User user)
        {

            if(!user.Validate())
            {
                return BadRequest("Invalid email or password");
            }

            var users = _context.User.ToList();
            bool userExists = false;
            foreach(User dbUser in users)
            {
                if(user.EmailAddress == dbUser.EmailAddress)
                {
                    userExists = true;
                }
            }

            if(!userExists)
            {
                return NotFound("User does not exist");
            }

            if(user.FailedLoginAttempts.Count >= 3)
            {
                return StatusCode(423, "User account is locked due to consecutive login failures");
            }
            
            return JsonWebToken;
            
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(long id)
        {
            return _context.User.Any(e => e.Id == id);
        }

    }
}
