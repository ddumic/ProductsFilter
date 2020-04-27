using ProductsFilter.Configuration.Common;

namespace ProductsFilter.Configuration.Sections
{
    public class FilterConfigurationSection : IAppSettingsConfigurationSection
    {
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
