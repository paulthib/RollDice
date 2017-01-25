using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RollDice.Startup))]
namespace RollDice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
