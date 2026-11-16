using System.Security.Cryptography;
using System.Text;

{
    byte[] rawData = Encoding.UTF8.GetBytes("Hello, streaming Base64 in .NET!");

    using (var inputStream = new MemoryStream(rawData))
    {
        using (var outputStream = new MemoryStream())
        {
            using (var transform = new ToBase64Transform())
            {
                using (var cryptoStream =
                       new CryptoStream(outputStream, transform, CryptoStreamMode.Write, leaveOpen: true))
                {
                    inputStream.CopyTo(cryptoStream);
                    // Important to flush the last bytes and add padding
                    cryptoStream.FlushFinalBlock();
                }
            }

            // Fetch our data from the output stream
            var base64Result = Encoding.ASCII.GetString(outputStream.ToArray());
            Console.WriteLine(base64Result); //
        }
    }
}

using (var inputStream = File.OpenRead("VeryLargeFileForEncoding.txt"))
{
    using (var outputStream = File.Create("EncodedFile"))
    {
        using (var transform = new ToBase64Transform())
        {
            using (var cryptoStream = new CryptoStream(outputStream, transform, CryptoStreamMode.Write))
            {
                inputStream.CopyTo(cryptoStream);
                cryptoStream.FlushFinalBlock();
            }
        }
    }
}

{
    var rawData = File.ReadAllBytes("SmallOrMediumFile.txt");
    var base64Result = Convert.ToBase64String(rawData);
    Console.WriteLine(base64Result);
}