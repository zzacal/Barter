using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Barter.Api.Data;
using Barter.Models;

namespace Barter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingsController : ControllerBase
    {
        private readonly CoreContext _context;

        public ThingsController(CoreContext context)
        {
            _context = context;
        }

        // GET: api/Things
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thing>>> GetThing()
        {
            return await _context.Thing.ToListAsync();
        }

        // GET: api/Things/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thing>> GetThing(int id)
        {
            var thing = await _context.Thing.FindAsync(id);

            if (thing == null)
            {
                return NotFound();
            }

            return thing;
        }

        // PUT: api/Things/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThing(int id, Thing thing)
        {
            if (id != thing.Id)
            {
                return BadRequest();
            }

            _context.Entry(thing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThingExists(id))
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

        // POST: api/Things
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Thing>> PostThing(Thing thing)
        {
            _context.Thing.Add(thing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThing", new { id = thing.Id }, thing);
        }

        // DELETE: api/Things/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Thing>> DeleteThing(int id)
        {
            var thing = await _context.Thing.FindAsync(id);
            if (thing == null)
            {
                return NotFound();
            }

            _context.Thing.Remove(thing);
            await _context.SaveChangesAsync();

            return thing;
        }

        private bool ThingExists(int id)
        {
            return _context.Thing.Any(e => e.Id == id);
        }
    }
}
