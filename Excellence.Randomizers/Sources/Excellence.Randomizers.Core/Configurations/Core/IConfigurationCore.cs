using System.Collections.Generic;

namespace Excellence.Randomizers.Core
{
    /// <summary>
    /// The core configuration.
    /// </summary>
    /// <typeparam name="TItem">The item type.</typeparam>
    /// <typeparam name="TConfiguration">The configuration type.</typeparam>
    public interface IConfigurationCore<TItem, out TConfiguration>
        where TConfiguration : IConfigurationCore<TItem, TConfiguration>
    {
        /// <summary>
        /// The items.
        /// </summary>
        public IEnumerable<TItem> Items { get; }

        /// <summary>
        /// The minimum number of items (inclusive).
        /// </summary>
        public int MinCount { get; }

        /// <summary>
        /// The maximum number of items (inclusive).
        /// </summary>
        public int MaxCount { get; }

        /// <summary>
        /// Indicates if unique items should be used in the resulting set.
        /// </summary>
        public bool UniqueOnly { get; }

        /// <summary>
        /// Adds the items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The current instance.</returns>
        public TConfiguration UseItems(IEnumerable<TItem> items);

        /// <summary>
        /// Adds the items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The current instance.</returns>
        public TConfiguration UseItems(params TItem[] items);

        /// <summary>
        /// Sets the minimum number of items (inclusive).
        /// </summary>
        /// <param name="minCount">The minimum number of items (inclusive).</param>
        /// <returns>The current instance.</returns>
        public TConfiguration UseMinCount(int minCount);

        /// <summary>
        /// Sets the maximum number of items (inclusive).
        /// </summary>
        /// <param name="maxCount">The maximum number of items (inclusive).</param>
        /// <returns>The current instance.</returns>
        public TConfiguration UseMaxCount(int maxCount);

        /// <summary>
        /// Sets if unique items should be used in the resulting set.
        /// </summary>
        /// <param name="uniqueOnly"><see langword="true"/> when only unique (non-repeating) items should be used in the resulting set or <see langword="false"/> when repeats are allowed.</param>
        /// <returns>The current instance.</returns>
        public TConfiguration UseUnique(bool uniqueOnly);

        /// <summary>
        /// Copies the configuration.
        /// </summary>
        /// <returns>The new instance.</returns>
        public TConfiguration Copy();
    }
}
