using IR.FirstBlazorWasm.DAL;
using IR.FirstBlazorWasm.DAL.Entities;
using IR.FirstBlazorWasm.Dto.Member;
using Microsoft.AspNetCore.Http;
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
    public class MemberController : ControllerBase
    {
        private readonly MultiPlannerContext _context;

        public MemberController(MultiPlannerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberOut>>> Get()
        {
            return Ok(await _context.Members.ToListAsync());
        }

        [HttpPut("{email}")]
        public async Task<ActionResult> Save(string email, [FromBody] MemberIn memberIn)
        {
            var member = await _context.Members.Where(m => m.Email == email).FirstOrDefaultAsync();
            // if member with email doesnt exist create new
            if (member is null)
            {
                var newMember = new Member()
                {
                    Email = memberIn.Email,
                    FirstName = memberIn.FirstName,
                    LastName = memberIn.LastName,
                    Capacity = memberIn.Capacity
                };
                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                return Ok(newMember);
            }

            // if member with email exists, update

            member.Email = memberIn.Email;
            member.FirstName = memberIn.FirstName;
            member.LastName = memberIn.LastName;
            member.Capacity = memberIn.Capacity;

            _context.Members.Update(member);
            await _context.SaveChangesAsync();
            return Ok(member); 
        }
    
    
        [HttpDelete("{email}")]
        public async Task<ActionResult> Delete(string email)
        {
            var member = await _context.Members.Where(m => m.Email == email).FirstOrDefaultAsync();

            if (member is null)
            {
                return NotFound();
            }

            _context.Remove(member);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
