using Excellence.Randomizers.Core;
using Excellence.Randomizers.Core.Configurations;
using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.Core.Shufflers;

namespace Excellence.Randomizers
{
    /// <inheritdoc cref="IRandomizer{TItem}" />
    public class Randomizer<TItem> : RandomizerCore<TItem, IConfiguration<TItem>, IRandomizer<TItem>>, IRandomizer<TItem>
    {
        public Randomizer(IRandomGenerator randomGenerator, IShuffler shuffler) : base(randomGenerator, shuffler) { }
    }
}
