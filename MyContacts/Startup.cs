using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyContacts.Startup))]
namespace MyContacts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
