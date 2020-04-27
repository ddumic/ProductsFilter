using ProductsFilter.DiContainer.Registries;

namespace ProductsFilter.DiContainer
{
    public class LamarServiceRegistry : Lamar.ServiceRegistry
    {
        public LamarServiceRegistry()
        {
            IncludeRegistry<AutoMapperRegistry>();
            IncludeRegistry<ConfigurationRegistry>();
            IncludeRegistry<ModelRegistry>();
            IncludeRegistry<RepositoryRegistry>();
            IncludeRegistry<ServiceRegistry>();
        }
    }
}
