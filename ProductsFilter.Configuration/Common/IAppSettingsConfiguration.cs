namespace ProductsFilter.Configuration.Common
{
    /// <summary>
    /// Dependency injection interface used for consuming configuration properties of selected configuration section. 
    /// </summary>
    public interface IAppSettingsConfiguration
    {
        /// <summary>
        /// Gets specified configuration section defined by TConfigurationSection
        /// </summary>
        /// <typeparam name="TConfigurationSection">Configuration section type</typeparam>
        /// <returns>Configuration section</returns>
        TConfigurationSection GetConfigurationSection<TConfigurationSection>() where TConfigurationSection : IAppSettingsConfigurationSection;
    }
}
