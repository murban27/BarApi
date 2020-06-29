using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatsController : ControllerBase
    {
        private readonly restaurantvspjContext _context;

        public VatsController(restaurantvspjContext context)
        {
            _context = context;
        }

        // GET: api/Vats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vat>>> GetVat()
        {
            return await _context.Vat.ToListAsync();
        }

        // GET: api/Vats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vat>> GetVat(int id)
        {
            var vat = await _context.Vat.FindAsync(id);

            if (vat == null)
            {
                return NotFound();
            }

            return vat;
        }

        // PUT: api/Vats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVat(int id, Vat vat)
        {
            if (id != vat.VatId)
            {
                return BadRequest();
            }

            _context.Entry(vat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VatExists(id))
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

        // POST: api/Vats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vat>> PostVat(Vat vat)
        {
            _context.Vat.Add(vat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVat", new { id = vat.VatId }, vat);
        }

        // DELETE: api/Vats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vat>> DeleteVat(int id)
        {
            var vat = await _context.Vat.FindAsync(id);
            if (vat == null)
            {
                return NotFound();
            }

            _context.Vat.Remove(vat);
            await _context.SaveChangesAsync();

            return vat;
        }

        private bool VatExists(int id)
        {
            return _context.Vat.Any(e => e.VatId == id);
        }
    }
}
