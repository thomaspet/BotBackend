using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BotBackend.Models.contexts
{
    public class ConfigureContext
    {

        public static void AddDbContexts(IServiceCollection services)
        {
            services.AddDbContext<MemberContext>(opt =>
                   opt.UseInMemoryDatabase("MemberList"));
        }

    }

}
