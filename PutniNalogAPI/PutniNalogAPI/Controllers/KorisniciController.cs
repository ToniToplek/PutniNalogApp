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
    public class KorisniciController : ControllerBase
    {
        private readonly PutniNalogContext _context;

        public KorisniciController(PutniNalogContext context)
        {
            _context = context;
        }

        // GET: api/Korisnici
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Korisnici>>> GetKorisnicis()
        {
            return await _context.Korisnicis.ToListAsync();
        }

        // GET: api/Korisnici/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Korisnici>> GetKorisnici(int id)
        {
            var korisnici = await _context.Korisnicis.FindAsync(id);

            if (korisnici == null)
            {
                return NotFound();
            }

            return korisnici;
        }

        // PUT: api/Korisnici/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKorisnici(int id, Korisnici korisnici)
        {
            if (id != korisnici.IdKorisnik)
            {
                return BadRequest();
            }

            _context.Entry(korisnici).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisniciExists(id))
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

        // POST: api/Korisnici
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Korisnici>> PostKorisnici(Korisnici korisnici)
        {
            _context.Korisnicis.Add(korisnici);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKorisnici", new { id = korisnici.IdKorisnik }, korisnici);
        }

        // DELETE: api/Korisnici/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisnici(int id)
        {
            var korisnici = await _context.Korisnicis.FindAsync(id);
            if (korisnici == null)
            {
                return NotFound();
            }

            _context.Korisnicis.Remove(korisnici);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KorisniciExists(int id)
        {
            return _context.Korisnicis.Any(e => e.IdKorisnik == id);
        }
    }
}
