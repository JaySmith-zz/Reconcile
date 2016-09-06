using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reconcile.Web.Startup))]
namespace Reconcile.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
