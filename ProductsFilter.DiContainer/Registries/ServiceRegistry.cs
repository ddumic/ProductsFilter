using ProductsFilter.Business.Common;

namespace ProductsFilter.DiContainer.Registries
{
    internal class ServiceRegistry : Lamar.ServiceRegistry
    {
        public ServiceRegistry()
        {
            Scan(_ =>
            {
                _.WithDefaultConventions();
                _.Assembly("ProductsFilter.Business");
                _.Include(type => type.BaseType == typeof(ServiceBase));
                _.Include(type => type.BaseType == typeof(FactoryBase));
            });
        }
    }
}
