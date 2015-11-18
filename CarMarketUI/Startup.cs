using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarMarketUI.Startup))]
namespace CarMarketUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
