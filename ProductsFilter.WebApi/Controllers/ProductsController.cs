using Microsoft.AspNetCore.Mvc;
using ProductsFilter.Business.Services.Products;
using ProductsFilter.Messaging;
using System.Threading.Tasks;

namespace ProductsFilter.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> Filter([FromQuery] ProductsRequestDto requestDto)
        {
            var response = await _productsService.GetProducts(requestDto);
            return Ok(response);
        }
    }
}