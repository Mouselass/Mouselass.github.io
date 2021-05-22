using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnetcore_api.DBContext;
using aspnetcore_api.Models;

namespace aspnetcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly ComputerWorkshopDBContext _context;

        public ApplicationsController(ComputerWorkshopDBContext context)
        {
            _context = context;
        }

        // GET: api/Applications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationDTO>>> GetApplications()
        {
            return await _context.Applications.Select(x => ApplicationToDTO(x)).ToListAsync();
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationDTO>> GetApplication(long id)
        {
            var todoItem = await _context.Applications.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return ApplicationToDTO(todoItem);
        }

        // PUT: api/Applications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication(long id, ApplicationDTO applicationDTO)
        {
            if (id != applicationDTO.Id)
            {
                return BadRequest();
            }

            var todoItem = await _context.Applications.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.PersonalData = applicationDTO.PersonalData;
            todoItem.Problem = applicationDTO.Problem;
            todoItem.DescriptionOfProblem = applicationDTO.DescriptionOfProblem;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ApplicationExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationDTO>> CreateApplication(ApplicationDTO applicationDTO)
        {
            var application = new Application
            {
                PersonalData = applicationDTO.PersonalData,
                Problem = applicationDTO.Problem,
                DescriptionOfProblem = applicationDTO.DescriptionOfProblem
            };

            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetApplication), new { id = application.Id }, ApplicationToDTO(application));
        }

        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(long id)
        {
            var todoItem = await _context.Applications.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationExists(long id) => _context.Applications.Any(e => e.Id == id);

        private static ApplicationDTO ApplicationToDTO(Application application) =>
            new ApplicationDTO
            {
                Id = application.Id,
                PersonalData = application.PersonalData,
                Problem = application.Problem,
                DescriptionOfProblem = application.DescriptionOfProblem
            };
    }
}
