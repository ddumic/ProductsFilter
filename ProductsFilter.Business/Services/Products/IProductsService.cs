using ProductsFilter.Messaging;
using System.Threading.Tasks;

namespace ProductsFilter.Business.Services.Products
{
    public interface IProductsService
    {
        Task<ProductsResponseDto> GetProducts(ProductsRequestDto request);
    }
}
