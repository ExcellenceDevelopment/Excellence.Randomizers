using System.Collections.Generic;

namespace Excellence.Randomizers.Core.Shufflers
{
    /// <summary>
    /// The shuffler
    /// </summary>
    public interface IShuffler
    {
        /// <summary>
        /// Shuffles the collection.
        /// </summary>
        /// <param name="source">The source collection.</param>
        /// <typeparam name="TItem">The item type.</typeparam>
        /// <returns>The shuffled collection.</returns>
        public IEnumerable<TItem> Shuffle<TItem>(IEnumerable<TItem> source);
    }
}
