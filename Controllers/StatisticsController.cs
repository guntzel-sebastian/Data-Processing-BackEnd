using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using NetflixAPI.Models;
using NuGet.Common;
using Microsoft.Extensions.Primitives;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace NetflixAPI.Controllers
{
    [ApiController]
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<SubscriptionsUserView>>> GetStatistics()
        {
            return await _context.SubscriptionsUserView.ToListAsync();
        }

        // GET: statistics/revenue/daily
        [HttpGet]
        [Route("statistics/revenue/daily")]
        public async Task<ActionResult<IEnumerable<GetTotalDailyRevenue>>> GetRevenueByDay()
        {
            var result = _context.Database
            .ExecuteSqlRaw("EXEC dbo.sp_GetRevenueByDay @days",
            new SqlParameter("@days", SqlDbType.Int) { Value = 30 });
            return Ok(result);
        }

    }
}
