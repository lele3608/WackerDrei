using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WackerDrei.Startup))]
namespace WackerDrei
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
