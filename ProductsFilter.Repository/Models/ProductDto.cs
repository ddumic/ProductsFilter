using System.Collections.Generic;

namespace ProductsFilter.Repository.Models
{
    public class ProductDto
    {
        public string Title { get; set; }

        public long Price { get; set; }

        public IEnumerable<string> Sizes { get; set; }

        public string Description { get; set; }
    }
}
