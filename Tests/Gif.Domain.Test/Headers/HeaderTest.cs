using FluentAssertions;
using Xunit;
using Gif.Domain.Headers;
using Gif.Domain.Headers.Versions;

namespace Gif.Domain.Test.Headers;

public class HeaderTest

{
    public static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            new Gif89(),
            new byte[] {0x47, 0x49, 0x46, 0x38, 0x39, 0x61 },
        };

        yield return new object[]
        {
            new Gif87(),
            new byte[] {0x47, 0x49, 0x46, 0x38, 0x37, 0x61 },
        };
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Header_Converts_Correctly_To_Byte_Array(VersionHeader versionHeader, byte[] expected)
    {
        var header = new Header() { VersionHeader = versionHeader, };

        header.Encode().Should().BeEquivalentTo(expected);
    }
}