using ProductsFilter.Business.Common;
using ProductsFilter.Business.Factories.Products;
using ProductsFilter.Messaging;
using ProductsFilter.Model.Domain.ProductDomain.QuerySpecification;
using System.Threading.Tasks;

namespace ProductsFilter.Business.Services.Products
{
    public class ProductsService : ServiceBase, IProductsService
    {
        private readonly IProductSearchQuerySpecification _productSearchQuerySpecification;
        private readonly IProductsFactory _productsFactory;

        public ProductsService(IProductSearchQuerySpecification productSearchQuerySpecification, IProductsFactory productsFactory)
        {
            _productSearchQuerySpecification = productSearchQuerySpecification;
            _productsFactory = productsFactory;
        }

        public async Task<ProductsResponseDto> GetProducts(ProductsRequestDto request)
        {
            var searchParams = _productsFactory.ConvertToProductSearchQueryParams(request);
            var products = await _productSearchQuerySpecification.IsSatisfiedBy(searchParams);

            foreach (var product in products)
            {
                product.AddHtmlTags(request.Highlight);
            }

            return _productsFactory.MakeGetProductsResponse(products);
        }
    }
}
