namespace Gif.Domain.Descriptors;

public class Descriptor : IEncodable
{
    public ushort CanvasWidth { get; init; }
    public ushort CanvasHeight { get; init; }
    public PackedData PackedData { get; init; } = new();
    public byte BackgroundColorIndex { get; set; }
    public byte PixelAspectRatio { get; set; }

    public byte[] Encode()
    {
        return BitConverter.GetBytes(CanvasWidth)
            .Concat(BitConverter.GetBytes(CanvasHeight))
            .Concat(PackedData.Encode())
            .Append(BackgroundColorIndex)
            .Append(PixelAspectRatio)
            .ToArray();
    }
}