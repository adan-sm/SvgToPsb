using NUnit.Framework;
using Psb.Domain;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Domain
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PsdFileTests
    {
        [TestCase((uint)0, "Minimum width : 1")]
        [TestCase((uint)(Consts.PsdFile.MaxWidth + 1), "Maximum width : 300000")]
        public void SetWidth_ShouldThrowsArgumentException_WhenCalledWithIncorrectValue(uint width, string expectedMessageStart)
        {
            // arrange
            var sut = new PsdFile();
            var testMethod = new TestDelegate(() => sut.Width = width);

            // act
            var result = Assert.Throws<ArgumentException>(testMethod);

            // assert
            Assert.IsTrue(result.Message.StartsWith(expectedMessageStart));
        }

        [TestCase((uint)0, "Minimum height : 1")]
        [TestCase((uint)(Consts.PsdFile.MaxHeight + 1), "Maximum height : 300000")]
        public void SetHeight_ShouldThrowsArgumentException_WhenCalledWithIncorrectValue(uint height, string expectedMessageStart)
        {
            // arrange
            var sut = new PsdFile();
            var testMethod = new TestDelegate(() => sut.Height = height);

            // act
            var result = Assert.Throws<ArgumentException>(testMethod);

            // assert
            Assert.IsTrue(result.Message.StartsWith(expectedMessageStart));
        }

        [TestCase((ushort)0, "Minimum channel count : 1")]
        [TestCase((ushort)(Consts.PsdFile.MaxChannelCount + 1), "Maximum channel count : 56")]
        public void SetChannelCount_ShouldThrowsArgumentException_WhenCalledWithIncorrectValue(ushort channelCount, string expectedMessageStart)
        {
            // arrange
            var sut = new PsdFile();
            var testMethod = new TestDelegate(() => sut.ChannelCount = channelCount);

            // act
            var result = Assert.Throws<ArgumentException>(testMethod);

            // assert
            Assert.IsTrue(result.Message.StartsWith(expectedMessageStart));
        }
    }
}
