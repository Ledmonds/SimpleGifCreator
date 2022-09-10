using Gif.Domain.Headers;

namespace Gif.Domain.Descriptors;

public class PackedData : IEncodable
{
    public bool GlobalColorTable { get; set; } = true;
    public ColorInformation ColorInformation { get; init; } = new();

    public byte[] Encode()
    {
        var bitArray = (!GlobalColorTable)
        ? new BitArray(8)
        : new BitArray(
            new[] { GlobalColorTable },
            ColorInformation.ColorResoloution.Bits,
            new[] { ColorInformation.SortFlag },
            ColorInformation.SizeOfGlobalColorTable.Bits
        );

        return bitArray.ToBytes();
    }
}

public class ColorInformation
{
    public BitArray ColorResoloution { get; init; } = new(3);
    public bool SortFlag { get; init; } = false;
    public BitArray SizeOfGlobalColorTable { get; init; } = new(3);
}