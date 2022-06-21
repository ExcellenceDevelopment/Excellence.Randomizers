using System;
using System.Collections.Generic;
using System.Linq;

using Excellence.Randomizers.Configurations.Core;
using Excellence.Randomizers.Constants;
using Excellence.Randomizers.Core.Configurations.Core;

using Xunit;

namespace Excellence.Randomizers.Tests.Configurations.Core
{
    public class ConfigurationTests
    {
        #region Shared

        public interface IConfigurationCoreTestSut : IConfigurationCore<int, IConfigurationCoreTestSut> { }

        public class ConfigurationCoreTestSut : ConfigurationCore<int, IConfigurationCoreTestSut>, IConfigurationCoreTestSut { }

        protected virtual IConfigurationCoreTestSut CreateSut() => new ConfigurationCoreTestSut();

        #endregion Shared

        #region UseItems

        [Fact]
        public void UseItems_IsNull_ThrowsException()
        {
            var sut = this.CreateSut();

            Assert.Throws<ArgumentNullException>(() => sut.UseItems((IEnumerable<int>)null!));
            Assert.Throws<ArgumentNullException>(() => sut.UseItems((int[])null!));
        }

        [Fact]
        public void UseItems_AddsItems()
        {
            var items = new int[] { 1, 2, 3, 4 };
            var items2 = new int[] { 3, 4, 5, 6 };
            var items3 = new int[] { 7, 8, 9, 10 };

            var sut = this.CreateSut();

            sut.UseItems(items);

            Assert.Equal(items, sut.Items);

            sut.UseItems((IEnumerable<int>)items2);

            Assert.Equal(items.Concat(items2), sut.Items);

            sut.UseItems(items3);

            Assert.Equal(items.Concat(items2).Concat(items3), sut.Items);
        }

        #endregion UseItems

        #region UseMinCount

        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        public void UseMinCount_IsLessThanZero_ThrowsException(int minCount)
        {
            var expectedMessage = String.Format(Messages.Errors.LessThanZero, "minCount");

            var sut = this.CreateSut();

            var exception = Assert.Throws<ArgumentException>(() => sut.UseMinCount(minCount));

            Assert.Equal(expectedMessage, exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(100)]
        public void UseMinCount_SetsMinCount(int minCount)
        {
            var sut = this.CreateSut();

            sut.UseMinCount(minCount);

            Assert.Equal(minCount, sut.MinCount);
        }

        #endregion UseMinCount

        #region UseMaxCount

        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        public void UseMaxCount_IsLessThanZero_ThrowsException(int maxCount)
        {
            var expectedMessage = String.Format(Messages.Errors.LessThanZero, "maxCount");

            var sut = this.CreateSut();

            var exception = Assert.Throws<ArgumentException>(() => sut.UseMaxCount(maxCount));

            Assert.Equal(expectedMessage, exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(100)]
        public void UseMaxCount_SetsMaxCount(int maxCount)
        {
            var sut = this.CreateSut();

            sut.UseMaxCount(maxCount);

            Assert.Equal(maxCount, sut.MaxCount);
        }

        #endregion UseMaxCount

        #region UseUnique

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void UseUnique_SetsUniqueOnly(bool uniqueOnly)
        {
            var sut = this.CreateSut();

            sut.UseUnique(uniqueOnly);

            Assert.Equal(uniqueOnly, sut.UniqueOnly);
        }

        #endregion UseUnique

        #region Copy

        [Fact]
        public void Copy_CopiesConfiguration()
        {
            var sut = this.CreateSut()
                .UseItems(1, 2, 3, 4)
                .UseMinCount(2)
                .UseMaxCount(8)
                .UseUnique(true);

            var copy = sut.Copy();

            Assert.False(ReferenceEquals(sut.Items, copy.Items));
            Assert.Equal(sut.Items, copy.Items);
            Assert.Equal(sut.MinCount, copy.MinCount);
            Assert.Equal(sut.MaxCount, copy.MaxCount);
            Assert.Equal(sut.UniqueOnly, copy.UniqueOnly);
        }

        #endregion Copy
    }
}
