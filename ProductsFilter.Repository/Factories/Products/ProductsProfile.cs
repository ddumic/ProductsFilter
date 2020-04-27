using AutoMapper;
using ProductsFilter.Model.Domain.ProductDomain;
using ProductsFilter.Repository.Models;
using System.Collections.Generic;

namespace ProductsFilter.Repository.Factories.Products
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}
