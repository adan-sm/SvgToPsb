using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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
            },
            new RectangleTestCase
            {
                // ---
                // | |
                // ------
                //    | |
                //    ---
                Rectangles = new List<Psb.Domain.Rectangle>
                {
                    new Psb.Domain.Rectangle
                    {
                        Top = 0,
                        Left = 0,
                        Bottom = 10,
                        Right = 10
                    },
                    new Psb.Domain.Rectangle
                    {
                        Top = 10,
                        Left = 10,
                        Bottom = 20,
                        Right = 20
                    }
                },
                ExpectedTop = 0,
                ExpectedLeft = 0,
                ExpectedBottom = 20,
                ExpectedRight = 20
            },
            new RectangleTestCase
            {
                // -------
                // | | | |
                // -------
                Rectangles = new List<Psb.Domain.Rectangle>
                {
                    new Psb.Domain.Rectangle
                    {
                        Top = 0,
                        Left = 0,
                        Bottom = 10,
                        Right = 10
                    },
                    new Psb.Domain.Rectangle
                    {
                        Top = 0,
                        Left = 5,
                        Bottom = 10,
                        Right = 15
                    }
                },
                ExpectedTop = 0,
                ExpectedLeft = 0,
                ExpectedBottom = 10,
                ExpectedRight = 15
            },
            new RectangleTestCase
            {
                // -------
                // |     |
                // | --- |
                // | | | |
                // | --- |
                // |     |
                // -------
                Rectangles = new List<Psb.Domain.Rectangle>
                {
                    new Psb.Domain.Rectangle
                    {
                        Top = 5,
                        Left = 5,
                        Bottom = 20,
                        Right = 20
                    },
                    new Psb.Domain.Rectangle
                    {
                        Top = 10,
                        Left = 10,
                        Bottom = 15,
                        Right = 15
                    }
                },
                ExpectedTop = 5,
                ExpectedLeft = 5,
                ExpectedBottom = 20,
                ExpectedRight = 20
            },
            new RectangleTestCase
            {
                // ---
                // | |
                // --- 
                //     ---
                //     | |
                //     ---
                Rectangles = new List<Psb.Domain.Rectangle>
                {
                    new Psb.Domain.Rectangle
                    {
                        Top = 5,
                        Left = 5,
                        Bottom = 10,
                        Right = 10
                    },
                    new Psb.Domain.Rectangle
                    {
                        Top = 15,
                        Left = 15,
                        Bottom = 25,
                        Right = 25
                    }
                },
                ExpectedTop = 5,
                ExpectedLeft = 5,
                ExpectedBottom = 25,
                ExpectedRight = 25
            },
            new RectangleTestCase
            {
                // ---     ---
                // | |     | |
                // ---     ---
                //     ---
                //     | |
                //     ---
                Rectangles = new List<Psb.Domain.Rectangle>
                {
                    new Psb.Domain.Rectangle
                    {
                        Top = 5,
                        Left = 5,
                        Bottom = 10,
                        Right = 10
                    },
                    new Psb.Domain.Rectangle
                    {
                        Top = 15,
                        Left = 15,
                        Bottom = 20,
                        Right = 20
                    },
                    new Psb.Domain.Rectangle
                    {
                        Top = 0,
                        Left = 25,
                        Bottom = 10,
                        Right = 30
                    }
                },
                ExpectedTop = 0,
                ExpectedLeft = 5,
                ExpectedBottom = 20,
                ExpectedRight = 30
            },
        };

        [TestCaseSource(nameof(RectangleTestCases))]
        public void Merge_ShouldMergeCorrectlyRectangles_WhenCalled(RectangleTestCase rectangleTestCase)
        {
            // arrange
            Psb.Domain.Rectangle result = rectangleTestCase.Rectangles.First();

            // act
            for (int i = 1; i < rectangleTestCase.Rectangles.Count; i++)
            {
                result = Psb.Domain.Rectangle.Merge(result, rectangleTestCase.Rectangles[i]);
            }

            // assert
            Assert.AreEqual(rectangleTestCase.ExpectedTop, result.Top);
            Assert.AreEqual(rectangleTestCase.ExpectedLeft, result.Left);
            Assert.AreEqual(rectangleTestCase.ExpectedBottom, result.Bottom);
            Assert.AreEqual(rectangleTestCase.ExpectedRight, result.Right);
        }
    }
}
