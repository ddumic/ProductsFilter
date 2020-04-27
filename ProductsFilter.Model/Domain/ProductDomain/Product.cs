using ProductsFilter.Model.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProductsFilter.Model.Domain.ProductDomain
{
    public class Product : IAgregateRoot
    {
        #region Properties

        public string Title { get; set; }

        public long Price { get; set; }

        public IEnumerable<Size> Sizes { get; set; }

        public string Description { get; set; }

        public string ModifiedDescription { get; private set; }

        #endregion

        public void AddHtmlTags(string highlightString)
        {
            if (!string.IsNullOrWhiteSpace(highlightString))
            {
                var highlights = highlightString.Split(',');

                if (highlights.Any())
                {
                    foreach (var highlight in highlights)
                    {
                        ModifiedDescription = Regex.Replace(Description, $@"\b{highlight}\b", $"<em>{highlight}</em>");
                    }
                }
            }
        }
    }
}
