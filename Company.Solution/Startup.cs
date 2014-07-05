using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Company.Solution.Startup))]
namespace Company.Solution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
