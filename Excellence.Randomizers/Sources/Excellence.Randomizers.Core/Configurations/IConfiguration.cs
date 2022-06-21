using Excellence.Randomizers.Core.Configurations.Core;

namespace Excellence.Randomizers.Core.Configurations
{
    /// <summary>
    /// The configuration.
    /// </summary>
    /// <typeparam name="TItem">The item type.</typeparam>
    public interface IConfiguration<TItem> :
        IConfigurationCore<TItem, IConfiguration<TItem>>,
        IConfigurationCoreJsonUtils<TItem, IConfiguration<TItem>> { }
}
