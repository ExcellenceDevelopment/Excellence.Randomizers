using System;

using Excellence.Randomizers.Core.Configurations.Core;
using Excellence.Randomizers.Utils;

using Newtonsoft.Json;

namespace Excellence.Randomizers.Configurations.Core
{
    /// <inheritdoc cref="IConfigurationCore{TItem, TConfiguration}" />
    /// <inheritdoc cref="IConfigurationCoreJsonUtils{TItem, TConfiguration}" />
    public class ConfigurationCoreComplete<TItem, TConfiguration> :
        ConfigurationCore<TItem, TConfiguration>,
        IConfigurationCoreJsonUtils<TItem, TConfiguration>
        where TConfiguration :
        IConfigurationCore<TItem, TConfiguration>,
        IConfigurationCoreJsonUtils<TItem, TConfiguration>
    {
        /// <inheritdoc />
        public virtual TConfiguration UseFromJson(string json, JsonSerializerSettings? jsonSerializerSettings = null)
        {
            ExceptionUtils.Process(json, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(json)));

            JsonConvert.PopulateObject(json, this, jsonSerializerSettings);

            return (TConfiguration)(object)this;
        }
    }
}
