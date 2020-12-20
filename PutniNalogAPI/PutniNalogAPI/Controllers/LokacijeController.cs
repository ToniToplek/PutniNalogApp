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
    public class LokacijeController : ControllerBase
    {
        private readonly PutniNalogContext _context;

        public LokacijeController(PutniNalogContext context)
        {
            _context = context;
        }

        // GET: api/Lokacije
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lokacije>>> GetLokacijes()
        {
            return await _context.Lokacijes.ToListAsync();
        }

        // GET: api/Lokacije/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lokacije>> GetLokacije(int id)
        {
            var lokacije = await _context.Lokacijes.FindAsync(id);

            if (lokacije == null)
            {
                return NotFound();
            }

            return lokacije;
        }

        // PUT: api/Lokacije/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLokacije(int id, Lokacije lokacije)
        {
            if (id != lokacije.IdLokacija)
            {
                return BadRequest();
            }

            _context.Entry(lokacije).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LokacijeExists(id))
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

        // POST: api/Lokacije
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lokacije>> PostLokacije(Lokacije lokacije)
        {
            _context.Lokacijes.Add(lokacije);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLokacije", new { id = lokacije.IdLokacija }, lokacije);
        }

        // DELETE: api/Lokacije/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLokacije(int id)
        {
            var lokacije = await _context.Lokacijes.FindAsync(id);
            if (lokacije == null)
            {
                return NotFound();
            }

            _context.Lokacijes.Remove(lokacije);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LokacijeExists(int id)
        {
            return _context.Lokacijes.Any(e => e.IdLokacija == id);
        }
    }
}
