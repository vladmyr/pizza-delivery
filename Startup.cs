using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PizzaDelivery01.Startup))]
namespace PizzaDelivery01
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
