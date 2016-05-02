using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TreinoFacil.Startup))]
namespace TreinoFacil
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
