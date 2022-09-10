namespace Gif.Domain.Descriptors;

public class Descriptor
{
    public uint CanvasWidth { get; init; }
    public uint CanvasHeight { get; init; }

    public PackedData PackedData { get; init; } = new();
}