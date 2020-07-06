using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen.Models;

namespace Examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalibrationsController : ControllerBase
    {
        private readonly ExamenDbContext _context;

        public CalibrationsController(ExamenDbContext context)
        {
            _context = context;
        }

        // GET: api/Calibrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calibration>>> GetCalibrations()
        {
            return await _context.Calibrations.ToListAsync();
        }

        // GET: api/Calibrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calibration>> GetCalibration(long id)
        {
            var calibration = await _context.Calibrations.FindAsync(id);

            if (calibration == null)
            {
                return NotFound();
            }

            return calibration;
        }

        // PUT: api/Calibrations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalibration(long id, Calibration calibration)
        {
            if (id != calibration.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(calibration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalibrationExists(id))
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

        // POST: api/Calibrations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Calibration>> PostCalibration(Calibration calibration)
        {
            _context.Calibrations.Add(calibration);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CalibrationExists(calibration.PersonId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCalibration", new { id = calibration.PersonId }, calibration);
        }

        // DELETE: api/Calibrations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Calibration>> DeleteCalibration(long id)
        {
            var calibration = await _context.Calibrations.FindAsync(id);
            if (calibration == null)
            {
                return NotFound();
            }

            _context.Calibrations.Remove(calibration);
            await _context.SaveChangesAsync();

            return calibration;
        }

        private bool CalibrationExists(long id)
        {
            return _context.Calibrations.Any(e => e.PersonId == id);
        }
    }
}
