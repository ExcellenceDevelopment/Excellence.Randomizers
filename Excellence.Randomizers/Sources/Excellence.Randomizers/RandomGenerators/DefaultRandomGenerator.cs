using Excellence.Randomizers.Constants;
using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.Providers;

namespace Excellence.Randomizers.RandomGenerators;

/// <inheritdoc />
public class DefaultRandomGenerator : IRandomGenerator
{
    /// <inheritdoc />
    public virtual int GetInt32(int min, int max)
    {
        if (min > max)
        {
            throw new ArgumentException(String.Format(Messages.Errors.GreaterThan, nameof(min), nameof(max)));
        }

        return RandomProvider.Random.Value!.Next(min, max + 1);
    }
}
