using ProductsFilter.Messaging;
using ProductsFilter.Model.Domain.ProductDomain;
using ProductsFilter.Model.Domain.ProductDomain.QuerySpecification;
using System.Collections.Generic;

namespace ProductsFilter.Business.Factories.Products
{
    public interface IProductsFactory
    {
        ProductSearchQueryParams ConvertToProductSearchQueryParams(ProductsRequestDto request);
        ProductsResponseDto MakeGetProductsResponse(IReadOnlyCollection<Product> products);
    }
}
