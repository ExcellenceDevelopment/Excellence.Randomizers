using System;
using System.Collections.Generic;
using System.Linq;

using Excellence.Randomizers.Constants;
using Excellence.Randomizers.Core;
using Excellence.Randomizers.Utils;

namespace Excellence.Randomizers
{
    /// <inheritdoc />
    public class ConfigurationCore<TItem, TConfiguration> : IConfigurationCore<TItem, TConfiguration>
        where TConfiguration : IConfigurationCore<TItem, TConfiguration>
    {
        /// <inheritdoc />
        public IEnumerable<TItem> Items { get; protected set; } = Enumerable.Empty<TItem>();

        /// <inheritdoc />
        public int MinCount { get; protected set; }

        /// <inheritdoc />
        public int MaxCount { get; protected set; }

        /// <inheritdoc />
        public bool UniqueOnly { get; protected set; }

        /// <inheritdoc />
        public virtual TConfiguration Use(IEnumerable<TItem> items, int minCount, int maxCount, bool uniqueOnly = false)
        {
            var itemsCollection = items?.ToList();

            ExceptionUtils.Process(itemsCollection, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(items)));
            ExceptionUtils.Process(minCount, (param) => param < 0, () => new ArgumentException(String.Format(Messages.Errors.LessThanZero, nameof(minCount))));
            ExceptionUtils.Process(maxCount, (param) => param < 0, () => new ArgumentException(String.Format(Messages.Errors.LessThanZero, nameof(maxCount))));
            ExceptionUtils.Process(() => minCount > maxCount, () => new ArgumentException(String.Format(Messages.Errors.GreaterThan, nameof(minCount), nameof(maxCount))));

            ExceptionUtils.Process
            (
                () => uniqueOnly && itemsCollection!.Distinct().ToList().Count < maxCount,
                () => new ArgumentException(String.Format(Messages.Errors.NoEnoughUniqueItems, nameof(items), maxCount))
            );

            return this.UseItems(itemsCollection!)
                .UseMinCount(minCount)
                .UseMaxCount(maxCount)
                .UseUnique(uniqueOnly);
        }

        /// <inheritdoc />
        public virtual TConfiguration UseItems(IEnumerable<TItem> items)
        {
            var itemsCollection = items?.ToList();

            ExceptionUtils.Process(itemsCollection, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(items)));

            this.Items = this.Items.Concat(itemsCollection!);

            return (TConfiguration)(object)this;
        }

        /// <inheritdoc />
        public virtual TConfiguration UseItems(params TItem[] items) =>
            this.UseItems(items?.ToList()!);

        /// <inheritdoc />
        public virtual TConfiguration UseMinCount(int minCount)
        {
            ExceptionUtils.Process(minCount, (param) => param < 0, () => new ArgumentException(String.Format(Messages.Errors.LessThanZero, nameof(minCount))));

            this.MinCount = minCount;

            return (TConfiguration)(object)this;
        }

        /// <inheritdoc />
        public virtual TConfiguration UseMaxCount(int maxCount)
        {
            ExceptionUtils.Process(maxCount, (param) => param < 0, () => new ArgumentException(String.Format(Messages.Errors.LessThanZero, nameof(maxCount))));

            this.MaxCount = maxCount;

            return (TConfiguration)(object)this;
        }

        /// <inheritdoc />
        public virtual TConfiguration UseUnique(bool uniqueOnly)
        {
            this.UniqueOnly = uniqueOnly;

            return (TConfiguration)(object)this;
        }

        /// <inheritdoc />
        public virtual TConfiguration Copy()
        {
            var copy = (ConfigurationCore<TItem, TConfiguration>)this.MemberwiseClone();
            copy.Items = this.Items.ToList();

            return (TConfiguration)(object)copy;
        }
    }
}
