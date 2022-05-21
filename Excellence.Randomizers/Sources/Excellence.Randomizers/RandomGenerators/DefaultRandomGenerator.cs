using System;

using Excellence.Randomizers.Constants;
using Excellence.Randomizers.Core;
using Excellence.Randomizers.Providers;
using Excellence.Randomizers.Utils;

namespace Excellence.Randomizers
{
    /// <inheritdoc />
    public class DefaultRandomGenerator : IRandomGenerator
    {
        /// <inheritdoc />
        public virtual int GetInt32(int min, int max)
        {
            ExceptionUtils.Process(() => min > max, () => new ArgumentException(String.Format(Messages.Errors.GreaterThan, nameof(min), nameof(max))));

            return RandomProvider.Random.Value!.Next(min, max + 1);
        }
    }
}
