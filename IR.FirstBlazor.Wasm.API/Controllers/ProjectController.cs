using IR.FirstBlazorWasm.DAL;
using IR.FirstBlazorWasm.DAL.Entities;
using IR.FirstBlazorWasm.Dto.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IR.FirstBlazor.Wasm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly MultiPlannerContext _context;

        public ProjectController(MultiPlannerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectOut>>> Get()
        {
            return Ok(await _context.Projects.ToListAsync());
        }

        [HttpPut("{name}")]
        public async Task<ActionResult> Save(string name, [FromBody] ProjectIn projectIn)
        {
            var project = await _context.Projects.Where(p => p.Name == name).FirstOrDefaultAsync();
            // if project with name doesnt exist create new
            if (project is null)
            {
                var newProject = new Project()
                {
                    Name = projectIn.Name,
                    StartDate = projectIn.StartDate,
                    EndDate = projectIn.EndDate,
                    Customer = projectIn.Customer,
                    MaxHours = projectIn.MaxHours
                };
                _context.Projects.Add(newProject);
                await _context.SaveChangesAsync();

                return Ok(newProject);
            }

            // if project with name exists, update
            project.Name = projectIn.Name;
            project.StartDate = projectIn.StartDate;
            project.EndDate = projectIn.EndDate;
            project.Customer = projectIn.Customer;
            project.MaxHours = projectIn.MaxHours;

            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return Ok(project);
        }


        [HttpDelete("{name}")]
        public async Task<ActionResult> Delete(string name)
        {
            var project = await _context.Projects.Where(p => p.Name == name).FirstOrDefaultAsync();

            if (project is null)
            {
                return NotFound();
            }

            _context.Remove(project);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
