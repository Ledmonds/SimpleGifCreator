using FluentAssertions;
using Xunit;

namespace Gif.Domain.Test.Bits;

public class BitArrayTest
{
    public static IEnumerable<object[]> GenerateTestData()
    {
        yield return new object[]
        {
            new BitArray(false), new byte[] { 0x00 },
        };

        yield return new object[]
        {
            new BitArray(true), new byte[] { 0x01 }
        };

        yield return new object[]
        {
            new BitArray(true, false, true, true), new byte[] { 0x0B }
        };

        yield return new object[]
        {
            new BitArray(true, false, true, false, false, false, false, true), new byte[] { 0x0A, 0x01 }
        };
    }

    [Theory]
    [MemberData(nameof(GenerateTestData))]
    public void BitArray_Correctly_Converts_To_Byte(BitArray bitArray, byte[] expected)
    {
        bitArray.ToBytes().Should().BeEquivalentTo(expected);
    }
}