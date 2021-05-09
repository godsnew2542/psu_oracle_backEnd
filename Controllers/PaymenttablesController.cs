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
    public class PaymenttablesController : ControllerBase
    {
        private readonly ModelContext _context;

        public PaymenttablesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Paymenttables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paymenttable>>> GetPaymenttables()
        {
            return await _context.Paymenttables.ToListAsync();
        }

        // GET: api/Paymenttables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paymenttable>> GetPaymenttable(decimal id)
        {
            var paymenttable = await _context.Paymenttables.FindAsync(id);

            if (paymenttable == null)
            {
                return NotFound();
            }

            return paymenttable;
        }

        // PUT: api/Paymenttables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymenttable(decimal id, Paymenttable paymenttable)
        {
            if (id != paymenttable.KPaymentt)
            {
                return BadRequest();
            }

            _context.Entry(paymenttable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymenttableExists(id))
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

        // POST: api/Paymenttables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Paymenttable>> PostPaymenttable(Paymenttable paymenttable)
        {
            _context.Paymenttables.Add(paymenttable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaymenttableExists(paymenttable.KPaymentt))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaymenttable", new { id = paymenttable.KPaymentt }, paymenttable);
        }

        // DELETE: api/Paymenttables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paymenttable>> DeletePaymenttable(decimal id)
        {
            var paymenttable = await _context.Paymenttables.FindAsync(id);
            if (paymenttable == null)
            {
                return NotFound();
            }

            _context.Paymenttables.Remove(paymenttable);
            await _context.SaveChangesAsync();

            return paymenttable;
        }

        private bool PaymenttableExists(decimal id)
        {
            return _context.Paymenttables.Any(e => e.KPaymentt == id);
        }
    }
}
