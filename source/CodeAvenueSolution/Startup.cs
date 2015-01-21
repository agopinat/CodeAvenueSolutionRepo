using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeAvenueSolution.Startup))]
namespace CodeAvenueSolution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
