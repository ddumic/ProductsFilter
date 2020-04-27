using ProductsFilter.Configuration;
using ProductsFilter.Configuration.Common;

namespace ProductsFilter.DiContainer.Registries
{
    internal class ConfigurationRegistry : Lamar.ServiceRegistry
    {
        public ConfigurationRegistry()
        {
            Scan(_ =>
            {
                _.WithDefaultConventions();
                _.Assembly("ProductsFilter.Configuration");
                _.IncludeNamespace("ProductsFilter.Configuration.Sections");
            });

            For<IAppSettingsConfiguration>().Use<AppSettingsConfiguration>();
        }
    }
}
