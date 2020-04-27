using AutoMapper;
using ProductsFilter.Model.Domain.ProductDomain;
using ProductsFilter.Repository.Common;
using ProductsFilter.Repository.Models;
using System.Collections.Generic;

namespace ProductsFilter.Repository.Factories.Products
{
    public class ProductsFactory : FactoryBase, IProductsFactory
    {
        public ProductsFactory(IMapper mapper) : base(mapper)
        { }

        public IReadOnlyCollection<Product> ConvertToProducts(ProductsDto products)
        {
            return _mapper.Map<IReadOnlyCollection<Product>>(products.Products);
        }
    }
}
