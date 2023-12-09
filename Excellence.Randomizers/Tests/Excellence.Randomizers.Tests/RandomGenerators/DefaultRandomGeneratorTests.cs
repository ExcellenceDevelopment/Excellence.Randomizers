using Excellence.Randomizers.Constants;
using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.RandomGenerators;

namespace Excellence.Randomizers.Tests.RandomGenerators;

public class DefaultRandomGeneratorTests
{
    #region Shared

    protected IRandomGenerator CreateSut() => new DefaultRandomGenerator();

    #endregion Shared

    #region GetInt32

    [Fact]
    public void GetInt32_Min_IsGreater_Than_Max_ThrowsException()
    {
        var expectedMessage = String.Format(Messages.Errors.GreaterThan, "min", "max");

        var exception = Assert.Throws<ArgumentException>(() => this.CreateSut().GetInt32(10, 1));

        Assert.Equal(expectedMessage, exception.Message);
    }

    [Theory]
    [InlineData(0, 10)]
    [InlineData(1, 5)]
    [InlineData(2, 4)]
    [InlineData(3, 3)]
    [InlineData(4, 15)]
    public void GetInt32_GeneratesRandomInt32(int min, int max)
    {
        var sut = this.CreateSut();

        var result = sut.GetInt32(min, max);

        Assert.True(result >= min && result <= max);
    }

    #endregion GetInt32
}
