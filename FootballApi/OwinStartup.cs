using System;
using System.Threading.Tasks;
using FootballApi.Startup;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FootballApi.OwinStartup))]

namespace FootballApi
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            WebApiConfiguration.Configure(app);
        }
    }
}
