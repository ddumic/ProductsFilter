using Moq;
using ProductsFilter.Business.Factories.Products;
using ProductsFilter.Business.Services.Products;
using ProductsFilter.Model.Domain.ProductDomain.QuerySpecification;
using ProductsFilter.Tests.Common;
using System;

namespace ProductsFilter.Tests.Fixtures.Services
{
    public class ProductsServiceTestFixture : ServiceTestFixture, IDisposable
    {
        public IProductsService ProductsService { get; }

        public Mock<IProductSearchQuerySpecification> ProductSearchQuerySpecificationMock { get; }

        public IProductsFactory ProductsFactory { get; }

        public ProductsServiceTestFixture()
        {
            ProductsFactory = new ProductsFactory(Mapper, Configuration);
            ProductSearchQuerySpecificationMock = new Mock<IProductSearchQuerySpecification>();

            ProductsService = new ProductsService(ProductSearchQuerySpecificationMock.Object, ProductsFactory);
        }

        public void Dispose()
        {
        }
    }
}
