namespace Gif.Domain;

public class BitArray
{
    public IReadOnlyCollection<bool> Bits { get; init; } = Array.Empty<bool>();

    public BitArray(int length)
    {
        Bits = new bool[length];
        Bits.Select(b => false).ToArray();
    }

    public BitArray(params bool[] bits)
    {
        Bits = bits.Select(b => b).ToArray();
    }

    public BitArray(params IReadOnlyCollection<bool>[] bits)
    {
        Bits = bits.SelectMany(b => b).ToArray();
    }

    public byte[] ToBytes()
    {
        return Bits.Chunk(4)
            .Select(c => ToByte(c.Reverse()))
            .ToArray();
    }

    private static byte ToByte(IEnumerable<bool> bits)
    {
        var modifier = 1;
        var total = 0;

        foreach (var bit in bits)
        {
            total += bit
                ? 1 * modifier
                : 0;

            modifier *= 2;
        }

        return Convert.ToByte(total);
    }
}