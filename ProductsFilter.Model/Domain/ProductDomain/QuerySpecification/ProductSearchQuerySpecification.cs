using ProductsFilter.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsFilter.Model.Domain.ProductDomain.QuerySpecification
{
    public class ProductSearchQuerySpecification : IProductSearchQuerySpecification
    {
        private readonly IProductsRepository _productsRepository;

        public ProductSearchQuerySpecification(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IReadOnlyCollection<Product>> IsSatisfiedBy(ProductSearchQueryParams parameters)
        {
            var query = new QueryExpression<Product>();

            if (parameters.MaxPrice.HasValue)
                query.AddWhereExpression(x => x.Price <= parameters.MaxPrice.Value);

            if (parameters.Size.HasValue)
                query.AddWhereExpression(x => x.Sizes.Contains(parameters.Size.Value));

            var queryResult = await _productsRepository.GetAll(query, parameters.Url);
            return queryResult;
        }
    }
}
