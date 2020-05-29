using Microsoft.EntityFrameworkCore;

namespace BotBackend.Models.contexts
{
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> options) : base(options)
        {  }

        public DbSet<Member> Members { get; set; }
    }
}
