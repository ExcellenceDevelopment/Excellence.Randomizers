using System;

using Excellence.Randomizers.Core;
using Excellence.Randomizers.Utils;

namespace Excellence.Randomizers
{
    /// <inheritdoc />
    public class RandomizerFactory : IRandomizerFactory
    {
        protected IRandomGenerator RandomGenerator { get; }
        protected IShuffler Shuffler { get; }

        public RandomizerFactory(IRandomGenerator randomGenerator, IShuffler shuffler)
        {
            ExceptionUtils.Process(randomGenerator, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(randomGenerator)));
            ExceptionUtils.Process(shuffler, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(shuffler)));

            this.RandomGenerator = randomGenerator;
            this.Shuffler = shuffler;
        }

        /// <inheritdoc />
        public virtual IRandomizer<TItem> CreateRandomizer<TItem>() => new Randomizer<TItem>(this.RandomGenerator, this.Shuffler);
    }
}
