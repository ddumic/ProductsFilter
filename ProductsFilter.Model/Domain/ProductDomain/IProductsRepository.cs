using ProductsFilter.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsFilter.Model.Domain.ProductDomain
{
    public interface IProductsRepository
    {
        Task<IReadOnlyCollection<Product>> GetAll(string url);
        Task<IReadOnlyCollection<Product>> GetAll(QueryExpression<Product> queryExpression, string url);
    }
}
