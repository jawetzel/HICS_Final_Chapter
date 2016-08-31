using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cmps285HotelProject.Startup))]
namespace cmps285HotelProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
