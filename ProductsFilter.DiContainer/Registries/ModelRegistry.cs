namespace ProductsFilter.DiContainer.Registries
{
    internal class ModelRegistry : Lamar.ServiceRegistry
    {
        public ModelRegistry()
        {
            Scan(_ =>
            {
                _.WithDefaultConventions();
                _.Assembly("ProductsFilter.Model");
                _.Include(type => type.Name.EndsWith("Specification"));
            });
        }
    }
}
