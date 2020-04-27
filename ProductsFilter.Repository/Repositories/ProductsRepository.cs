using AutoMapper;
using ProductsFilter.Model.Common;
using ProductsFilter.Model.Domain.ProductDomain;
using ProductsFilter.Repository.Common;
using ProductsFilter.Repository.Factories.Products;
using ProductsFilter.Repository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsFilter.Repository.Repositories
{
    public class ProductsRepository : HttpRepositoryBase, IProductsRepository
    {
        private readonly IProductsFactory _productsFactory;

        public ProductsRepository(IProductsFactory productsFactory)
        {
            _productsFactory = productsFactory;
        }

        public async Task<IReadOnlyCollection<Product>> GetAll(string url)
        {
            var response = await Get<ProductsDto>(url);
            return _productsFactory.ConvertToProducts(response);
        }

        public async Task<IReadOnlyCollection<Product>> GetAll(QueryExpression<Product> queryExpression, string url)
        {
            var result = await GetAll(url);

            var dynamicQuery = result.AsQueryable();
            dynamicQuery = AppendWhereExpressions(dynamicQuery, queryExpression);
            var dynamicQueryResult = dynamicQuery.ToList();

            return dynamicQueryResult;
        }
    }
}
