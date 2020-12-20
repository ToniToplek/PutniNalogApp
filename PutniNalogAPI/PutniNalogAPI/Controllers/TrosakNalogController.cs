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
    public class TrosakNalogController : ControllerBase
    {
        private readonly PutniNalogContext _context;

        public TrosakNalogController(PutniNalogContext context)
        {
            _context = context;
        }

        // GET: api/TrosakNalog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrosakNalog>>> GetTrosakNalogs()
        {
            return await _context.TrosakNalogs.ToListAsync();
        }

        // GET: api/TrosakNalog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrosakNalog>> GetTrosakNalog(int id)
        {
            var trosakNalog = await _context.TrosakNalogs.FindAsync(id);

            if (trosakNalog == null)
            {
                return NotFound();
            }

            return trosakNalog;
        }

        // PUT: api/TrosakNalog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrosakNalog(int id, TrosakNalog trosakNalog)
        {
            if (id != trosakNalog.IdTrosakNalog)
            {
                return BadRequest();
            }

            _context.Entry(trosakNalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrosakNalogExists(id))
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

        // POST: api/TrosakNalog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrosakNalog>> PostTrosakNalog(TrosakNalog trosakNalog)
        {
            _context.TrosakNalogs.Add(trosakNalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrosakNalog", new { id = trosakNalog.IdTrosakNalog }, trosakNalog);
        }

        // DELETE: api/TrosakNalog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrosakNalog(int id)
        {
            var trosakNalog = await _context.TrosakNalogs.FindAsync(id);
            if (trosakNalog == null)
            {
                return NotFound();
            }

            _context.TrosakNalogs.Remove(trosakNalog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrosakNalogExists(int id)
        {
            return _context.TrosakNalogs.Any(e => e.IdTrosakNalog == id);
        }
    }
}
