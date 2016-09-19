using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingListVersion2.Startup))]
namespace ShoppingListVersion2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
