using FizzWare.NBuilder;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Domain
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FileModeComputerTests
    {
        [TestCase(Psb.Domain.Enums.FileMode.RegularFile, (uint)10, (uint)10)]
        [TestCase(Psb.Domain.Enums.FileMode.RegularFile, Psb.Domain.Consts.PsdFile.MaxRegularFileWidth, Psb.Domain.Consts.PsdFile.MaxRegularFileHeight)]
        [TestCase(Psb.Domain.Enums.FileMode.BigFile, (uint)(Psb.Domain.Consts.PsdFile.MaxRegularFileWidth + 1), (uint)10)]
        [TestCase(Psb.Domain.Enums.FileMode.BigFile, (uint)10, (uint)(Psb.Domain.Consts.PsdFile.MaxRegularFileHeight + 1))]
        [TestCase(Psb.Domain.Enums.FileMode.BigFile, (uint)(Psb.Domain.Consts.PsdFile.MaxRegularFileWidth + 1), (uint)(Psb.Domain.Consts.PsdFile.MaxRegularFileHeight + 1))]
        public void GetFileMode_ShouldReturnCorrectMode_WhenCalledWithAccordingPsdDimensions(Psb.Domain.Enums.FileMode expectedFileMode, uint width, uint height)
        {
            // arrange
            var sut = new Psb.Domain.Implementations.FileModeComputer();
            var psdFile = Builder<Psb.Domain.PsdFile>
                            .CreateNew()
                                .With(p => p.Width = width)
                                .With(p => p.Height = height)
                            .Build();

            // act
            var result = sut.GetFileMode(psdFile);

            // assert
            Assert.AreEqual(expectedFileMode, result);
        }
    }
}
