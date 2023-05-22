using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegisterAndLoginSystem.Startup))]
namespace RegisterAndLoginSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
