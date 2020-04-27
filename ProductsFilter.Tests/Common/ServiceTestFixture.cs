using AutoMapper;
using Moq;
using ProductsFilter.Configuration.Common;
using ProductsFilter.Configuration.Sections;
using System;
using System.Linq;
using System.Reflection;

namespace ProductsFilter.Tests.Common
{
    public abstract class ServiceTestFixture
    {
        public IMapper Mapper { get; }

        public IAppSettingsConfiguration Configuration { get; }

        public ServiceTestFixture()
        {
            Mapper = GetAutoMapperInstance();
            Configuration = GetConfigurationInstance();
        }

        private IMapper GetAutoMapperInstance()
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
            return config.CreateMapper();
        }

        private IAppSettingsConfiguration GetConfigurationInstance()
        {
            var mock = new Mock<IAppSettingsConfiguration>();

            mock
                .Setup(_ => _.GetConfigurationSection<EndpointsConfigurationSection>())
                .Returns(new EndpointsConfigurationSection());

            mock
               .Setup(_ => _.GetConfigurationSection<FilterConfigurationSection>())
               .Returns(new FilterConfigurationSection());

            return mock.Object;
        }
    }
}
