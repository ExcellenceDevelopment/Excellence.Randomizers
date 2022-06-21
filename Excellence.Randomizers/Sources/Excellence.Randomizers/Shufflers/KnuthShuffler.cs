using System;
using System.Collections.Generic;
using System.Linq;

using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.Core.Shufflers;
using Excellence.Randomizers.Utils;

namespace Excellence.Randomizers.Shufflers
{
    /// <inheritdoc />
    public class KnuthShuffler : IShuffler
    {
        protected IRandomGenerator RandomGenerator { get; }

        public KnuthShuffler(IRandomGenerator randomGenerator)
        {
            ExceptionUtils.Process(randomGenerator, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(randomGenerator)));

            this.RandomGenerator = randomGenerator;
        }

        /// <inheritdoc />
        public virtual IEnumerable<TItem> Shuffle<TItem>(IEnumerable<TItem> source)
        {
            var list = source?.ToList();

            ExceptionUtils.Process(list, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(source)));

            for (var index = 0; index < list!.Count - 1; index++)
            {
                var indexToExchange = this.RandomGenerator.GetInt32(index, list.Count - 1);

                (list[index], list[indexToExchange]) = (list[indexToExchange], list[index]);
            }

            return list;
        }
    }
}
