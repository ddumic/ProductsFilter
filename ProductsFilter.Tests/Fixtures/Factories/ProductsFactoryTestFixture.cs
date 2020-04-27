using ProductsFilter.Business.Factories.Products;
using ProductsFilter.Tests.Common;
using System;

namespace ProductsFilter.Tests.Fixtures.Factories
{
    public class ProductsFactoryTestFixture : FactoryTestFixture, IDisposable
    {
        public IProductsFactory ProductsFactory { get; }

        public ProductsFactoryTestFixture()
        {
            ProductsFactory = new ProductsFactory(Mapper, Configuration);
        }

        public void Dispose()
        {
        }
    }
}
