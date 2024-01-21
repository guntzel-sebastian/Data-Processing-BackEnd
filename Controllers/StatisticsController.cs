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
using Microsoft.Extensions.Primitives;

namespace NetflixAPI.Controllers
{
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly NetflixContext _context;

        public StatisticsController(NetflixContext context)
        {
            _context = context;
        }

        // GET: statistics/subscriptions/users
        [HttpGet]
        [Route("statistics/subscriptions/users")]
        public async Task<ActionResult<IEnumerable<UserSubscriptionView>>> GetStatistics()
        {
            var headers = HttpContext.Request.Headers;

            headers.TryGetValue("token", out StringValues token);
            if (token == "false")
            {
                return Unauthorized("Login has expired, please log in again");
            }

            headers.TryGetValue("userRole", out StringValues userRole);
            if (!userRole.Equals("Senior") || !userRole.Equals("Medior") || !userRole.Equals("Junior") || !userRole.Equals("Admin"))
            {
                return StatusCode(403, "User lacks required privileges");
            }

            return await _context.UserSubscriptionView.ToListAsync();
        }

        // GET: statistics/subscriptions/users
        [HttpGet]
        [Route("statistics/revenue/daily")]
        public async Task<ActionResult<IEnumerable<UserSubscriptionView>>> GetTotalDailyRevenue()
        {
            var headers = HttpContext.Request.Headers;

            headers.TryGetValue("token", out StringValues token);
            if (token == "false")
            {
                return Unauthorized("Login has expired, please log in again");
            }

            headers.TryGetValue("userRole", out StringValues userRole);
            if (!userRole.Equals("Senior") || !userRole.Equals("Medior") || !userRole.Equals("Junior") || !userRole.Equals("Admin"))
            {
                return StatusCode(403, "User lacks required privileges");
            }

            DateTime date = DateTime.Now;
            FormattableString query = ("EXECUTE dbo.GetTotalDailyRevenue {0}", date.ToString);
            return await _context.UserSubscriptionView.FromSql(query).ToListAsync();
        }

    }
}
