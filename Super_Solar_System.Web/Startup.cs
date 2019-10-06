using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Super_Solar_System.Web.Startup))]
namespace Super_Solar_System.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
