using System.Text.Json;
using System.Text.Json.Serialization;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;

namespace ImageSerialization;

/// <summary>
/// A JsonConverter that handles Image Serialization 
/// </summary>
public class ImageJsonConverter : JsonConverter<Image>
{
    public override Image? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // This is the deserialization process. Read the data as a stream of bytes
        return Image.Load<Rgba32>(reader.GetBytesFromBase64());
    }

    public override void Write(Utf8JsonWriter writer, Image value, JsonSerializerOptions options)
    {
        // This is the serialization process. Obtain the bytes of the image and write them as a stream
        using (var ms = new MemoryStream())
        {
            value.Save(ms, new JpegEncoder());
            writer.WriteBase64StringValue(ms.ToArray());
        }
    }
}