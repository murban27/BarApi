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
    public class SekcesController : ControllerBase
    {
        private readonly restaurantvspjContext _context;

        public SekcesController(restaurantvspjContext context)
        {
            _context = context;
        }

        // GET: api/Sekces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sekce>>> GetSekce()
        {
            return await _context.Sekce.ToListAsync();
        }

        // GET: api/Sekces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sekce>> GetSekce(long id)
        {
            var sekce = await _context.Sekce.FindAsync(id);

            if (sekce == null)
            {
                return NotFound();
            }

            return sekce;
        }

        // PUT: api/Sekces/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSekce(long id, Sekce sekce)
        {
            if (id != sekce.Id)
            {
                return BadRequest();
            }

            _context.Entry(sekce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SekceExists(id))
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

        // POST: api/Sekces
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sekce>> PostSekce(Sekce sekce)
        {
            _context.Sekce.Add(sekce);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSekce", new { id = sekce.Id }, sekce);
        }

        // DELETE: api/Sekces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sekce>> DeleteSekce(long id)
        {
            var sekce = await _context.Sekce.FindAsync(id);
            if (sekce == null)
            {
                return NotFound();
            }

            _context.Sekce.Remove(sekce);
            await _context.SaveChangesAsync();

            return sekce;
        }

        private bool SekceExists(long id)
        {
            return _context.Sekce.Any(e => e.Id == id);
        }
    }
}
