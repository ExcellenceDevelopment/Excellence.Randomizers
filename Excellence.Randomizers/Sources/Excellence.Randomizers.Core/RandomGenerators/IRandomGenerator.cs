namespace Excellence.Randomizers.Core.RandomGenerators
{
    /// <summary>
    /// The random generator.
    /// </summary>
    public interface IRandomGenerator
    {
        /// <summary>
        /// Generates random Int32 number.
        /// </summary>
        /// <param name="min">The min value (inclusive).</param>
        /// <param name="max">The max value (inclusive).</param>
        /// <returns>The random Int32 value.</returns>
        public int GetInt32(int min, int max);
    }
}
