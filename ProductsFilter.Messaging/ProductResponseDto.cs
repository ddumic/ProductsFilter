using System.Collections.Generic;

namespace ProductsFilter.Messaging
{
    public class ProductResponseDto
    {
        public string Title { get; set; }
        public long Price { get; set; }

        public IEnumerable<string> Sizes { get; set; }

        public string Description { get; set; }
    }
}
