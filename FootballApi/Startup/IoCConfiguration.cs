using System;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using FootballApi.CrossCuting;
using FootballApi.Data;
using FootballApi.Data.Repositories;
using FootballApi.Domain.Repositories;
using FootballApi.Domain.Services;
using Microsoft.Owin;
using Owin;
using SimpleInjector;
using SimpleInjector.Diagnostics;
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

            container.Register(typeof(IMapper<,>), typeof(Mapper<,>), Lifestyle.Singleton);
            container.Register<FootballApiContext>(Lifestyle.Scoped);
            container.RegisterDisposableTransient<IAddGameResultUnitOfWork, AddGameResultUnitOfWork>();
            container.Register<IAddGameResultService, AddGameResultService>();
            container.Register<IGameResultRepository, GameResultRepository>();
            container.Register<ITeamRepository, TeamRepository>();
            container.Register<ITableService, TableService>();

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
        public IOwinContext CurrentContext => (IOwinContext)CallContext.LogicalGetData("IOwinContext");
    }

    public static class SimpleInjectorExtensions
    {
        public static void RegisterDisposableTransient<TService, TImplementation>(
            this Container container)
            where TImplementation : class, IDisposable, TService
            where TService : class
        {
            var scoped = Lifestyle.Scoped;
            var reg = Lifestyle.Transient.CreateRegistration<TService, TImplementation>(container);
            reg.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "suppressed.");
            container.AddRegistration(typeof(TService), reg);
            container.RegisterInitializer<TImplementation>(o => scoped.RegisterForDisposal(container, o));
        }
    }

}
