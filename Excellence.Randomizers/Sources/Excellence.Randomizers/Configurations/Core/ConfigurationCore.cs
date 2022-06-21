using System;
using System.Collections.Generic;
using System.Linq;

using Excellence.Randomizers.Constants;
using Excellence.Randomizers.Core.Configurations.Core;
using Excellence.Randomizers.Utils;

using Newtonsoft.Json;

namespace Excellence.Randomizers.Configurations.Core
{
    /// <inheritdoc />
    public class ConfigurationCore<TItem, TConfiguration> : IConfigurationCore<TItem, TConfiguration>
        where TConfiguration : IConfigurationCore<TItem, TConfiguration>
    {
        /// <inheritdoc />
        [JsonProperty]
        public IEnumerable<TItem> Items { get; protected set; } = Enumerable.Empty<TItem>();

        /// <inheritdoc />
        [JsonProperty]
        public int MinCount { get; protected set; }

        /// <inheritdoc />
        [JsonProperty]
        public int MaxCount { get; protected set; }

        /// <inheritdoc />
        [JsonProperty]
        public bool UniqueOnly { get; protected set; }

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
            this.UseItems((IEnumerable<TItem>)items);

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
