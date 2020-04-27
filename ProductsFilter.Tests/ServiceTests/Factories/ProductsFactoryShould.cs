using FluentAssertions;
using FluentAssertions.Execution;
using ProductsFilter.Tests.Fixtures.Factories;
using ProductsFilter.Tests.TestData;
using System.Linq;
using Xunit;

namespace ProductsFilter.Tests.ServiceTests.Factories
{
    public class ProductsFactoryShould : IClassFixture<ProductsFactoryTestFixture>
    {
        private readonly ProductsFactoryTestFixture _fixture;

        public ProductsFactoryShould(ProductsFactoryTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ConvertToProductSearchQueryParams_From_ProductsRequestDto()
        {
            //Arrange
            var sourceParams = ProductsTestData.ProductsRequest;

            //Act
            var convertedParams = _fixture.ProductsFactory.ConvertToProductSearchQueryParams(sourceParams);

            //Assert
            convertedParams.MaxPrice.Should().Be(sourceParams.MaxPrice);
        }

        [Fact]
        public void MakeGetProductsResponse_From_Products()
        {
            //Arrange
            var sourceParams = ProductsTestData.MultipleProducts;

            //Act
            var convertedParams = _fixture.ProductsFactory.MakeGetProductsResponse(sourceParams);

            //Assert
            using (new AssertionScope())
            {
                convertedParams.MinPrice.Should().Be(sourceParams.Min(p => p.Price));
                convertedParams.MaxPrice.Should().Be(sourceParams.Max(p => p.Price));
                convertedParams.MostCommonWordsInTheProductDescriptions.First().Should().Be("test");
            }
        }
    }
}
