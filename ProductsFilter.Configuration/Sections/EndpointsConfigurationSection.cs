using ProductsFilter.Configuration.Common;

namespace ProductsFilter.Configuration.Sections
{
    public class EndpointsConfigurationSection : IAppSettingsConfigurationSection
    {
        public string ProductsUrl { get; set; }
    }
}
