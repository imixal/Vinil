using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vinil.Startup))]
namespace Vinil
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
