using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RequestViewer.Startup))]
namespace RequestViewer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
