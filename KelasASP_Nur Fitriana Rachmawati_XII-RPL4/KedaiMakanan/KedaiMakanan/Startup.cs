using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KedaiMakanan.Startup))]
namespace KedaiMakanan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
