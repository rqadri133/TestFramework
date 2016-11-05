using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestFrameworkPortal.Startup))]
namespace TestFrameworkPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
