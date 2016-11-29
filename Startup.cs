using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataListTest.Startup))]
namespace DataListTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
