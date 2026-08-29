var str = "cocoa butter".AsEnumerable();
Console.WriteLine((char)str[0]);


// public static class EnumerableExtensions
// {
// 	public static char ItemAt(this IEnumerable<char> str, int index)
// 	{
// 		return str.ElementAt(index);
// 	}
// }

public static class EnumerableExtensions
{
    extension(IEnumerable<char> enumerable)
    {
        public int this[int index] => enumerable.ElementAt(index);
    }
}