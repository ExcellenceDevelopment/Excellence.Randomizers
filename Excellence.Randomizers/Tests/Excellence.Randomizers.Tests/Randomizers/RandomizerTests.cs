using Excellence.Randomizers.Configurations;
using Excellence.Randomizers.Core;
using Excellence.Randomizers.Core.Configurations;
using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.Core.Shufflers;
using Excellence.Randomizers.RandomGenerators;
using Excellence.Randomizers.RandomizerFactories;
using Excellence.Randomizers.Shufflers;

using Xunit;

namespace Excellence.Randomizers.Tests
{
    public class RandomizerTests
    {
        #region Shared

        protected IRandomizer<object> CreateSut(IRandomGenerator? randomGenerator = null, IShuffler? shuffler = null)
        {
            randomGenerator ??= new DefaultRandomGenerator();
            shuffler ??= new KnuthShuffler(randomGenerator);

            return new Randomizer<object>(randomGenerator, shuffler);
        }

        #endregion Shared

        #region Constructors

        [Fact]
        public void Constructor_CreatesInstance()
        {
            var randomGenerator = new DefaultRandomGenerator();
            var shuffler = new KnuthShuffler(randomGenerator);

            var sut = this.CreateSut(randomGenerator, shuffler);

            Assert.NotNull(sut);
        }

        #endregion Constructors

        #region Usage

        [Fact]
        public void Usage()
        {
            var configuration = new Configuration<int>();
            configuration.UseItems(1, 2, 3);
            configuration.UseMinCount(2);
            configuration.UseMaxCount(10);
            configuration.UseUnique(false);

            // or

            var configuration2 = new Configuration<int>()
                .UseItems(new List<int>() { 3, 4, 5, 6, 7, 8 })
                .UseMinCount(1)
                .UseMaxCount(5)
                .UseUnique(true);

            // or

            var configuration3 = new Configuration<int>()
                .UseFromJson
                (
                    "{ "
                    + "\"Items\": [1, 3, 5, 7, 9], "
                    + "\"MinCount\": 2, "
                    + "\"MaxCount\": 4, "
                    + "\"UniqueOnly\": false"
                    + " }"
                );

            var randomGenerator = new DefaultRandomGenerator();
            var shuffler = new KnuthShuffler(randomGenerator);

            var randomizerFactory = new RandomizerFactory(randomGenerator, shuffler);
            var randomizer = randomizerFactory.CreateRandomizer<int>();

            randomizer.Use(configuration);

            // or

            randomizer.Use(new List<IConfiguration<int>>() { configuration2, configuration3 });

            // one set
            var randomSet = randomizer.Next().ToList();

            // 5 sets
            var randomSets = randomizer.Next(5).Select(item => item.ToList()).ToList();

            Assert.Equal(configuration.MinCount + configuration2.MinCount + configuration3.MinCount, randomizer.MinCount);
            Assert.Equal(configuration.MaxCount + configuration2.MaxCount + configuration3.MaxCount, randomizer.MaxCount);

            foreach (var set in randomSets.Concat(new[] { randomSet }))
            {
                Assert.True(set.Count >= randomizer.MinCount && set.Count <= randomizer.MaxCount);
            }

            var randomizerCopy = randomizer.Copy()
                .Use(configuration3.Copy());

            var anotherRandomSet = randomizerCopy.Next().ToList();
            var anotherRandomSets = randomizerCopy.Next(5).Select(item => item.ToList()).ToList();

            Assert.Equal(configuration.MinCount + configuration2.MinCount + configuration3.MinCount + configuration3.MinCount, randomizerCopy.MinCount);
            Assert.Equal(configuration.MaxCount + configuration2.MaxCount + configuration3.MaxCount + configuration3.MaxCount, randomizerCopy.MaxCount);

            foreach (var set in anotherRandomSets.Concat(new[] { anotherRandomSet }))
            {
                Assert.True(set.Count >= randomizerCopy.MinCount && set.Count <= randomizerCopy.MaxCount);
            }
        }

        #endregion Usage
    }
}
