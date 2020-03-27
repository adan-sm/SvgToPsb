using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Domain.ImageResources
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VersionInfoTests
    {
        [Test]
        public void CreateDefault_ShouldCreateDefaultVersionInfo_WhenCalled()
        {
            // arrange
            var version = System.Reflection.Assembly.GetAssembly(typeof(Psb.Domain.ImageResources.Implementations.VersionInfo)).GetName().Version;
            var expectedVersion = (uint)version.Major;
            var expectedFileVersion = (uint)version.Major;
            var expectedHasRealMergedData = false;
            var expectedWriterName = $"Svg2Psb {version.Major}.{version.Minor}.{version.Build}";

            // act
            var result = Psb.Domain.ImageResources.Implementations.VersionInfo.CreateDefaultVersionInfo();

            // assert
            Assert.AreEqual(Psb.Domain.ImageResources.ImageResourcesId.PS6_VersionInfo, result.Id);
            Assert.IsEmpty(result.Name);
            Assert.AreEqual(expectedVersion, result.Version);
            Assert.AreEqual(expectedFileVersion, result.FileVersion);
            Assert.AreEqual(expectedHasRealMergedData, result.HasRealMergedData);
            Assert.IsEmpty(result.ReaderName);
            Assert.AreEqual(expectedWriterName, result.WriterName);
        }
    }
}
