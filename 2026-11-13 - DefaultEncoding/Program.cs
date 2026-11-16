using System.Text;

byte[] utf = Encoding.UTF8.GetBytes("This is some text with an emoji 🤗");
byte[] ascii = Encoding.ASCII.GetBytes("This is some text with an emoji 🤗");

// Check if they are equal 
Console.WriteLine(utf.SequenceEqual(ascii));

utf = Encoding.UTF8.GetBytes("This is some text with an emoji");
ascii = Encoding.ASCII.GetBytes("This is some text with an emoji");

Console.WriteLine(Encoding.UTF8.GetString(utf));
Console.WriteLine(Encoding.ASCII.GetString(ascii));