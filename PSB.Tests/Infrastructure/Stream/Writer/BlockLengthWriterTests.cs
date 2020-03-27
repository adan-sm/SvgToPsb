using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class BlockLengthWriterTests
    {
        [TestCase((long)0, (long)10, (uint)(10 - sizeof(uint)))]
        [TestCase((long)10, (long)15, (uint)(5 - sizeof(uint)))]
        public void CompleteSequenceShouldWriteCorrectLength_WhenUsedWithRegularFile(long startPosition, long endPosition, uint expectedLength)
        {
            // arrange
            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var iterator = GetNextValue(startPosition, startPosition + sizeof(uint), endPosition).GetEnumerator();
            iterator.MoveNext();

            binaryWriter
                .SetupGet(b => b.Position)
                    .Returns(() => { var result = iterator.Current; iterator.MoveNext(); return result; })
                .Verifiable();

            binaryWriter
                .Setup(b => b.WriteUInt32(expectedLength))
                .Verifiable();

            binaryWriter
                .Setup(b => b.Seek(startPosition))
                .Verifiable();

            binaryWriter
                .Setup(b => b.Seek(endPosition))
                .Verifiable();

            // act
            using (var sut = Psb.Infrastructure.Stream.Writer.BlockLengthWriter.CreateBlockLengthWriter(binaryWriter.Object, Psb.Domain.Enums.FileMode.RegularFile))
            {

            }

            // assert
            binaryWriter.Verify();
        }

        [TestCase((long)0, (long)10, (uint)(10 - sizeof(uint)))]
        [TestCase((long)10, (long)15, (uint)(5 - sizeof(uint)))]
        public void CompleteSequenceShouldWriteCorrectLength_WhenUsedWithBigFile(long startPosition, long endPosition, uint expectedLength)
        {
            // arrange
            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var iterator = GetNextValue(startPosition, startPosition + sizeof(uint), endPosition).GetEnumerator();
            iterator.MoveNext();

            binaryWriter
                .SetupGet(b => b.Position)
                    .Returns(() => { var result = iterator.Current; iterator.MoveNext(); return result; })
                .Verifiable();

            binaryWriter
                .Setup(b => b.WriteUInt64(expectedLength))
                .Verifiable();

            binaryWriter
                .Setup(b => b.Seek(startPosition))
                .Verifiable();

            binaryWriter
                .Setup(b => b.Seek(endPosition))
                .Verifiable();

            // act
            using (var sut = Psb.Infrastructure.Stream.Writer.BlockLengthWriter.CreateBlockLengthWriter(binaryWriter.Object, Psb.Domain.Enums.FileMode.BigFile))
            {

            }

            // assert
            binaryWriter.Verify();
        }

        private IEnumerable<long> GetNextValue(params long[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                yield return values[i];
            }
        }
    }
}
