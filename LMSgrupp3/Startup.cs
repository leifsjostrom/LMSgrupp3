using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LMSgrupp3.Startup))]
namespace LMSgrupp3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
