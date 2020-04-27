using Microsoft.Extensions.Configuration;
using ProductsFilter.Configuration.Common;
using System;

namespace ProductsFilter.Configuration
{
    public class AppSettingsConfiguration : IAppSettingsConfiguration
    {
        private readonly IConfiguration _configuration;

        public AppSettingsConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TConfigurationSection GetConfigurationSection<TConfigurationSection>() where TConfigurationSection : IAppSettingsConfigurationSection
        {
            TConfigurationSection section = (TConfigurationSection)Activator.CreateInstance(typeof(TConfigurationSection));
            _configuration.Bind(typeof(TConfigurationSection).Name, section);
            return section;
        }
    }
}
