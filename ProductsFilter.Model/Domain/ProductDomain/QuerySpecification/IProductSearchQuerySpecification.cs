using ProductsFilter.Model.Common;

namespace ProductsFilter.Model.Domain.ProductDomain.QuerySpecification
{
    public interface IProductSearchQuerySpecification : IQueryWithParamsSpecification<Product, ProductSearchQueryParams>
    {
    }
}
