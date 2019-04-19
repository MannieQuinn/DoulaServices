using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoulaServices.WebMVC.Startup))]
namespace DoulaServices.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
