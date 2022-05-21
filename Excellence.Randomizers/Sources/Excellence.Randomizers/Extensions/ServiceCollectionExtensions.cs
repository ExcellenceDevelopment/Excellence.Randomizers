using System;

using Excellence.Randomizers.Core;
using Excellence.Randomizers.Utils;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Randomizers.Extensions
{
    /// <summary>
    /// The service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the dependencies needed for the the randomizers.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns>The passed <see cref="IServiceCollection"/> instance with the added dependencies.</returns>
        /// <exception cref="ArgumentNullException">The exception when the argument is <see langword="null"/>.</exception>
        public static IServiceCollection AddRandomizers(this IServiceCollection serviceCollection)
        {
            ExceptionUtils.Process(serviceCollection, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(serviceCollection)));

            serviceCollection.AddSingleton<IRandomGenerator, DefaultRandomGenerator>();
            serviceCollection.AddSingleton<IShuffler, KnuthShuffler>();
            serviceCollection.AddSingleton<IRandomizerFactory, RandomizerFactory>();

            return serviceCollection;
        }
    }
}
