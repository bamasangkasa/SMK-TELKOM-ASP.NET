using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Univ.Startup))]
namespace Univ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
