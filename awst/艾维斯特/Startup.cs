using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(艾维斯特.Startup))]
namespace 艾维斯特
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
