using Gif.Domain.Headers.Versions;

namespace Gif.Domain.Headers;

public class Header : IEncodable
{
    public const string SIGNITURE = "GIF";
    public VersionHeader VersionHeader { get; init; } = new Gif87();

    public byte[] Encode()
    {
        var signiture = Encoding.Default.GetBytes(SIGNITURE);
        var versionHeader = VersionHeader.Encode();

        return signiture.Concat(versionHeader).ToArray();
    }
}