using System.Collections.Generic;

namespace ProductsFilter.Messaging
{
    public class ProductsRequestDto
    {
        public int? MaxPrice { get; set; }
        public ProductSize? Size { get; set; }
        public string Highlight { get; set; }
    }
}
