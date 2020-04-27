using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using ProductsFilter.Model.Domain.ProductDomain.QuerySpecification;
using ProductsFilter.Tests.Fixtures.Services;
using ProductsFilter.Tests.TestData;
using System.Threading.Tasks;
using Xunit;

namespace ProductsFilter.Tests.ServiceTests.Services
{
    public class ProductsServiceShould : IClassFixture<ProductsServiceTestFixture>
    {
        private readonly ProductsServiceTestFixture _fixture;

        public ProductsServiceShould(ProductsServiceTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ReturnNoProducts_When_MaxPriceIsTooLow()
        {
            //Arrange
            var dto = ProductsTestData.ProductsRequestWithLowMaxPrice;

            _fixture.ProductSearchQuerySpecificationMock
                .Setup(_ => _.IsSatisfiedBy(It.IsAny<ProductSearchQueryParams>()))
                .ReturnsAsync(ProductsTestData.EmptyProducts);

            //Act
            var response = await _fixture.ProductsService.GetProducts(dto);

            //Assert
            response.Products.Should().HaveCount(0);
        }

        [Fact]
        public async Task ReturnAllProducts_When_NoFilter()
        {
            //Arrange
            var dto = ProductsTestData.EmptyProductsRequest;

            _fixture.ProductSearchQuerySpecificationMock
                .Setup(_ => _.IsSatisfiedBy(It.IsAny<ProductSearchQueryParams>()))
                .ReturnsAsync(ProductsTestData.SingleProduct);

            //Act
            var response = await _fixture.ProductsService.GetProducts(dto);

            //Assert
            response.Products.Should().HaveCount(1);
        }

        [Fact]
        public async Task ReturnProducts_When_MatchingFilter()
        {
            //Arrange
            var dto = ProductsTestData.ProductsRequest;

            _fixture.ProductSearchQuerySpecificationMock
               .Setup(_ => _.IsSatisfiedBy(It.IsAny<ProductSearchQueryParams>()))
               .ReturnsAsync(ProductsTestData.SingleProduct);

            //Act
            var response = await _fixture.ProductsService.GetProducts(dto);

            //Assert
            using (new AssertionScope())
            {
                response.Products.Should().HaveCount(1);
                response.Products.Should().Contain(x => x.Description.Contains("<em>green</em>"));
                response.Products.Should().NotContain(x => x.Description.Contains("<em>red</em>"));
            }
        }
    }
}
