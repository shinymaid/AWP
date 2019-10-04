using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nicenicenice.Startup))]
namespace nicenicenice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
