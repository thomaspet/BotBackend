using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BotBackend.Services;
using BotBackend.Models;

namespace BotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _members;

        public MembersController(IMemberService service)
        {
            _members = service;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            return await _members.GetAll();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(long id)
        {
            var member = await _members.Get(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(long id, Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            try
            {
                await _members.Put(id, member);
            }
            catch (MemberNotFoundException e)
            {
                return NotFound(e.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return NoContent();
        }

        // POST: api/Members
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            await _members.Add(member);
            return CreatedAtAction(nameof(GetMember), new { id = member.Id }, member);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(long id)
        {
            var member = await _members.Get(id);
            if (member == null)
            {
                return NotFound();
            }

            await _members.Remove(member);

            return member;
        }


    }
}
