using Excellence.Randomizers.Core;

namespace Excellence.Randomizers.Tests
{
    public abstract class ConfigurationCoreCompleteTestsBase
    {
        public interface IConfigurationCoreCompleteTestSut :
            IConfigurationCore<int, IConfigurationCoreCompleteTestSut>,
            IConfigurationCoreJsonUtils<int, IConfigurationCoreCompleteTestSut> { }

        protected class ConfigurationCoreCompleteTestSut : ConfigurationCoreComplete<int, IConfigurationCoreCompleteTestSut>, IConfigurationCoreCompleteTestSut { }

        protected virtual IConfigurationCoreCompleteTestSut CreateSut() => new ConfigurationCoreCompleteTestSut();
    }
}
