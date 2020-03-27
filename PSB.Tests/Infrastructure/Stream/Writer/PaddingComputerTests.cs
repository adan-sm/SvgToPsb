using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PaddingComputerTests
    {
        [TestCase(-1)]
        [TestCase(-10)]
        public void GetPadding_ShouldThrowArgumentException_WhenCalledWithIncorrectLength(int length)
        {
            // arrange
            var sut = new Psb.Infrastructure.Stream.Writer.Implementations.PaddingComputer();

            // act
            var result = Assert.Throws<ArgumentException>(() => sut.GetPadding(length, 1));

            // result
            Assert.AreEqual(result.ParamName, "length");
            Assert.IsTrue(result.Message.StartsWith("Length must be >= 0"));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void GetPadding_ShouldThrowArgumentException_WhenCalledWithIncorrectPadMultiple(int padMultiple)
        {
            // arrange
            var sut = new Psb.Infrastructure.Stream.Writer.Implementations.PaddingComputer();

            // act
            var result = Assert.Throws<ArgumentException>(() => sut.GetPadding(1, padMultiple));

            // result
            Assert.AreEqual(result.ParamName, "padMultiple");
            Assert.IsTrue(result.Message.StartsWith("Pad multiple must be > 0"));
        }

        [TestCase(0, 1, 0)]
        [TestCase(0, 2, 0)]
        [TestCase(1, 2, 1)]
        [TestCase(4, 2, 0)]
        [TestCase(4, 3, 2)]
        [TestCase(2, 1, 0)]
        [TestCase(2, 2, 0)]
        public void GetPadding_ShouldReturnCorrectValue_WhenCalled(int length, int padMultiple, int expectedPadding)
        {
            // arrange
            var sut = new Psb.Infrastructure.Stream.Writer.Implementations.PaddingComputer();

            // act
            var result = sut.GetPadding(length, padMultiple);

            // assert
            Assert.AreEqual(expectedPadding, result);
        }
    }
}
