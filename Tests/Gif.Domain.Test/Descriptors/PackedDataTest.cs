using FluentAssertions;
using Gif.Domain.Descriptors;
using Xunit;

namespace Gif.Domain.Test.Descriptors;

public class PackedDataTest
{
    [Theory]
    [InlineData(false, new byte[] { 0x00, 0x00 })]
    [InlineData(true, new byte[] { 0x08, 0x00 })]
    public void ColorTable_Changes_Encoding_As_Most_Significant_Bit(bool colorTable, byte[] expected)
    {
        var packedData = new PackedData() { GlobalColorTable = colorTable, };

        packedData.Encode().Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void All_Bits_In_Packed_Data_Influence_Encoding()
    {
        var packedData = new PackedData()
        {
            GlobalColorTable = true,
            ColorInformation = new()
            {
                ColorResoloution = new(false, false, true),
                SortFlag = false,
                SizeOfGlobalColorTable = new(false, false, true),
            }
        };

        var expected = new byte[] { 0x09, 0x01 };

        packedData.Encode().Should().BeEquivalentTo(expected);
    }
}