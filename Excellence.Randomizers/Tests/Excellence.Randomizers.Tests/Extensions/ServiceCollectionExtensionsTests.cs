using System;

using Excellence.Randomizers.Core;
using Excellence.Randomizers.Extensions;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Randomizers.Tests.Extensions
{
    public class ServiceCollectionExtensionsTests
    {
        #region AddRandomizers

        [Fact]
        public void AddRandomizers_Argument_IsNull_ThrowsException()
        {
            var sut = default(IServiceCollection);

            Assert.Throws<ArgumentNullException>(() => sut!.AddRandomizers());
        }

        [Fact]
        public void AddRandomizers_AddsRandomizers()
        {
            var expectedRandomGeneratorType = typeof(DefaultRandomGenerator);
            var expectedShufflerType = typeof(KnuthShuffler);
            var expectedRandomizerFactoryType = typeof(RandomizerFactory);

            var sut = new ServiceCollection();

            var actualResult = sut.AddRandomizers();

            var serviceProvider = actualResult.BuildServiceProvider();

            var randomGenerator = serviceProvider.GetRequiredService<IRandomGenerator>();

            Assert.NotNull(randomGenerator);
            Assert.Equal(expectedRandomGeneratorType, randomGenerator.GetType());

            var shuffler = serviceProvider.GetRequiredService<IShuffler>();

            Assert.NotNull(shuffler);
            Assert.Equal(expectedShufflerType, shuffler.GetType());

            var randomizerFactory = serviceProvider.GetRequiredService<IRandomizerFactory>();

            Assert.NotNull(randomizerFactory);
            Assert.Equal(expectedRandomizerFactoryType, randomizerFactory.GetType());
        }

        #endregion AddRandomizers
    }
}
