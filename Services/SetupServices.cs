using SimpleInjector;

namespace BotBackend.Services
{
    public class SetupServices
    {
        public static Container SetupContainer(Container container = null)
        {
            if (container == null)
            {
                container = new Container();
            }

            container.Register<IMemberService, MemberService>();

            return container;
        }
    }
}
