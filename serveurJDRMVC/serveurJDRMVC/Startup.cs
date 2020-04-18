using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(serveurJDRMVC.Startup))]
namespace serveurJDRMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
