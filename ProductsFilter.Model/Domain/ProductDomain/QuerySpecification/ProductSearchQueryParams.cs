using ProductsFilter.Model.Common;

namespace ProductsFilter.Model.Domain.ProductDomain.QuerySpecification
{
    public class ProductSearchQueryParams : QueryParameters
    {
        public string Url { get; set; }
        public int? MaxPrice { get; set; }
        public Size? Size { get; set; }
    }
}
