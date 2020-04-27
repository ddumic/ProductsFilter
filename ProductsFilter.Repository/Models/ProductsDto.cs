using System.Collections.Generic;

namespace ProductsFilter.Repository.Models
{
    public class ProductsDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
