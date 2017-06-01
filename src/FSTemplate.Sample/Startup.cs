using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FSTemplate.Sample.Startup))]
namespace FSTemplate.Sample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
