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
    public class TroskoviController : ControllerBase
    {
        private readonly PutniNalogContext _context;

        public TroskoviController(PutniNalogContext context)
        {
            _context = context;
        }

        // GET: api/Troskovi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Troskovi>>> GetTroskovis()
        {
            return await _context.Troskovis.ToListAsync();
        }

        // GET: api/Troskovi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Troskovi>> GetTroskovi(int id)
        {
            var troskovi = await _context.Troskovis.FindAsync(id);

            if (troskovi == null)
            {
                return NotFound();
            }

            return troskovi;
        }

        // PUT: api/Troskovi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTroskovi(int id, Troskovi troskovi)
        {
            if (id != troskovi.IdTrosak)
            {
                return BadRequest();
            }

            _context.Entry(troskovi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TroskoviExists(id))
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

        // POST: api/Troskovi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Troskovi>> PostTroskovi(Troskovi troskovi)
        {
            _context.Troskovis.Add(troskovi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTroskovi", new { id = troskovi.IdTrosak }, troskovi);
        }

        // DELETE: api/Troskovi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTroskovi(int id)
        {
            var troskovi = await _context.Troskovis.FindAsync(id);
            if (troskovi == null)
            {
                return NotFound();
            }

            _context.Troskovis.Remove(troskovi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TroskoviExists(int id)
        {
            return _context.Troskovis.Any(e => e.IdTrosak == id);
        }
    }
}
