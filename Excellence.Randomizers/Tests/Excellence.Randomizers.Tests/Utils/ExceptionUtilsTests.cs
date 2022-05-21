using System;

using Excellence.Randomizers.Utils;

using Xunit;

namespace Excellence.Randomizers.Tests.Utils
{
    public class ExceptionUtilsTests
    {
        #region Shared

        public static Func<bool> PredicateTrue => () => true;
        public static Func<bool> PredicateFalse => () => false;

        #endregion Shared

        #region IsNull

        public static TheoryData<object?, bool> IsNullTestData => new TheoryData<object?, bool>()
        {
            { new object(), false },
            { null, true },
            { "", false },
            { (string?)null, true },
            { 5, false },
            { (int?)null, true }
        };

        [Theory]
        [MemberData(nameof(IsNullTestData))]
        public void IsNull_ReturnsCorrectResult(object? target, bool expectedResult)
        {
            var actualResult = ExceptionUtils.IsNull(target);

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion IsNull

        #region Process

        public static TheoryData<object?, Func<object?, bool>?, Func<Exception>?> ProcessWithParamExceptionTestData =>
            new TheoryData<object?, Func<object?, bool>?, Func<Exception>?>()
            {
                { new object(), null, null },
                { new object(), ExceptionUtils.IsNull, null }
            };

        [Theory]
        [MemberData(nameof(ProcessWithParamExceptionTestData))]
        public void Process_WithParam_Argument_IsNull_ThrowsException
            (object? arg, Func<object?, bool>? predicate, Func<Exception>? exceptionFactory) => Assert.Throws<ArgumentNullException>
            (() => ExceptionUtils.Process(arg, predicate!, exceptionFactory!));

        public static TheoryData<Func<bool>?, Func<Exception>?> ProcessWithoutParamExceptionTestData => new TheoryData<Func<bool>?, Func<Exception>?>()
        {
            { null, null },
            { PredicateFalse, null }
        };

        [Theory]
        [MemberData(nameof(ProcessWithoutParamExceptionTestData))]
        public void Process_WithoutParam_Argument_IsNull_ThrowsException(Func<bool>? predicate, Func<Exception>? exceptionFactory) =>
            Assert.Throws<ArgumentNullException>(() => ExceptionUtils.Process(predicate!, exceptionFactory!));

        public static Func<Exception> ArgumentNullExceptionFactory => () => new ArgumentNullException();

        public static TheoryData<object?, Func<object?, bool>, Func<Exception>, bool> ProcessWithParamTestData =>
            new TheoryData<object?, Func<object?, bool>, Func<Exception>, bool>()
            {
                { new object(), ExceptionUtils.IsNull, ArgumentNullExceptionFactory, false },
                { null, ExceptionUtils.IsNull, ArgumentNullExceptionFactory, true },
                { "", ExceptionUtils.IsNull, ArgumentNullExceptionFactory, false },
                { (string?)null, ExceptionUtils.IsNull, ArgumentNullExceptionFactory, true },
                { 5, ExceptionUtils.IsNull, ArgumentNullExceptionFactory, false },
                { (int?)null, ExceptionUtils.IsNull, ArgumentNullExceptionFactory, true }
            };

        [Theory]
        [MemberData(nameof(ProcessWithParamTestData))]
        public void Process_WithParam_ExecutesCorrectly(object? arg, Func<object?, bool> predicate, Func<Exception> exceptionFactory, bool shouldThrow)
        {
            var processDelegate = () => ExceptionUtils.Process(arg, predicate, exceptionFactory);

            if (shouldThrow)
            {
                Assert.Throws<ArgumentNullException>(processDelegate);
            }
            else
            {
                processDelegate.Invoke();
            }
        }

        public static TheoryData<Func<bool>, Func<Exception>, bool> ProcessWithoutParamTestData =>
            new TheoryData<Func<bool>, Func<Exception>, bool>()
            {
                { PredicateFalse, ArgumentNullExceptionFactory, false },
                { PredicateTrue, ArgumentNullExceptionFactory, true }
            };

        [Theory]
        [MemberData(nameof(ProcessWithoutParamTestData))]
        public void Process_WithoutParam_ExecutesCorrectly(Func<bool> predicate, Func<Exception> exceptionFactory, bool shouldThrow)
        {
            var processDelegate = () => ExceptionUtils.Process(predicate, exceptionFactory);

            if (shouldThrow)
            {
                Assert.Throws<ArgumentNullException>(processDelegate);
            }
            else
            {
                processDelegate.Invoke();
            }
        }

        #endregion Process
    }
}
