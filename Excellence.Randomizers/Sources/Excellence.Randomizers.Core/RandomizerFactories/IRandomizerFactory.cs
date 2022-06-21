namespace Excellence.Randomizers.Core.RandomizerFactories
{
    /// <summary>
    /// The randomizer factory.
    /// </summary>
    public interface IRandomizerFactory
    {
        /// <summary>
        /// Creates the randomizer.
        /// </summary>
        /// <typeparam name="TItem">The item type.</typeparam>
        /// <returns>The randomizer.</returns>
        public IRandomizer<TItem> CreateRandomizer<TItem>();
    }
}
