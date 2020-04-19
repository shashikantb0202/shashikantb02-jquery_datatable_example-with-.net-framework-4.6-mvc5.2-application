using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmpAssignment.Startup))]
namespace EmpAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
