using Newtonsoft.Json;

namespace Excellence.Randomizers.Core
{
    /// <summary>
    /// The core configuration JSON utils.
    /// </summary>
    /// <typeparam name="TItem">The item type.</typeparam>
    /// <typeparam name="TConfiguration">The configuration type.</typeparam>
    public interface IConfigurationCoreJsonUtils<TItem, out TConfiguration> :
        IConfigurationCore<TItem, TConfiguration>
        where TConfiguration : IConfigurationCore<TItem, TConfiguration>
    {
        /// <summary>
        /// Sets configuration properties from JSON.
        /// </summary>
        /// <param name="json">The JSON.</param>
        /// <param name="jsonSerializerSettings">The serializer settings.</param>
        /// <returns></returns>
        public TConfiguration UseFromJson(string json, JsonSerializerSettings? jsonSerializerSettings = null);
    }
}
