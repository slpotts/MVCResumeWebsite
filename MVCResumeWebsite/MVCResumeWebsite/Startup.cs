using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCResumeWebsite.Startup))]
namespace MVCResumeWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
