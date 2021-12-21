Console.WriteLine(Concatenate(null, "two"));

string Concatenate(string first, string second)
{
    ArgumentNullException.ThrowIfNull(first);
    ArgumentNullException.ThrowIfNull(second);

    return first + second;
}