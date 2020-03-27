using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer.ImageResourceWriters
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ImageResourceWriterFactoryTests
    {
        [Test]
        public void Get_ShouldReturnVersionInfoWriter_WhenCalledWithVersionInfo()
        {
            // arrange
            var sut = new Psb.Infrastructure.Stream.Writer.ImageResourceWriters.ImageResourceWriterFactory();
            var versionInfo = new Psb.Domain.ImageResources.Implementations.VersionInfo();

            // act
            var result = sut.Get(versionInfo);

            // assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Psb.Infrastructure.Stream.Writer.ImageResourceWriters.VersionInfoWriter>(result);
        }

        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.AlphaChannelsNames)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.BackgroundColor)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.BlackAndWhiteDotRange)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.BorderInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.CaptionPascalString)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.ClippingPathName)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.ColorHalftoningInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.ColorTransferFunctions)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.DuotoneHalftoningInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.DuotoneImageInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.DuotoneTransferFunctions)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.EPSOptions)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.GrayscaleAndMultichannelHalftoningInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.GrayscaleMultichannelTransferFunction)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.ImageModeForRawFormatFiles)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.ImageReady7RolloverExpandedState)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.ImageReadyDataSets)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.ImageReadyDefaultSelectedState)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.ImageReadyRolloverExpandedState)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.ImageReadySaveLayerSettings)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.ImageReadyVariables)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.ImageReadyVersion)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.IPTC_NAARecord)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.JPEGQuality)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.LayersGroupInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.LayerStateInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.MacintoshPrintManagerPrintInfoRecord)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.Obsolete01)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.Obsolete02)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.Obsolete03)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.Obsolete_DisplayInfo)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.Obsolete_MacintoshPageFormatInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.Obsolete_PS2_ChannelsRowsColumnsDepthMode)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.Obsolete_PS2_IndexedColorTable)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.Obsolete_PS5_ColorSamplersResource)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PathInformation_End)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PathInformation_Start)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCC_OriginPathInfo)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCC_PathSelectionState)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS2_HDRToningInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS2_LayerGroupEnabledID)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS2_LayerSelectionID)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS2_PrintInfo)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS3_ColorSamplersResource)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS3_DisplayInfo)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS3_LightroomWorkflow)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS3_MeasurementScale)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS3_OnionSkins)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS3_SheetDisclosure)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS3_TimelineInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS4_CountInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS5_MacintoshNSPrintInfo)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS5_PrintInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS5_PrintStyle)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS5_WindowsDEVMODE)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS6_AutoSaveFilePath)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS6_AutoSaveFormat)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS_AlternateDuotoneColors)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS_AlternateSpotColors)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS_LayerComps)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PCS_PixelAspectRatio)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PlugInResource_End)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PlugInResource_Start)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PrintFlags)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PrintFlagsInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS4_CopyrightFlag)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS4_GridAndGuides)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS4_Thumbnail)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS4_URL)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS5_DocumentSpecificID)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS5_EffectsVisible)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS5_GlobalAngle)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS5_ICCProfile)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS5_ICCUntaggedProfile)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS5_SpotHalftone)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS5_Thumbnail)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS5_UnicodeAlphaNames)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS5_Watermark)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS6_AlphaIdentifiers)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS6_GlobalAltitude)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS6_IndexedColorTableCount)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS6_JumpToXPEP)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS6_Slices)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS6_TransparencyIndex)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS6_URLList)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS6_WorkflowURL)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS7_CaptionDigest)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS7_EXIF_Data_1)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS7_EXIF_Data_3)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS7_PrintScale)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.PS7_XMP_Metadata)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.QuickMaskInformation)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.ResolutionInfo)]
        [TestCase(Psb.Domain.ImageResources.ImageResourcesId.WorkingPath)]
        public void Get_ShouldThrowNotImplementedException_WhenCalled(ushort resourceId)
        {
            // arrange
            var sut = new Psb.Infrastructure.Stream.Writer.ImageResourceWriters.ImageResourceWriterFactory();
            var imageResource = new Moq.Mock<Psb.Domain.IImageResource>();

            imageResource
                .SetupGet(i => i.Id)
                .Returns(resourceId);

            // act, assert
            var result = Assert.Throws<NotImplementedException>(() => sut.Get(imageResource.Object));
        }
    }
}
