using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using NuGet.Common;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

using NetflixAPI.Models;

namespace NetflixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly NetflixContext _context;
        private readonly IConfiguration _configuration;

        public UserController(NetflixContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{user_id}")]
        public async Task<ActionResult<User>> GetUser(int user_id)
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
        public async Task<IActionResult> PutUser(int user_id, User user)
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


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult UserLogin(LoginUser loginUser)
        {

            if(!loginUser.Validate())
            {
                return BadRequest("Invalid email or password");
            }

            var users = _context.User.ToList();
            foreach(User dbUser in users)
            {
                if(loginUser.email == dbUser.email)
                {
                    var loginAttempts = _context.User.Where(u => u.email == dbUser.email).ToList();

                    if(loginAttempts.Count >= 3)
                    {
                        return StatusCode(423, "User account is locked due to consecutive login failures");
                    }

                    return Ok(CreateToken(dbUser, "Admin"));
                }
            }

            return NotFound("User does not exist");
                        
        }
        

        // DELETE: api/User/5
        [HttpDelete("{user_id}")]
        public async Task<IActionResult> DeleteUser(int user_id)
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

        private bool UserExists(int user_id)
        {
            return _context.User.Any(e => e.user_id == user_id);
        }

        private string CreateToken(User user, string role)
        {
            
            var tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.email),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenRaw = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(tokenRaw);

            return jwt;

        }

    }

}
