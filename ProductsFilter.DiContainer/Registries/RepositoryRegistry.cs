using ProductsFilter.Repository.Common;

namespace ProductsFilter.DiContainer.Registries
{
    internal class RepositoryRegistry : Lamar.ServiceRegistry
    {
        public RepositoryRegistry()
        {
            Scan(_ =>
            {
                _.WithDefaultConventions();
                _.Assembly("ProductsFilter.Repository");
                _.IncludeNamespace("ProductsFilter.Repository.Repositories");
                _.Include(type => type.BaseType == typeof(FactoryBase));
            });
        }
    }
}
