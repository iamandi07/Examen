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
    public class InspectionPlansController : ControllerBase
    {
        private readonly ExamenDbContext _context;

        public InspectionPlansController(ExamenDbContext context)
        {
            _context = context;
        }

        // GET: api/InspectionPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionPlan>>> GetInspectionPlans()
        {
            IQueryable<InspectionPlan> result = _context.InspectionPlans;
            var resultList = await result.OrderByDescending(t => t.Description).ToListAsync();
            return resultList;
        }

        // GET: api/InspectionPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionPlan>> GetInspectionPlan(long id)
        {
            var inspectionPlan = await _context.InspectionPlans.FindAsync(id);

            if (inspectionPlan == null)
            {
                return NotFound();
            }

            return inspectionPlan;
        }

        // PUT: api/InspectionPlans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspectionPlan(long id, InspectionPlan inspectionPlan)
        {
            if (id != inspectionPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(inspectionPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionPlanExists(id))
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

        // POST: api/InspectionPlans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InspectionPlan>> PostInspectionPlan(InspectionPlan inspectionPlan)
        {
            _context.InspectionPlans.Add(inspectionPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspectionPlan", new { id = inspectionPlan.Id }, inspectionPlan);
        }

        // DELETE: api/InspectionPlans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InspectionPlan>> DeleteInspectionPlan(long id)
        {
            var inspectionPlan = await _context.InspectionPlans.FindAsync(id);
            if (inspectionPlan == null)
            {
                return NotFound();
            }

            _context.InspectionPlans.Remove(inspectionPlan);
            await _context.SaveChangesAsync();

            return inspectionPlan;
        }

        private bool InspectionPlanExists(long id)
        {
            return _context.InspectionPlans.Any(e => e.Id == id);
        }
    }
}
