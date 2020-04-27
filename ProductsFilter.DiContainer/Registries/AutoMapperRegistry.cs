using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace ProductsFilter.DiContainer.Registries
{
    internal class AutoMapperRegistry : Lamar.ServiceRegistry
    {
        public AutoMapperRegistry()
        {
            //get all service profiles
            var serviceProfiles = from t in Assembly.Load("ProductsFilter.Business").GetTypes()
                                  where typeof(Profile).IsAssignableFrom(t)
                                  select (Profile)Activator.CreateInstance(t);

            //get all service profiles
            var repositoryProfiles = from t in Assembly.Load("ProductsFilter.Repository").GetTypes()
                                     where typeof(Profile).IsAssignableFrom(t)
                                     select (Profile)Activator.CreateInstance(t);

            //For each Profile, include that profile in the MapperConfiguration
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in serviceProfiles)
                {
                    cfg.AddProfile(profile);
                }

                foreach (var profile in repositoryProfiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            //Create a mapper that will be used by the DI container
            IMapper mapper = config.CreateMapper();

            //Register the DI interfaces with their implementation
            For<IConfigurationProvider>().Use(config);
            For<IMapper>().Use(mapper);
        }
    }
}
