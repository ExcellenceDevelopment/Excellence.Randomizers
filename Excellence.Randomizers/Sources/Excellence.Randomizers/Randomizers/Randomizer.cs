using Excellence.Randomizers.Core;

namespace Excellence.Randomizers
{
    /// <inheritdoc cref="IRandomizer{TItem}" />
    public class Randomizer<TItem> : RandomizerCore<TItem, IConfiguration<TItem>, IRandomizer<TItem>>, IRandomizer<TItem>
    {
        public Randomizer(IRandomGenerator randomGenerator, IShuffler shuffler) : base(randomGenerator, shuffler) { }
    }
}
