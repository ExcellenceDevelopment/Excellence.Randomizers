using Excellence.Randomizers.Configurations.Core;
using Excellence.Randomizers.Core.Configurations.Core;

namespace Excellence.Randomizers.Tests.Configurations.Core;

public abstract class ConfigurationCoreCompleteTestsBase
{
    public interface IConfigurationCoreCompleteTestSut :
        IConfigurationCore<int, IConfigurationCoreCompleteTestSut>,
        IConfigurationCoreJsonUtils<int, IConfigurationCoreCompleteTestSut> { }

    protected class ConfigurationCoreCompleteTestSut : ConfigurationCoreComplete<int, IConfigurationCoreCompleteTestSut>, IConfigurationCoreCompleteTestSut { }

    protected virtual IConfigurationCoreCompleteTestSut CreateSut() => new ConfigurationCoreCompleteTestSut();
}