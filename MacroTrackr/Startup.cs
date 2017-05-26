using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MacroTrackr.Startup))]
namespace MacroTrackr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
