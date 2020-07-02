using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore.Query;
using WebApplication1.Helper;
using System.Collections.Immutable;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tables : ControllerBase
    {
        private readonly restaurantvspjContext _context;

        public Tables(restaurantvspjContext context)
        {
            _context = context;
        }

        // GET: api/Tabless
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tabless>>> GetTabless()
        {
        return await _context.Tabless.Include("Orders").ToListAsync();


          

        }

        // GET: api/Tabless/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tabless>> GetTabless(long id)
        {
            var Tabless = await _context.Tabless.FindAsync(id);

            if (Tabless == null)
            {
                return NotFound();
            }

            return Tabless;
        }

        // PUT: api/Tabless/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTabless(long id, Tabless Tabless)
        {
            if (id != Tabless.Id)
            {
                return BadRequest();
            }

            _context.Entry(Tabless).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TablessExists(id))
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

        // POST: api/Tabless
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tabless>> PostTabless(Tabless Tabless)
        {
            _context.Tabless.Add(Tabless);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTabless", new { id = Tabless.Id }, Tabless);
        }

        // DELETE: api/Tabless/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tabless>> DeleteTabless(long id)
        {
            var Tabless = await _context.Tabless.FindAsync(id);
            if (Tabless == null)
            {
                return NotFound();
            }

            _context.Tabless.Remove(Tabless);
            await _context.SaveChangesAsync();

            return Tabless;
        }

        private bool TablessExists(long id)
        {
            return _context.Tabless.Any(e => e.Id == id);
        }
    }
}
