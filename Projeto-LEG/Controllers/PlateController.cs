using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_LEG.Modelos;

namespace Projeto_LEG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Plate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plate>>> GetPlates()
        {
            return await _context.Plates.ToListAsync();
        }

        // GET: api/Plate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plate>> GetPlate(int id)
        {
            var plate = await _context.Plates.FindAsync(id);

            if (plate == null)
            {
                return NotFound();
            }

            return plate;
        }

        // PUT: api/Plate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlate(int id, Plate plate)
        {
            if (id != plate.PlateId)
            {
                return BadRequest();
            }

            _context.Entry(plate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlateExists(id))
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

        // POST: api/Plate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plate>> PostPlate(Plate plate)
        {
            _context.Plates.Add(plate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlate", new { id = plate.PlateId }, plate);
        }

        // DELETE: api/Plate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlate(int id)
        {
            var plate = await _context.Plates.FindAsync(id);
            if (plate == null)
            {
                return NotFound();
            }

            _context.Plates.Remove(plate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlateExists(int id)
        {
            return _context.Plates.Any(e => e.PlateId == id);
        }
    }
}
