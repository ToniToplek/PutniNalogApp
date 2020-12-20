using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PutniNalogAPI.Models;

namespace PutniNalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutiController : ControllerBase
    {
        private readonly PutniNalogContext _context;

        public AutiController(PutniNalogContext context)
        {
            _context = context;
        }

        // GET: api/Auti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auti>>> GetAutis()
        {
            return await _context.Autis.ToListAsync();
        }

        // GET: api/Auti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auti>> GetAuti(int id)
        {
            var auti = await _context.Autis.FindAsync(id);

            if (auti == null)
            {
                return NotFound();
            }

            return auti;
        }

        // PUT: api/Auti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuti(int id, Auti auti)
        {
            if (id != auti.IdAuto)
            {
                return BadRequest();
            }

            _context.Entry(auti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutiExists(id))
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

        // POST: api/Auti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auti>> PostAuti(Auti auti)
        {
            _context.Autis.Add(auti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuti", new { id = auti.IdAuto }, auti);
        }

        // DELETE: api/Auti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuti(int id)
        {
            var auti = await _context.Autis.FindAsync(id);
            if (auti == null)
            {
                return NotFound();
            }

            _context.Autis.Remove(auti);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutiExists(int id)
        {
            return _context.Autis.Any(e => e.IdAuto == id);
        }
    }
}
