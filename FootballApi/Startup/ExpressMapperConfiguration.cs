using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpressMapper;
using FootballApi.CrossCuting;
using FootballApi.Domain;

namespace FootballApi.Startup
{
    public static class ExpressMapperConfiguration
    {
        public static void Configure()
        {
            var assemblies = new[]
            {
                typeof (Domain.AssemblyLocator).Assembly,
                typeof (Presentation.AssemblyLocator).Assembly
            };
            var types = assemblies.SelectMany(a => a.ExportedTypes);
            var registrations = from type in types
                where type.GetInterfaces()
                    .Any(i => i == typeof (IMapperRegistration))
                select type;

            foreach(var registration in registrations)
            {
                Activator.CreateInstance(registration);
            }

            ExpressMapper.Mapper.Compile();
        }
    }
}