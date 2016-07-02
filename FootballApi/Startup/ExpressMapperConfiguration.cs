using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpressMapper;
using FootballApi.CrossCuting;

namespace FootballApi.Startup
{
    public static class ExpressMapperConfiguration
    {
        public static void Configure()
        {
            var registrations = from type in typeof (FootballApi.Presentation.AssemblyLocator).Assembly.ExportedTypes
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