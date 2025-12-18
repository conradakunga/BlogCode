using System.Net.Mime;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public static class ResultEx
{
    extension(Results)
    {
        public static async Task<IResult> Xml<T>(T value)
        {
            return Results.Text(await Serialize(value), MediaTypeNames.Text.Xml, Encoding.UTF8);
        }

        private static async Task<string> Serialize<T>(T value)
        {
            var serializer = new XmlSerializer(typeof(T));
            await using var ms = new MemoryStream();
            await using (var writer = XmlWriter.Create(
                             ms,
                             new XmlWriterSettings
                             {
                                 Encoding = Encoding.UTF8,
                                 Indent = true,
                                 Async = true
                             }))
            {
                serializer.Serialize(writer, value);
            }

            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}