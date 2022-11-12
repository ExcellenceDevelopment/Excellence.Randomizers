using Excellence.Randomizers.Constants;
using Excellence.Randomizers.Core.Configurations.Core;
using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.Core.Shufflers;

namespace Excellence.Randomizers.Core
{
    /// <inheritdoc />
    public class RandomizerCore<TItem, TConfiguration, TRandomizer> : IRandomizerCore<TItem, TConfiguration, TRandomizer>
        where TConfiguration : IConfigurationCore<TItem, TConfiguration>
        where TRandomizer : IRandomizerCore<TItem, TConfiguration, TRandomizer>
    {
        protected IList<TConfiguration> Configurations { get; set; } = new List<TConfiguration>();

        protected IRandomGenerator RandomGenerator { get; }
        protected IShuffler Shuffler { get; }

        /// <inheritdoc />
        public int MinCount => this.Configurations.Sum(item => item.MinCount);

        /// <inheritdoc />
        public int MaxCount => this.Configurations.Sum(item => item.MaxCount);

        public RandomizerCore(IRandomGenerator randomGenerator, IShuffler shuffler)
        {
            ArgumentNullException.ThrowIfNull(randomGenerator);
            ArgumentNullException.ThrowIfNull(shuffler);

            this.RandomGenerator = randomGenerator;
            this.Shuffler = shuffler;
        }

        /// <inheritdoc />
        public virtual TRandomizer Use(IEnumerable<TConfiguration> configurations)
        {
            ArgumentNullException.ThrowIfNull(configurations);

            var configurationsList = configurations.ToList();

            var validationMessage = this.ValidateConfigurations(configurationsList);

            if (!String.IsNullOrEmpty(validationMessage))
            {
                throw new ArgumentException(validationMessage);
            }

            foreach (var configuration in configurationsList)
            {
                this.Configurations.Add(configuration.Copy());
            }

            return (TRandomizer)(object)this;
        }

        /// <inheritdoc />
        public virtual TRandomizer Use(params TConfiguration[] configurations) => this.Use((IEnumerable<TConfiguration>)configurations);

        /// <inheritdoc />
        public virtual IEnumerable<TItem> Next()
        {
            var randomItems = this.Configurations
                .Select(item => this.GetRandomItemsFromConfiguration(item))
                .SelectMany(item => item)
                .ToList();

            var result = this.Shuffler.Shuffle(randomItems);

            return result;
        }

        /// <inheritdoc />
        public virtual IEnumerable<IEnumerable<TItem>> Next(int count)
        {
            var result = new List<IEnumerable<TItem>>(count);

            for (var setsCount = 0; setsCount < count; setsCount++)
            {
                result.Add(this.Next());
            }

            return result;
        }

        /// <inheritdoc />
        public virtual TRandomizer Copy()
        {
            var copy = (RandomizerCore<TItem, TConfiguration, TRandomizer>)this.MemberwiseClone();
            copy.Configurations = this.Configurations.Select(item => item.Copy()).ToList();

            return (TRandomizer)(object)copy;
        }

        protected virtual string ValidateConfigurations(IList<TConfiguration> configurations)
        {
            var validationMessages = new List<string>();

            for (var index = 0; index < configurations.Count; index++)
            {
                var configuration = configurations[index];
                var configurationValidationMessages = new List<string>();

                if (configuration == null)
                {
                    configurationValidationMessages.Add(String.Format(Messages.Errors.Null, String.Format(Messages.ConfigurationWithIndex, index)));
                }
                else
                {
                    var itemsCollection = configuration.Items.ToList();

                    if (!itemsCollection.Any() && configuration.MinCount > 0)
                    {
                        configurationValidationMessages.Add(String.Format(Messages.Errors.NoEnoughItems, nameof(configuration.Items), nameof(configuration.MinCount)));
                    }

                    if (configuration.MinCount < 0)
                    {
                        configurationValidationMessages.Add(String.Format(Messages.Errors.LessThanZero, nameof(configuration.MinCount)));
                    }

                    if (configuration.MaxCount < 0)
                    {
                        configurationValidationMessages.Add(String.Format(Messages.Errors.LessThanZero, nameof(configuration.MaxCount)));
                    }

                    if (configuration.MinCount > configuration.MaxCount)
                    {
                        configurationValidationMessages.Add(String.Format(Messages.Errors.GreaterThan, nameof(configuration.MinCount), nameof(configuration.MaxCount)));
                    }

                    if (configuration.UniqueOnly)
                    {
                        var distinctItems = itemsCollection.Distinct().ToList();

                        if (distinctItems.Count < configuration.MaxCount)
                        {
                            configurationValidationMessages.Add(String.Format(Messages.Errors.NoEnoughUniqueItems, nameof(configuration.Items), configuration.MaxCount));
                        }
                    }
                }

                if (configurationValidationMessages.Any())
                {
                    var configurationValidationMessagesJoined = String.Join(Messages.NewLineWithIndent, configurationValidationMessages);

                    var configurationValidationMessage = String.Join
                    (
                        Messages.NewLineWithIndent,
                        new List<string>()
                        {
                            String.Format(Messages.ConfigurationWithIndex, index),
                            configurationValidationMessagesJoined
                        }
                    );

                    validationMessages.Add(configurationValidationMessage);
                }
            }

            return String.Join($"{Environment.NewLine}{Environment.NewLine}", validationMessages);
        }

        protected virtual IEnumerable<TItem> GetRandomItemsFromConfiguration(TConfiguration configuration)
        {
            var items = configuration.Items.ToList();

            if (!items.Any())
            {
                return Enumerable.Empty<TItem>();
            }

            var itemsCountToUse = this.RandomGenerator.GetInt32(configuration.MinCount, configuration.MaxCount);

            var configurationSet = (ICollection<TItem>)new List<TItem>(itemsCountToUse);

            if (configuration.UniqueOnly)
            {
                configurationSet = new HashSet<TItem>();

                var distinctItems = items.Distinct().ToList();

                if (distinctItems.Count == itemsCountToUse)
                {
                    return items;
                }
            }

            while (configurationSet.Count != itemsCountToUse)
            {
                configurationSet.Add(items[this.RandomGenerator.GetInt32(0, items.Count - 1)]);
            }

            return configurationSet;
        }
    }
}
