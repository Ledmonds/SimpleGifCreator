namespace Gif.Domain.Headers.Versions;

public abstract class VersionHeader : IEncodable
{
    public virtual string Version => "87a";

    public byte[] Encode()
    {
        return Encoding.Default.GetBytes(Version);
    }
}