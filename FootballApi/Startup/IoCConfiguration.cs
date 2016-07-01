using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.WebApi;

namespace FootballApi.Startup
{
    public static class IoCConfiguration
    {
        public static void Configure(IAppBuilder app, HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();
            container.RegisterSingleton<IOwinContextProvider>(new CallContextOwinContextProvider());
            container.RegisterWebApiControllers(config);
            container.Verify();

            app.Use(async (context, next) =>
            {
                using (container.BeginExecutionContextScope())
                {
                    CallContext.LogicalSetData("IOwinContext", context);
                    await next();
                }
            });

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }

    public interface IOwinContextProvider
    {
        IOwinContext CurrentContext { get; }
    }

    public class CallContextOwinContextProvider : IOwinContextProvider
    {
        public IOwinContext CurrentContext
        {
            get { return (IOwinContext)CallContext.LogicalGetData("IOwinContext"); }
        }
    }
}
