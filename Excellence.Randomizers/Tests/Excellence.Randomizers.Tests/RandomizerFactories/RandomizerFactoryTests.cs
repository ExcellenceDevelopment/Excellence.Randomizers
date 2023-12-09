using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.Core.RandomizerFactories;
using Excellence.Randomizers.Core.Shufflers;
using Excellence.Randomizers.RandomGenerators;
using Excellence.Randomizers.RandomizerFactories;
using Excellence.Randomizers.Shufflers;

namespace Excellence.Randomizers.Tests.RandomizerFactories;

public class RandomizerFactoryTests
{
    #region Shared

    protected IRandomizerFactory CreateSut(IRandomGenerator? randomGenerator = null, IShuffler? shuffler = null)
    {
        randomGenerator ??= new DefaultRandomGenerator();
        shuffler ??= new KnuthShuffler(randomGenerator);

        return new RandomizerFactory(randomGenerator, shuffler);
    }

    #endregion Shared

    #region Constructors

    public static TheoryData<IRandomGenerator, IShuffler> ConstructorArgumentIsNullTestData => new TheoryData<IRandomGenerator, IShuffler>()
    {
        { null!, null! },
        { new DefaultRandomGenerator(), null! }
    };

    [Theory]
    [MemberData(nameof(ConstructorArgumentIsNullTestData))]
    public void Constructor_Argument_IsNull_ThrowsException(IRandomGenerator randomGenerator, IShuffler shuffler) =>
        Assert.Throws<ArgumentNullException>(() => new RandomizerFactory(randomGenerator, shuffler));

    [Fact]
    public void Constructor_CreatesInstance()
    {
        var randomGenerator = new DefaultRandomGenerator();
        var shuffler = new KnuthShuffler(randomGenerator);

        var actualResult = this.CreateSut(randomGenerator, shuffler);

        Assert.NotNull(actualResult);
    }

    #endregion Constructors

    #region CreateRandomizer

    [Fact]
    public void CreateRandomizer_CreatesRandomizer()
    {
        var sut = this.CreateSut();

        var randomizer = sut.CreateRandomizer<object>();

        Assert.NotNull(randomizer);
    }

    #endregion CreateRandomizer
}
