using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Food_Order_Website.Startup))]
namespace Food_Order_Website
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
