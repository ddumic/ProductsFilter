namespace ProductsFilter.Configuration.Common
{
    /// <summary>
    /// Constraint interface for configuration section. Each class that defines configuration properties must implement this interface in order to be 
    /// consumed using GetConfigurationSection method that is part of the IAppSettingsConfiguration interface.
    /// </summary>
    public interface IAppSettingsConfigurationSection
    {
    }
}
