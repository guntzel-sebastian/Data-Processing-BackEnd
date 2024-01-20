using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using NetflixAPI.Models;
using NuGet.Common;

namespace NetflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpGet("{user_id}")]
        public async Task<ActionResult<User>> GetUser(long user_id)
        {
            var user = await _context.User.FindAsync(user_id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{user_id}")]
        public async Task<IActionResult> PutUser(long user_id, User user)
        {
            if (user_id != user.user_id)
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
                if (!UserExists(user_id))
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
        [Route("register")]
        [AllowAnonymous]
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
                if(user.email == dbUser.email)
                {
                    return Conflict("User already exists");
                }
            }

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { user_id = user.user_id }, user);
        }

/*
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<JsonWebToken>> UserLogin(User user)
        {

            if(!user.Validate())
            {
                return BadRequest("Invalid email or password");
            }

            var users = _context.User.ToList();
            User compareUser;
            bool userExists = false;
            foreach(User dbUser in users)
            {
                if(user.email == dbUser.email)
                {
                    userExists = true;
                    compareUser = dbUser;
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

            
                        
        }
        */

        // DELETE: api/User/5
        [HttpDelete("{user_id}")]
        public async Task<IActionResult> DeleteUser(long user_id)
        {
            var user = await _context.User.FindAsync(user_id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(long user_id)
        {
            return _context.User.Any(e => e.user_id == user_id);
        }

    }
}
