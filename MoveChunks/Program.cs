using System.Text;

// Generate a long string the hard way	
var str = "";
for (var i = 1; i < 10_000; i++)
{
    str += $"{i} ";
}

Console.WriteLine(str);

// Generate using a StringBuilder
StringBuilder sb = new();
for (var i = 1; i < 10_000; i++)
{
    sb.Append($"{i} ");
}

Console.WriteLine(sb.ToString());

// Copy from one StringBuilder to another
StringBuilder oldTarget = new StringBuilder(sb.ToString());

// Move from one StringBuilder to another
Console.WriteLine($"The source has {sb.Length} characters before");
StringBuilder target = StringBuilder.MoveChunks(sb);
Console.WriteLine($"The source has {sb.Length} characters after");