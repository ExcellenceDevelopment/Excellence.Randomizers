using Excellence.Randomizers.Configurations.Core;
using Excellence.Randomizers.Core.Configurations;

namespace Excellence.Randomizers.Configurations
{
    /// <inheritdoc cref="IConfiguration{TItem}" />
    public class Configuration<TItem> : ConfigurationCoreComplete<TItem, IConfiguration<TItem>>, IConfiguration<TItem> { }
}
