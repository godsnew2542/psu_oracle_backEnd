using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psu_oracle_backEnd.Models;

namespace psu_oracle_backEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsertablesController : ControllerBase
    {
        private readonly ModelContext _context;

        public UsertablesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Usertables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usertable>>> GetUsertables()
        {
            return await _context.Usertables.ToListAsync();
        }

        // GET: api/Usertables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usertable>> GetUsertable(decimal id)
        {
            var usertable = await _context.Usertables.FindAsync(id);

            if (usertable == null)
            {
                return NotFound();
            }

            return usertable;
        }

        // PUT: api/Usertables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsertable(decimal id, Usertable usertable)
        {
            if (id != usertable.UId)
            {
                return BadRequest();
            }

            _context.Entry(usertable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsertableExists(id))
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

        // POST: api/Usertables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Usertable>> PostUsertable(Usertable usertable)
        {
            _context.Usertables.Add(usertable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsertableExists(usertable.UId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsertable", new { id = usertable.UId }, usertable);
        }

        // DELETE: api/Usertables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usertable>> DeleteUsertable(decimal id)
        {
            var usertable = await _context.Usertables.FindAsync(id);
            if (usertable == null)
            {
                return NotFound();
            }

            _context.Usertables.Remove(usertable);
            await _context.SaveChangesAsync();

            return usertable;
        }

        private bool UsertableExists(decimal id)
        {
            return _context.Usertables.Any(e => e.UId == id);
        }
    }
}
