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
    public class SubscriptionController : ControllerBase
    {
        private readonly NetflixContext _context;

        public SubscriptionController(NetflixContext context)
        {
            _context = context;
        }

        // GET: api/Subscription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetSubscription()
        {
            return await _context.Subscription.ToListAsync();
        }

        // GET: api/Subscription/5
        [HttpGet("{subscription_id}")]
        public async Task<ActionResult<Subscription>> GetSubscription(int subscription_id)
        {
            var subscription = await _context.Subscription.FindAsync(subscription_id);

            if (subscription == null)
            {
                return NotFound("subscription does not exist");
            }

            return subscription;
        }

        // PUT: api/Subscription/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{subscription_id}")]
        public async Task<IActionResult> PutSubscription(int subscription_id, Subscription subscription)
        {
            if (subscription_id != subscription.subscription_id)
            {
                return BadRequest("ID does not match with subscription object");
            }

            _context.Entry(subscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(subscription_id))
                {
                    return NotFound("subscription does not exist");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Subscription
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subscription>> PostSubscription(Subscription subscription)
        {
            _context.Subscription.Add(subscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubscription), new { subscription_id = subscription.subscription_id }, subscription);
        }

        // DELETE: api/Subscription/5
        [HttpDelete("{subscription_id}")]
        public async Task<IActionResult> DeleteSubscription(int subscription_id)
        {
            var subscription = await _context.Subscription.FindAsync(subscription_id);
            if (subscription == null)
            {
                return NotFound();
            }

            _context.Subscription.Remove(subscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionExists(int subscription_id)
        {
            return _context.Subscription.Any(e => e.subscription_id == subscription_id);
        }
    }
}
