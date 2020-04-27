using ProductsFilter.Model.Domain.ProductDomain;
using ProductsFilter.Repository.Models;
using System.Collections.Generic;

namespace ProductsFilter.Repository.Factories.Products
{
    public interface IProductsFactory
    {
        IReadOnlyCollection<Product> ConvertToProducts(ProductsDto products);
    }
}
