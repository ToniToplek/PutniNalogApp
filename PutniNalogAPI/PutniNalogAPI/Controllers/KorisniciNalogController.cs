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
    public class KorisniciNalogController : ControllerBase
    {
        private readonly PutniNalogContext _context;

        public KorisniciNalogController(PutniNalogContext context)
        {
            _context = context;
        }

        // GET: api/KorisniciNalog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KorisniciNalog>>> GetKorisniciNalogs()
        {
            return await _context.KorisniciNalogs.ToListAsync();
        }

        // GET: api/KorisniciNalog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KorisniciNalog>> GetKorisniciNalog(int id)
        {
            var korisniciNalog = await _context.KorisniciNalogs.FindAsync(id);

            if (korisniciNalog == null)
            {
                return NotFound();
            }

            return korisniciNalog;
        }

        // PUT: api/KorisniciNalog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKorisniciNalog(int id, KorisniciNalog korisniciNalog)
        {
            if (id != korisniciNalog.idKorisniciNalog)
            {
                return BadRequest();
            }

            _context.Entry(korisniciNalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisniciNalogExists(id))
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

        // POST: api/KorisniciNalog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KorisniciNalog>> PostKorisniciNalog(KorisniciNalog korisniciNalog)
        {
            _context.KorisniciNalogs.Add(korisniciNalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKorisniciNalog", new { id = korisniciNalog.idKorisniciNalog }, korisniciNalog);
        }

        // DELETE: api/KorisniciNalog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisniciNalog(int id)
        {
            var korisniciNalog = await _context.KorisniciNalogs.FindAsync(id);
            if (korisniciNalog == null)
            {
                return NotFound();
            }

            _context.KorisniciNalogs.Remove(korisniciNalog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KorisniciNalogExists(int id)
        {
            return _context.KorisniciNalogs.Any(e => e.idKorisniciNalog == id);
        }
    }
}
