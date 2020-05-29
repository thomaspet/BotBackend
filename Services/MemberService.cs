using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotBackend.Models;
using BotBackend.Models.contexts;

namespace BotBackend.Services
{
    public interface IMemberService
    {
        Task<List<Member>> GetAll();
        Task<Member> Get(long id);
        Task Put(long id, Member member);
        Task Add(Member member);
        Task Remove(Member member);
    }

    public class MemberService : IMemberService
    {
        private readonly MemberContext _context;
        public MemberService(MemberContext context)
        {
            _context = context;
        }

        public async Task<List<Member>> GetAll()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> Get(long id)
        {
            var member = await _context.Members.FindAsync(id);

            return member;
        }

        public async Task Put(long id, Member member)
        {
            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
                {
                    throw new MemberNotFoundException(id);
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task Add(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Member member)
        {
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }

        private bool MemberExists(long id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }

    public class MemberNotFoundException : Exception
    {
        public long Id;
        public MemberNotFoundException(long id)
        {
            Id = id;
        }
    }
}
