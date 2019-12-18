using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_26_MVC1.Startup))]
namespace Lab_26_MVC1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
