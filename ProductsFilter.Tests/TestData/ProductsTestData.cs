using ProductsFilter.Messaging;
using ProductsFilter.Model.Domain.ProductDomain;
using System.Collections.Generic;

namespace ProductsFilter.Tests.TestData
{
    public static class ProductsTestData
    {
        #region Request

        public static ProductsRequestDto ProductsRequest => new ProductsRequestDto
        {
            Highlight = "green",
            MaxPrice = 10,
            Size = ProductSize.Small
        };

        public static ProductsRequestDto ProductsRequestWithLowMaxPrice => new ProductsRequestDto
        {
            Highlight = "green",
            MaxPrice = 1,
            Size = ProductSize.Small
        };

        public static ProductsRequestDto EmptyProductsRequest => new ProductsRequestDto();

        #endregion

        #region Response

        public static List<Product> EmptyProducts => new List<Product>();

        public static List<Product> SingleProduct => new List<Product>
        {
            new Product
            {
                Description = "This trouser perfectly pairs with a green shirt.",
                Price = 10,
                Sizes = new List<Size>{ Size.Small, Size.Medium,Size.Large },
                Title = "A Red Trouser"
            }
        };

        public static List<Product> MultipleProducts => new List<Product>
        {
            new Product
            {
                Description = "test This trouser perfectly pairs with a green shirt.",
                Price = 10,
                Sizes = new List<Size>{ Size.Small, Size.Medium,Size.Large },
                Title = "A Red Trouser"
            },
            new Product
            {
                Description = "test text.",
                Price = 10,
                Sizes = new List<Size>{ Size.Small, Size.Medium,Size.Large },
                Title = "A Blue Trouser"
            }
        };

        #endregion
    }
}
