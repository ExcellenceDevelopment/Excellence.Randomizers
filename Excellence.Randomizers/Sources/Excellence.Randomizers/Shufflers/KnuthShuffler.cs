using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.Core.Shufflers;

namespace Excellence.Randomizers.Shufflers;

/// <inheritdoc />
public class KnuthShuffler : IShuffler
{
    protected IRandomGenerator RandomGenerator { get; }

    public KnuthShuffler(IRandomGenerator randomGenerator)
    {
        ArgumentNullException.ThrowIfNull(randomGenerator);

        this.RandomGenerator = randomGenerator;
    }

    /// <inheritdoc />
    public virtual IEnumerable<TItem> Shuffle<TItem>(IEnumerable<TItem> source)
    {
        ArgumentNullException.ThrowIfNull(source);

        var list = source.ToList();

        for (var index = 0; index < list.Count - 1; index++)
        {
            var indexToExchange = this.RandomGenerator.GetInt32(index, list.Count - 1);

            (list[index], list[indexToExchange]) = (list[indexToExchange], list[index]);
        }

        return list;
    }
}
