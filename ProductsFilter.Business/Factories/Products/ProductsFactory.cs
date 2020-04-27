using AutoMapper;
using ProductsFilter.Business.Common;
using ProductsFilter.Configuration.Common;
using ProductsFilter.Configuration.Sections;
using ProductsFilter.Messaging;
using ProductsFilter.Model.Domain.ProductDomain;
using ProductsFilter.Model.Domain.ProductDomain.QuerySpecification;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductsFilter.Business.Factories.Products
{
    public class ProductsFactory : FactoryBase, IProductsFactory
    {
        private readonly EndpointsConfigurationSection _endpointsConfigurationSection;
        private readonly FilterConfigurationSection _filterConfigurationSection;

        public ProductsFactory(IMapper mapper, IAppSettingsConfiguration configuration) : base(mapper, configuration)
        {
            _endpointsConfigurationSection = _configuration.GetConfigurationSection<EndpointsConfigurationSection>();
            _filterConfigurationSection = _configuration.GetConfigurationSection<FilterConfigurationSection>();
        }

        public ProductSearchQueryParams ConvertToProductSearchQueryParams(ProductsRequestDto request)
        {
            var queryParams = _mapper.Map<ProductSearchQueryParams>(request);
            queryParams.Url = _endpointsConfigurationSection.ProductsUrl;

            return queryParams;
        }

        public ProductsResponseDto MakeGetProductsResponse(IReadOnlyCollection<Product> products)
        {
            var productsResponse = _mapper.Map<ProductsResponseDto>(products);
            productsResponse.Sizes = GetSizes(products);
            productsResponse.MostCommonWordsInTheProductDescriptions = GetMostCommonWordsInTheProductDescriptions(products);

            return productsResponse;
        }

        private IEnumerable<string> GetSizes(IReadOnlyCollection<Product> src)
        {
            var result = new List<string>();

            if (src.Any() && src.Select(p => p.Sizes).Any())
            {
                foreach (var product in src)
                {
                    foreach (var size in product.Sizes)
                    {
                        result.Add(size.ToString());
                    }
                }
            }

            return result.Distinct();
        }

        private IEnumerable<string> GetMostCommonWordsInTheProductDescriptions(IReadOnlyCollection<Product> src)
        {
            var text = new StringBuilder();

            foreach (var product in src)
            {
                text.Append($" {product.Description.TrimEnd('.')}");
            }

            var allWords = text.ToString().Split(' ').Where(w => !string.IsNullOrWhiteSpace(w));

            var countedWords = allWords
                .GroupBy(w => w)
                .OrderByDescending(g => g.Count())
                .Skip(_filterConfigurationSection.Skip)
                .Take(_filterConfigurationSection.Take)
                .Select(g => g.Key);

            return countedWords;
        }
    }
}
