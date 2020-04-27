using System.Collections.Generic;

namespace ProductsFilter.Messaging
{
    public class ProductsResponseDto
    {
        public long MinPrice { get; set; }
        public long MaxPrice { get; set; }
        public IEnumerable<string> Sizes { get; set; }
        public IEnumerable<string> MostCommonWordsInTheProductDescriptions { get; set; }
        public IEnumerable<ProductResponseDto> Products { get; set; }
    }
}
