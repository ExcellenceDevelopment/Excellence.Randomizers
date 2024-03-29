﻿using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.Core.RandomizerFactories;
using Excellence.Randomizers.Core.Shufflers;
using Excellence.Randomizers.RandomGenerators;
using Excellence.Randomizers.RandomizerFactories;
using Excellence.Randomizers.Shufflers;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Excellence.Randomizers.Extensions;

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
        ArgumentNullException.ThrowIfNull(services);

        services.TryAddSingleton<IRandomGenerator, DefaultRandomGenerator>();
        services.TryAddSingleton<IShuffler, KnuthShuffler>();
        services.TryAddSingleton<IRandomizerFactory, RandomizerFactory>();

        return services;
    }
}
