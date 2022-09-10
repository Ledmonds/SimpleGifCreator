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
    public void ToBytes_Converts_Byte_Array_Equivalent(BitArray bitArray, byte[] expected)
    {
        bitArray.ToBytes().Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Empty_BitArray_Converts_To_Empty_Byte_Array()
    {
        var bitArray = new BitArray(0);
        bitArray.ToBytes().Should().BeEquivalentTo(Array.Empty<byte>());
    }
}