using Excellence.Randomizers.Core;
using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.Core.RandomizerFactories;
using Excellence.Randomizers.Core.Shufflers;

namespace Excellence.Randomizers.RandomizerFactories;

/// <inheritdoc />
public class RandomizerFactory : IRandomizerFactory
{
    protected IRandomGenerator RandomGenerator { get; }
    protected IShuffler Shuffler { get; }

    public RandomizerFactory(IRandomGenerator randomGenerator, IShuffler shuffler)
    {
        ArgumentNullException.ThrowIfNull(randomGenerator);
        ArgumentNullException.ThrowIfNull(shuffler);

        this.RandomGenerator = randomGenerator;
        this.Shuffler = shuffler;
    }

    /// <inheritdoc />
    public virtual IRandomizer<TItem> CreateRandomizer<TItem>() => new Randomizer<TItem>(this.RandomGenerator, this.Shuffler);
}
