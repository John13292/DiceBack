#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiceBack.Data;
using DiceBack.Models;

namespace DiceBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EffectsController : ControllerBase
    {
        private readonly DiceBackContext _context;

        public EffectsController(DiceBackContext context)
        {
            _context = context;
        }

        // GET: api/Effects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Effects>>> GetEffects()
        {
            return await _context.Effects.ToListAsync();
        }

        // GET: api/Effects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Effects>> GetEffects(int id)
        {
            var effects = await _context.Effects.FindAsync(id);

            if (effects == null)
            {
                return NotFound();
            }

            return effects;
        }

        // PUT: api/Effects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEffects(int id, Effects effects)
        {
            if (id != effects.Id)
            {
                return BadRequest();
            }

            _context.Entry(effects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EffectsExists(id))
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

        // POST: api/Effects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Effects>> PostEffects(Effects effects)
        {
            _context.Effects.Add(effects);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEffects", new { id = effects.Id }, effects);
        }

        // DELETE: api/Effects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEffects(int id)
        {
            var effects = await _context.Effects.FindAsync(id);
            if (effects == null)
            {
                return NotFound();
            }

            _context.Effects.Remove(effects);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EffectsExists(int id)
        {
            return _context.Effects.Any(e => e.Id == id);
        }
    }
}
