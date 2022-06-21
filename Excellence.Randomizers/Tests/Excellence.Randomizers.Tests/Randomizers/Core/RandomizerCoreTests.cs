using System;
using System.Collections.Generic;
using System.Linq;

using Excellence.Randomizers.Constants;
using Excellence.Randomizers.Core;
using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.Core.Shufflers;
using Excellence.Randomizers.RandomGenerators;
using Excellence.Randomizers.Shufflers;
using Excellence.Randomizers.Tests.Configurations.Core;

using Newtonsoft.Json;

using Xunit;

namespace Excellence.Randomizers.Tests
{
    public class RandomizerCoreTests
    {
        #region Shared

        protected static Func<object, string, object, object> SetProperty => (target, propertyName, propertyValue) =>
        {
            target
                .GetType()
                .GetProperty(propertyName)
                !.SetValue(target, propertyValue);

            return target;
        };

        public interface IRandomizerCoreTestSut : IRandomizerCore<int, ConfigurationTests.IConfigurationCoreTestSut, IRandomizerCoreTestSut>
        {
            public IList<ConfigurationTests.IConfigurationCoreTestSut> ConfigurationsPublic { get; }
        }

        public class RandomizerCoreTestSut : RandomizerCore<int, ConfigurationTests.IConfigurationCoreTestSut, IRandomizerCoreTestSut>, IRandomizerCoreTestSut
        {
            public IList<ConfigurationTests.IConfigurationCoreTestSut> ConfigurationsPublic => this.Configurations;

            public RandomizerCoreTestSut(IRandomGenerator randomGenerator, IShuffler shuffler) : base(randomGenerator, shuffler) { }
        }

        protected IRandomizerCoreTestSut CreateSut(IRandomGenerator? randomGenerator = null, IShuffler? shuffler = null)
        {
            randomGenerator ??= new DefaultRandomGenerator();
            shuffler ??= new KnuthShuffler(randomGenerator);

            return new RandomizerCoreTestSut(randomGenerator, shuffler);
        }

        public static ConfigurationTests.IConfigurationCoreTestSut DefaultConfiguration => new ConfigurationTests.ConfigurationCoreTestSut()
            .UseItems(1, 2, 3, 4)
            .UseMinCount(1)
            .UseMaxCount(3)
            .UseUnique(true);

        #endregion Shared

        #region Constructors

        public static TheoryData<IRandomGenerator, IShuffler> ConstructorArgumentIsNullTestData => new TheoryData<IRandomGenerator, IShuffler>()
        {
            { null!, null! },
            { new DefaultRandomGenerator(), null! }
        };

        [Theory]
        [MemberData(nameof(ConstructorArgumentIsNullTestData))]
        public void Constructor_Argument_IsNull(IRandomGenerator randomGenerator, IShuffler shuffler) =>
            Assert.Throws<ArgumentNullException>(() => new RandomizerCoreTestSut(randomGenerator, shuffler));

        [Fact]
        public void Constructor_CreatesInstance()
        {
            var randomGenerator = new DefaultRandomGenerator();
            var shuffler = new KnuthShuffler(randomGenerator);

            var sut = this.CreateSut(randomGenerator, shuffler);

            Assert.NotNull(sut);
        }

        #endregion Constructors

        #region Use

        public static TheoryData<Func<IRandomizerCoreTestSut, IRandomizerCoreTestSut>, Type, string?> UseValidationErrorTestData =>
            new TheoryData<Func<IRandomizerCoreTestSut, IRandomizerCoreTestSut>, Type, string?>()
            {
                // collection == null
                {
                    randomizer => randomizer.Use((IEnumerable<ConfigurationTests.IConfigurationCoreTestSut>)null!),
                    typeof(ArgumentNullException),
                    null
                },
                {
                    randomizer => randomizer.Use((ConfigurationTests.IConfigurationCoreTestSut[])null!),
                    typeof(ArgumentNullException),
                    null
                },

                // entry == null
                {
                    randomizer => randomizer.Use(new List<ConfigurationTests.IConfigurationCoreTestSut>() { null! }),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + $"{Environment.NewLine}"
                    + $"    {String.Format(Messages.Errors.Null, String.Format(Messages.ConfigurationWithIndex, 0))}"
                },
                {
                    randomizer => randomizer.Use(new ConfigurationTests.IConfigurationCoreTestSut[] { null! }),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + $"{Environment.NewLine}"
                    + $"    {String.Format(Messages.Errors.Null, String.Format(Messages.ConfigurationWithIndex, 0))}"
                },

                // empty Items when MinCount > 0
                {
                    randomizer => randomizer.Use
                    (
                        new List<ConfigurationTests.IConfigurationCoreTestSut>()
                        {
                            new ConfigurationTests.ConfigurationCoreTestSut().UseMinCount(1).UseMaxCount(2)
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.NoEnoughItems, nameof(ConfigurationTests.IConfigurationCoreTestSut.Items), nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount))}"
                },
                {
                    randomizer => randomizer.Use
                    (
                        new List<ConfigurationTests.IConfigurationCoreTestSut>()
                        {
                            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(new List<int>()).UseMinCount(1).UseMaxCount(2)
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.NoEnoughItems, nameof(ConfigurationTests.IConfigurationCoreTestSut.Items), nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount))}"
                },
                {
                    randomizer => randomizer.Use
                    (
                        new ConfigurationTests.IConfigurationCoreTestSut[]
                        {
                            new ConfigurationTests.ConfigurationCoreTestSut().UseMinCount(1).UseMaxCount(2)
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.NoEnoughItems, nameof(ConfigurationTests.IConfigurationCoreTestSut.Items), nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount))}"
                },
                {
                    randomizer => randomizer.Use
                    (
                        new ConfigurationTests.IConfigurationCoreTestSut[]
                        {
                            new ConfigurationTests.ConfigurationCoreTestSut().UseItems().UseMinCount(1).UseMaxCount(2)
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.NoEnoughItems, nameof(ConfigurationTests.IConfigurationCoreTestSut.Items), nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount))}"
                },

                // MinCount < 0
                {
                    randomizer => randomizer.Use
                    (
                        new List<ConfigurationTests.IConfigurationCoreTestSut>()
                        {
                            (ConfigurationTests.IConfigurationCoreTestSut)SetProperty
                            (
                                new ConfigurationTests.ConfigurationCoreTestSut(),
                                nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount),
                                -10
                            )
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.LessThanZero, nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount))}"
                },
                {
                    randomizer => randomizer.Use
                    (
                        new ConfigurationTests.IConfigurationCoreTestSut[]
                        {
                            (ConfigurationTests.IConfigurationCoreTestSut)SetProperty
                            (
                                new ConfigurationTests.ConfigurationCoreTestSut(),
                                nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount),
                                -10
                            )
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.LessThanZero, nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount))}"
                },

                // MaxCount < 0
                {
                    randomizer => randomizer.Use
                    (
                        new List<ConfigurationTests.IConfigurationCoreTestSut>()
                        {
                            (ConfigurationTests.IConfigurationCoreTestSut)SetProperty
                            (
                                new ConfigurationTests.ConfigurationCoreTestSut(),
                                nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount),
                                -10
                            )
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.LessThanZero, nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount))}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.GreaterThan, nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount), nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount))}"
                },
                {
                    randomizer => randomizer.Use
                    (
                        new ConfigurationTests.IConfigurationCoreTestSut[]
                        {
                            (ConfigurationTests.IConfigurationCoreTestSut)SetProperty
                            (
                                new ConfigurationTests.ConfigurationCoreTestSut(),
                                nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount),
                                -10
                            )
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.LessThanZero, nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount))}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.GreaterThan, nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount), nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount))}"
                },

                // MinCount > MaxCount
                {
                    randomizer => randomizer.Use
                    (
                        new List<ConfigurationTests.IConfigurationCoreTestSut>()
                        {
                            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(1).UseMinCount(10).UseMaxCount(5)
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.GreaterThan, nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount), nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount))}"
                },
                {
                    randomizer => randomizer.Use
                    (
                        new ConfigurationTests.IConfigurationCoreTestSut[]
                        {
                            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(1).UseMinCount(10).UseMaxCount(5)
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.GreaterThan, nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount), nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount))}"
                },

                // Unique
                {
                    randomizer => randomizer.Use
                    (
                        new List<ConfigurationTests.IConfigurationCoreTestSut>()
                        {
                            new ConfigurationTests.ConfigurationCoreTestSut().UseItems
                            (
                                1,
                                2,
                                3,
                                3,
                                3,
                                2
                            ).UseMaxCount(5).UseUnique(true)
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.NoEnoughUniqueItems, nameof(ConfigurationTests.IConfigurationCoreTestSut.Items), 5)}"
                },
                {
                    randomizer => randomizer.Use
                    (
                        new ConfigurationTests.IConfigurationCoreTestSut[]
                        {
                            new ConfigurationTests.ConfigurationCoreTestSut().UseItems
                            (
                                1,
                                2,
                                3,
                                3,
                                3,
                                2
                            ).UseMaxCount(5).UseUnique(true)
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.NoEnoughUniqueItems, nameof(ConfigurationTests.IConfigurationCoreTestSut.Items), 5)}"
                },

                // Multiple errors
                {
                    randomizer => randomizer.Use
                    (
                        new List<ConfigurationTests.IConfigurationCoreTestSut>()
                        {
                            new ConfigurationTests.ConfigurationCoreTestSut().UseMinCount(3).UseMaxCount(2)
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.NoEnoughItems, nameof(ConfigurationTests.IConfigurationCoreTestSut.Items), nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount))}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.GreaterThan, nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount), nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount))}"
                },
                {
                    randomizer => randomizer.Use
                    (
                        new ConfigurationTests.IConfigurationCoreTestSut[]
                        {
                            new ConfigurationTests.ConfigurationCoreTestSut().UseMinCount(3).UseMaxCount(2)
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.NoEnoughItems, nameof(ConfigurationTests.IConfigurationCoreTestSut.Items), nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount))}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.GreaterThan, nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount), nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount))}"
                },

                // Multiple configurations
                {
                    randomizer => randomizer.Use
                    (
                        new List<ConfigurationTests.IConfigurationCoreTestSut>()
                        {
                            new ConfigurationTests.ConfigurationCoreTestSut().UseMinCount(3).UseMaxCount(2),
                            new ConfigurationTests.ConfigurationCoreTestSut().UseMinCount(3).UseMaxCount(2)
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.NoEnoughItems, nameof(ConfigurationTests.IConfigurationCoreTestSut.Items), nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount))}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.GreaterThan, nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount), nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount))}"
                    + Environment.NewLine
                    + Environment.NewLine
                    + $"{String.Format(Messages.ConfigurationWithIndex, 1)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.NoEnoughItems, nameof(ConfigurationTests.IConfigurationCoreTestSut.Items), nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount))}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.GreaterThan, nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount), nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount))}"
                },
                {
                    randomizer => randomizer.Use
                    (
                        new ConfigurationTests.IConfigurationCoreTestSut[]
                        {
                            new ConfigurationTests.ConfigurationCoreTestSut().UseMinCount(3).UseMaxCount(2),
                            new ConfigurationTests.ConfigurationCoreTestSut().UseMinCount(3).UseMaxCount(2)
                        }
                    ),
                    typeof(ArgumentException),
                    $"{String.Format(Messages.ConfigurationWithIndex, 0)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.NoEnoughItems, nameof(ConfigurationTests.IConfigurationCoreTestSut.Items), nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount))}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.GreaterThan, nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount), nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount))}"
                    + Environment.NewLine
                    + Environment.NewLine
                    + $"{String.Format(Messages.ConfigurationWithIndex, 1)}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.NoEnoughItems, nameof(ConfigurationTests.IConfigurationCoreTestSut.Items), nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount))}"
                    + Environment.NewLine
                    + $"    {String.Format(Messages.Errors.GreaterThan, nameof(ConfigurationTests.IConfigurationCoreTestSut.MinCount), nameof(ConfigurationTests.IConfigurationCoreTestSut.MaxCount))}"
                }
            };

        [Theory]
        [MemberData(nameof(UseValidationErrorTestData))]
        public void Use_ValidationError_ThrowsException
        (
            Func<IRandomizerCoreTestSut, IRandomizerCoreTestSut> configurationDelegate,
            Type exceptionType,
            string? expectedMessage
        )
        {
            var sut = this.CreateSut();

            var exception = Assert.Throws(exceptionType, () => configurationDelegate.Invoke(sut));

            if (expectedMessage != null)
            {
                Assert.Equal(expectedMessage, exception.Message);
            }
        }

        public static TheoryData<Func<IRandomizerCoreTestSut, IRandomizerCoreTestSut>> UseTestData => new TheoryData<Func<IRandomizerCoreTestSut, IRandomizerCoreTestSut>>()
        {
            randomizer => randomizer.Use(new List<ConfigurationTests.IConfigurationCoreTestSut>() { DefaultConfiguration }),
            randomizer => randomizer.Use(new ConfigurationTests.IConfigurationCoreTestSut[] { DefaultConfiguration })
        };

        [Theory]
        [MemberData(nameof(UseTestData))]
        public void Use_AddsConfiguration(Func<IRandomizerCoreTestSut, IRandomizerCoreTestSut> configurationDelegate)
        {
            var expectedConfiguration = DefaultConfiguration;

            var sut = this.CreateSut();

            configurationDelegate.Invoke(sut);

            Assert.True(sut.ConfigurationsPublic.Count == 1);

            var sutConfiguration = sut.ConfigurationsPublic.Single();

            Assert.Equal(expectedConfiguration.Items, sutConfiguration.Items);
            Assert.Equal(expectedConfiguration.MinCount, sutConfiguration.MinCount);
            Assert.Equal(expectedConfiguration.MaxCount, sutConfiguration.MaxCount);
            Assert.Equal(expectedConfiguration.UniqueOnly, sutConfiguration.UniqueOnly);
        }

        public static TheoryData<Func<IRandomizerCoreTestSut, IRandomizerCoreTestSut>> UseMultipleTestData =>
            new TheoryData<Func<IRandomizerCoreTestSut, IRandomizerCoreTestSut>>()
            {
                randomizer => randomizer.Use
                (
                    new List<ConfigurationTests.IConfigurationCoreTestSut>() { DefaultConfiguration, DefaultConfiguration, new ConfigurationTests.ConfigurationCoreTestSut() }
                ),
                randomizer => randomizer.Use
                    (new ConfigurationTests.IConfigurationCoreTestSut[] { DefaultConfiguration, DefaultConfiguration, new ConfigurationTests.ConfigurationCoreTestSut() })
            };

        [Theory]
        [MemberData(nameof(UseMultipleTestData))]
        public void Use_Multiple_AddsConfigurations(Func<IRandomizerCoreTestSut, IRandomizerCoreTestSut> configurationDelegate)
        {
            var sut = this.CreateSut();

            configurationDelegate.Invoke(sut);

            Assert.True(sut.ConfigurationsPublic.Count == 3);
            Assert.Equal(sut.MinCount, sut.ConfigurationsPublic.Sum(item => item.MinCount));
            Assert.Equal(sut.MaxCount, sut.ConfigurationsPublic.Sum(item => item.MaxCount));
        }

        #endregion Use

        #region Next

        protected static readonly string ResultCheckMessage = $"{Environment.NewLine}"
                                                              + $"    Result[{{0}}]: {{1}}{Environment.NewLine}"
                                                              + $"{Environment.NewLine}"
                                                              + $"    Configuration[{{2}}]: {{3}}"
                                                              + $"{Environment.NewLine}";

        protected static readonly string ResultCheckUniquenessMessage = $"{Environment.NewLine}"
                                                                        + $"Uniqueness"
                                                                        + $"{ResultCheckMessage}";

        protected IList<ConfigurationTests.IConfigurationCoreTestSut> NextConfigurations => new List<ConfigurationTests.IConfigurationCoreTestSut>()
        {
            // no items
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems().UseMinCount(0).UseMaxCount(0).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems().UseMinCount(0).UseMaxCount(10).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems().UseMinCount(0).UseMaxCount(0).UseUnique(true),


            // one item and MinCount == 0
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(1, 1)).UseMinCount(0).UseMaxCount(1).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(10, 1)).UseMinCount(0).UseMaxCount(10).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(-1, 1)).UseMinCount(0).UseMaxCount(1).UseUnique(true),

            // one item and MinCount > 0
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(20, 1)).UseMinCount(1).UseMaxCount(5).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(30, 1)).UseMinCount(1).UseMaxCount(5).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(-20, 1)).UseMinCount(1).UseMaxCount(1).UseUnique(true),

            // one item and MinCount == MaxCount
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(40, 1)).UseMinCount(0).UseMaxCount(0).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(50, 1)).UseMinCount(5).UseMaxCount(5).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(-40, 1)).UseMinCount(0).UseMaxCount(0).UseUnique(true),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(-50, 1)).UseMinCount(1).UseMaxCount(1).UseUnique(true),


            // multiple items and MinCount == 0
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(100, 8)).UseMinCount(0).UseMaxCount(8).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(-100, 8)).UseMinCount(0).UseMaxCount(8).UseUnique(true),

            // multiple items and MinCount > 0
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(200, 17)).UseMinCount(3).UseMaxCount(10).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(-200, 17)).UseMinCount(3).UseMaxCount(10).UseUnique(true),

            // multiple items and MinCount == MaxCount
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(300, 12)).UseMinCount(10).UseMaxCount(10).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(-300, 12)).UseMinCount(10).UseMaxCount(10).UseUnique(true),


            // others
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(400, 15).Concat(this.GetRange(410, 10))).UseMinCount(5).UseMaxCount(15).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(-400, 15).Concat(this.GetRange(-410, 10))).UseMinCount(5).UseMaxCount(15).UseUnique
                (false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(1000, 500)).UseMinCount(250).UseMaxCount(400).UseUnique(false),
            new ConfigurationTests.ConfigurationCoreTestSut().UseItems(this.GetRange(-1000, 500)).UseMinCount(250).UseMaxCount(400).UseUnique(false)
        };

        private IEnumerable<int> GetRange(int start, int count)
        {
            var result = Enumerable.Range(Math.Abs(start), count).ToList();

            if (start < 0)
            {
                result = result.Select(item => item * -1).ToList();
            }

            return result;
        }

        [Fact]
        public void Next_ReturnsCorrectResult()
        {
            var sut = this.CreateSut();

            foreach (var configuration in this.NextConfigurations)
            {
                sut.Use(configuration);
            }

            var result = sut.Next();

            this.CheckResult(new List<IList<int>>() { result.ToList() }, sut);
        }

        [Fact]
        public void Next_Multiple_ReturnsCorrectResults()
        {
            var itemsCount = 1000;

            var sut = this.CreateSut();

            foreach (var configuration in this.NextConfigurations)
            {
                sut.Use(configuration);
            }

            var results = sut.Next(itemsCount);

            this.CheckResult(results.Select(item => (IList<int>)item.ToList()).ToList(), sut);
        }

        protected void CheckResult(IList<IList<int>> results, IRandomizerCoreTestSut sut)
        {
            for (var resultIndex = 0; resultIndex < results.Count; resultIndex++)
            {
                var result = results[resultIndex];

                Assert.True(result.Count >= sut.MinCount && result.Count <= sut.MaxCount);

                for (var configurationIndex = 0; configurationIndex < sut.ConfigurationsPublic.Count; configurationIndex++)
                {
                    var configuration = sut.ConfigurationsPublic[configurationIndex];

                    var resultItems = result.Where(item => configuration.Items.Contains(item)).ToList();

                    Assert.True
                    (
                        resultItems.Count >= configuration.MinCount && resultItems.Count <= configuration.MaxCount,
                        String.Format
                        (
                            ResultCheckMessage,
                            resultIndex,
                            JsonConvert.SerializeObject(result),
                            configurationIndex,
                            JsonConvert.SerializeObject(configuration)
                        )
                    );

                    if (configuration.UniqueOnly)
                    {
                        var resultUniqueItems = resultItems.Distinct().ToList();

                        Assert.True
                        (
                            resultItems.Count == resultUniqueItems.Count,
                            String.Format
                            (
                                ResultCheckUniquenessMessage,
                                resultIndex,
                                JsonConvert.SerializeObject(result),
                                configurationIndex,
                                JsonConvert.SerializeObject(configuration)
                            )
                        );
                    }
                }
            }
        }

        #endregion Next

        #region Copy

        public static TheoryData<Func<IRandomizerCoreTestSut, IRandomizerCoreTestSut>> CopyTestData => new TheoryData<Func<IRandomizerCoreTestSut, IRandomizerCoreTestSut>>()
        {
            randomizer => randomizer.Use(new List<ConfigurationTests.IConfigurationCoreTestSut>() { DefaultConfiguration }).Use
                (new List<ConfigurationTests.IConfigurationCoreTestSut>() { DefaultConfiguration }),
            randomizer => randomizer.Use(new List<ConfigurationTests.IConfigurationCoreTestSut>() { DefaultConfiguration, DefaultConfiguration }),
            randomizer => randomizer.Use(DefaultConfiguration).Use(DefaultConfiguration),
            randomizer => randomizer.Use(DefaultConfiguration, DefaultConfiguration, DefaultConfiguration)
        };

        [Theory]
        [MemberData(nameof(CopyTestData))]
        public void Copy_CopiesTheInstance(Func<IRandomizerCoreTestSut, IRandomizerCoreTestSut> configurationDelegate)
        {
            var sut = this.CreateSut();

            configurationDelegate.Invoke(sut);

            var copy = sut.Copy();

            Assert.Equal(sut.ConfigurationsPublic.Count, copy.ConfigurationsPublic.Count);

            for (var index = 0; index < sut.ConfigurationsPublic.Count; index++)
            {
                var expectedConfiguration = sut.ConfigurationsPublic[index];
                var actualConfiguration = copy.ConfigurationsPublic[index];

                Assert.Equal(expectedConfiguration.Items, actualConfiguration.Items);
                Assert.Equal(expectedConfiguration.MinCount, actualConfiguration.MinCount);
                Assert.Equal(expectedConfiguration.MaxCount, actualConfiguration.MaxCount);
                Assert.Equal(expectedConfiguration.UniqueOnly, actualConfiguration.UniqueOnly);
            }
        }

        #endregion Copy
    }
}
