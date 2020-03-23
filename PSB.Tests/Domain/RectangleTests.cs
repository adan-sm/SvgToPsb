using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Domain
{
    public class RectangleTestCase
    {
        public List<Psb.Domain.Rectangle> Rectangles { get; set; }
    
        public int ExpectedTop { get; set; }

        public int ExpectedLeft { get; set; }

        public int ExpectedBottom { get; set; }

        public int ExpectedRight { get; set; }
    }

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RectangleTests
    {
        static List<RectangleTestCase> RectangleTestCases = new List<RectangleTestCase>
        {
            new RectangleTestCase
            {
                Rectangles = new List<Psb.Domain.Rectangle>
                {
                    new Psb.Domain.Rectangle
                    {
                        Top = 0,
                        Left = 0,
                        Bottom = 10,
                        Right = 10
                    }
                },
                ExpectedTop = 0,
                ExpectedLeft = 0,
                ExpectedBottom = 10,
                ExpectedRight = 10
            }
        };

        [TestCaseSource(nameof(RectangleTestCases))]
        public void Merge_ShouldMergeCorrectlyRectangles_WhenCalled(RectangleTestCase rectangleTestCase)
        {
            // arrange
            Psb.Domain.Rectangle result = new Psb.Domain.Rectangle();

            // act
            foreach (var currentRectangle in rectangleTestCase.Rectangles)
            {
                result = Psb.Domain.Rectangle.Merge(result, currentRectangle);
            }

            // assert
            Assert.AreEqual(rectangleTestCase.ExpectedTop, result.Top);
            Assert.AreEqual(rectangleTestCase.ExpectedLeft, result.Left);
            Assert.AreEqual(rectangleTestCase.ExpectedBottom, result.Bottom);
            Assert.AreEqual(rectangleTestCase.ExpectedRight, result.Right);
        }
    }
}
