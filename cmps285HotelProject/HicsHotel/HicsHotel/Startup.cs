using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HicsHotel.Startup))]
namespace HicsHotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
