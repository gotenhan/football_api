using System;
using System.Threading.Tasks;
using System.Web.Http;
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
            var httpConfiguration = new HttpConfiguration();
            WebApiConfiguration.Configure(app, httpConfiguration);
            IoCConfiguration.Configure(app, httpConfiguration);
            ExpressMapperConfiguration.Configure();
        }
    }
}
