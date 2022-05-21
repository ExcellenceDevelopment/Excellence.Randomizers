using Excellence.Randomizers.Core;

namespace Excellence.Randomizers
{
    /// <inheritdoc cref="IConfiguration{TItem}" />
    public class Configuration<TItem> : ConfigurationCore<TItem, IConfiguration<TItem>>, IConfiguration<TItem> { }
}
