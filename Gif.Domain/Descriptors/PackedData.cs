namespace Gif.Domain.Descriptors;

public class PackedData : IEncodable
{
    public bool GlobalColorTable { get; set; } = true;
    public BitArray ColorResoloution { get; init; } = new(3);
    public bool SortFlag { get; init; } = false;
    public BitArray SizeOfGlobalColorTable { get; init; } = new(3);

    public byte[] Encode()
    {
        var bitArray = (!GlobalColorTable)
            ? new BitArray(8)
            : new BitArray(
                new[] { GlobalColorTable },
                ColorResoloution.Bits,
                new[] { SortFlag },
                SizeOfGlobalColorTable.Bits
            );

        return bitArray.ToBytes();
    }
}