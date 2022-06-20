using System;
using System.Collections.Generic;

using Xunit;

namespace Excellence.Randomizers.Tests
{
    public class ConfigurationCoreJsonUtilsTests : ConfigurationCoreCompleteTestsBase
    {
        #region UseFromJson

        [Fact]
        public void UseFromJson_Json_IsNull_ThrowsException() => Assert.Throws<ArgumentNullException>(() => this.CreateSut().UseFromJson(null!));

        public static TheoryData<string, ICollection<int>, int, int, bool> UseFromJsonTestData =>
            new TheoryData<string, ICollection<int>, int, int, bool>()
            {
                { "{}", Array.Empty<int>(), 0, 0, false },
                { "{ \"Items\": [1, 2, 3, 4, 5, 6, 7, 8] }", new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0, 0, false },
                { "{ \"MinCount\": 2 }", Array.Empty<int>(), 2, 0, false },
                { "{ \"MaxCount\": 5 }", Array.Empty<int>(), 0, 5, false },
                { "{ \"UniqueOnly\": true }", Array.Empty<int>(), 0, 0, true },
                {
                    "{ "
                    + "\"Items\": [1, 2, 3, 4, 5, 6, 7, 8], "
                    + "\"MinCount\": 2, "
                    + "\"MaxCount\": 5, "
                    + "\"UniqueOnly\": true"
                    + " }",
                    new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 2, 5, true
                }
            };

        [Theory]
        [MemberData(nameof(UseFromJsonTestData))]
        public void UseFromJson_SetsValuesFromJson
        (
            string json,
            ICollection<int> items,
            int minCount,
            int maxCount,
            bool uniqueOnly
        )
        {
            var sut = this.CreateSut();

            var actualResult = sut.UseFromJson(json);

            Assert.Equal(items, actualResult.Items);
            Assert.Equal(minCount, actualResult.MinCount);
            Assert.Equal(maxCount, actualResult.MaxCount);
            Assert.Equal(uniqueOnly, actualResult.UniqueOnly);
        }

        #endregion UseFromJson
    }
}
