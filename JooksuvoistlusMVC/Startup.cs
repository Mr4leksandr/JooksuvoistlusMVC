using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JooksuvoistlusMVC.Startup))]
namespace JooksuvoistlusMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
