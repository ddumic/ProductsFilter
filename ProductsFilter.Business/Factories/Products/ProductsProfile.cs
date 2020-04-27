using AutoMapper;
using ProductsFilter.Messaging;
using ProductsFilter.Model.Domain.ProductDomain;
using ProductsFilter.Model.Domain.ProductDomain.QuerySpecification;
using System.Collections.Generic;
using System.Linq;

namespace ProductsFilter.Business.Factories.Products
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<ProductsRequestDto, ProductSearchQueryParams>();

            CreateMap<IReadOnlyCollection<Product>, ProductsResponseDto>()
                .ForMember(dest => dest.MinPrice, opt => opt.MapFrom(src => src.Any() ? src.Min(p => p.Price) : 0))
                .ForMember(dest => dest.MaxPrice, opt => opt.MapFrom(src => src.Any() ? src.Max(p => p.Price) : 0))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src));

            CreateMap<Product, ProductResponseDto>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ModifiedDescription));
        }


    }
}
