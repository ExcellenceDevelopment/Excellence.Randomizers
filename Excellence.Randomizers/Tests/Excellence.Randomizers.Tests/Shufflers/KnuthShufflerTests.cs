using System;
using System.Collections.Generic;
using System.Linq;

using Excellence.Randomizers.Core.RandomGenerators;
using Excellence.Randomizers.Core.Shufflers;
using Excellence.Randomizers.RandomGenerators;
using Excellence.Randomizers.Shufflers;

using Xunit;

namespace Excellence.Randomizers.Tests.Shufflers
{
    public class KnuthShufflerTests
    {
        #region Shared

        protected IShuffler CreateSut(IRandomGenerator? randomGenerator = null) => new KnuthShuffler(randomGenerator ?? new DefaultRandomGenerator());

        #endregion Shared

        #region Constructors

        [Fact]
        public void Constructor_Argument_IsNull_ThrowsException() =>
            Assert.Throws<ArgumentNullException>(() => new KnuthShuffler(null!));

        [Fact]
        public void Constructor_CreatesInstance()
        {
            var randomGenerator = new DefaultRandomGenerator();

            var sut = this.CreateSut(randomGenerator);

            Assert.NotNull(sut);
        }

        #endregion Constructors

        #region Shuffle

        [Fact]
        public void Shuffle_Argument_IsNull_ThrowsException()
        {
            var sut = this.CreateSut();

            Assert.Throws<ArgumentNullException>(() => sut.Shuffle((IEnumerable<object>)null!));
        }

        [Fact]
        public void Shuffle_ShufflesCollection()
        {
            var sut = this.CreateSut();

            var collection = new List<int>() { 1, 2, 3, 4, 5 };

            var result = sut.Shuffle(collection).ToList();

            Assert.Equal(result.Count, collection.Count);
        }

        #endregion
    }
}
