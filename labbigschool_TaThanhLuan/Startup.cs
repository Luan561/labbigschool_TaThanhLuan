using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(labbigschool_TaThanhLuan.Startup))]
namespace labbigschool_TaThanhLuan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
