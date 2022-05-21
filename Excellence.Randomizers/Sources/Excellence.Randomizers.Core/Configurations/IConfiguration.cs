namespace Excellence.Randomizers.Core
{
    /// <summary>
    /// The configuration.
    /// </summary>
    /// <typeparam name="TItem">The item type.</typeparam>
    public interface IConfiguration<TItem> : IConfigurationCore<TItem, IConfiguration<TItem>> { }
}
