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
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}
