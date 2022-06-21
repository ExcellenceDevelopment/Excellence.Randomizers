using Excellence.Randomizers.Core.Configurations;

namespace Excellence.Randomizers.Core
{
    /// <summary>
    /// The randomizer.
    /// </summary>
    /// <typeparam name="TItem">The item type.</typeparam>
    public interface IRandomizer<TItem> : IRandomizerCore<TItem, IConfiguration<TItem>, IRandomizer<TItem>> { }
}
