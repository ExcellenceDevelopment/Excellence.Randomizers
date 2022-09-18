using System;

using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.Core.RandomizerFactories;
using Excellence.Randomizers.Core.Shufflers;
using Excellence.Randomizers.RandomGenerators;
using Excellence.Randomizers.RandomizerFactories;
using Excellence.Randomizers.Shufflers;
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
        /// <param name="services">The services.</param>
        /// <returns>The passed <see cref="IServiceCollection"/> instance with the added dependencies.</returns>
        /// <exception cref="ArgumentNullException">The exception when the argument is <see langword="null"/>.</exception>
        public static IServiceCollection AddRandomizers(this IServiceCollection services)
        {
            ExceptionUtils.Process(services, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(services)));

            services.AddSingleton<IRandomGenerator, DefaultRandomGenerator>();
            services.AddSingleton<IShuffler, KnuthShuffler>();
            services.AddSingleton<IRandomizerFactory, RandomizerFactory>();

            return services;
        }
    }
}
