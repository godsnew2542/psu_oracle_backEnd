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
    public class MarriagetablesController : ControllerBase
    {
        private readonly ModelContext _context;

        public MarriagetablesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Marriagetables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marriagetable>>> GetMarriagetables()
        {
            return await _context.Marriagetables.ToListAsync();
        }

        // GET: api/Marriagetables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marriagetable>> GetMarriagetable(decimal id)
        {
            var marriagetable = await _context.Marriagetables.FindAsync(id);

            if (marriagetable == null)
            {
                return NotFound();
            }

            return marriagetable;
        }

        // PUT: api/Marriagetables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarriagetable(decimal id, Marriagetable marriagetable)
        {
            if (id != marriagetable.UId)
            {
                return BadRequest();
            }

            _context.Entry(marriagetable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarriagetableExists(id))
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

        // POST: api/Marriagetables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Marriagetable>> PostMarriagetable(Marriagetable marriagetable)
        {
            _context.Marriagetables.Add(marriagetable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MarriagetableExists(marriagetable.UId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMarriagetable", new { id = marriagetable.UId }, marriagetable);
        }

        // DELETE: api/Marriagetables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Marriagetable>> DeleteMarriagetable(decimal id)
        {
            var marriagetable = await _context.Marriagetables.FindAsync(id);
            if (marriagetable == null)
            {
                return NotFound();
            }

            _context.Marriagetables.Remove(marriagetable);
            await _context.SaveChangesAsync();

            return marriagetable;
        }

        private bool MarriagetableExists(decimal id)
        {
            return _context.Marriagetables.Any(e => e.UId == id);
        }
    }
}
