using Gif.Domain.Headers;

var header = new Header();

Console.WriteLine(BitConverter.ToString(header.Encode()));