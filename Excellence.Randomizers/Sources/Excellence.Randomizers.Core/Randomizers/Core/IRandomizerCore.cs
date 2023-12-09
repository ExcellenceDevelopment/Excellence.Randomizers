using Excellence.Randomizers.Core.Configurations.Core;

namespace Excellence.Randomizers.Core;

/// <summary>
/// The core randomizer.
/// </summary>
/// <typeparam name="TItem">The item type.</typeparam>
/// <typeparam name="TConfiguration">The configuration type.</typeparam>
/// <typeparam name="TRandomizer">The randomizer type.</typeparam>
public interface IRandomizerCore<out TItem, in TConfiguration, out TRandomizer>
    where TConfiguration : IConfigurationCore<TItem, TConfiguration>
    where TRandomizer : IRandomizerCore<TItem, TConfiguration, TRandomizer>
{
    /// <summary>
    /// The total minimum number of items (inclusive).
    /// </summary>
    public int MinCount { get; }

    /// <summary>
    /// The total maximum number of items (inclusive).
    /// </summary>
    public int MaxCount { get; }

    /// <summary>
    /// Add the configurations.
    /// </summary>
    /// <param name="configurations">The configurations.</param>
    /// <returns>The current instance.</returns>
    public TRandomizer Use(params TConfiguration[] configurations);

    /// <summary>
    /// Add the configurations.
    /// </summary>
    /// <param name="configurations">The configurations.</param>
    /// <returns>The current instance.</returns>
    public TRandomizer Use(IEnumerable<TConfiguration> configurations);

    /// <summary>
    /// Generates the random set of items.
    /// </summary>
    /// <returns>The generated set of items.</returns>
    public IEnumerable<TItem> Next();

    /// <summary>
    /// Generates multiple random sets of items.
    /// </summary>
    /// <param name="count">The count of sets to generate.</param>
    /// <returns>The generated sets of items.</returns>
    public IEnumerable<IEnumerable<TItem>> Next(int count);

    /// <summary>
    /// Copies the current instance.
    /// </summary>
    /// <returns>The new instance that has the same configuration as the current one.</returns>
    public TRandomizer Copy();
}