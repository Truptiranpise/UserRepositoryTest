using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserRepositories.Startup))]
namespace UserRepositories
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
