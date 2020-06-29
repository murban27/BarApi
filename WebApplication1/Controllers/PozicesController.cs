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
    public class PozicesController : ControllerBase
    {
        private readonly restaurantvspjContext _context;

        public PozicesController(restaurantvspjContext context)
        {
            _context = context;
        }

        // GET: api/Pozices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pozice>>> GetPozice()
        {
            return await _context.Pozice.ToListAsync();
        }

        // GET: api/Pozices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pozice>> GetPozice(long id)
        {
            var pozice = await _context.Pozice.FindAsync(id);

            if (pozice == null)
            {
                return NotFound();
            }

            return pozice;
        }

        // PUT: api/Pozices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPozice(long id, Pozice pozice)
        {
            if (id != pozice.Id)
            {
                return BadRequest();
            }

            _context.Entry(pozice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoziceExists(id))
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

        // POST: api/Pozices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pozice>> PostPozice(Pozice pozice)
        {
            _context.Pozice.Add(pozice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPozice", new { id = pozice.Id }, pozice);
        }

        // DELETE: api/Pozices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pozice>> DeletePozice(long id)
        {
            var pozice = await _context.Pozice.FindAsync(id);
            if (pozice == null)
            {
                return NotFound();
            }

            _context.Pozice.Remove(pozice);
            await _context.SaveChangesAsync();

            return pozice;
        }

        private bool PoziceExists(long id)
        {
            return _context.Pozice.Any(e => e.Id == id);
        }
    }
}
