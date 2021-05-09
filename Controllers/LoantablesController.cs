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
    public class LoantablesController : ControllerBase
    {
        private readonly ModelContext _context;

        public LoantablesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Loantables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loantable>>> GetLoantables()
        {
            return await _context.Loantables.ToListAsync();
        }

        // GET: api/Loantables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loantable>> GetLoantable(decimal id)
        {
            var loantable = await _context.Loantables.FindAsync(id);

            if (loantable == null)
            {
                return NotFound();
            }

            return loantable;
        }

        // PUT: api/Loantables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoantable(decimal id, Loantable loantable)
        {
            if (id != loantable.KLoan)
            {
                return BadRequest();
            }

            _context.Entry(loantable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoantableExists(id))
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

        // POST: api/Loantables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Loantable>> PostLoantable(Loantable loantable)
        {
            _context.Loantables.Add(loantable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoantableExists(loantable.KLoan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoantable", new { id = loantable.KLoan }, loantable);
        }

        // DELETE: api/Loantables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Loantable>> DeleteLoantable(decimal id)
        {
            var loantable = await _context.Loantables.FindAsync(id);
            if (loantable == null)
            {
                return NotFound();
            }

            _context.Loantables.Remove(loantable);
            await _context.SaveChangesAsync();

            return loantable;
        }

        private bool LoantableExists(decimal id)
        {
            return _context.Loantables.Any(e => e.KLoan == id);
        }
    }
}
