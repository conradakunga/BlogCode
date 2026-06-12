public static class ByteArrayExtensions
{
	public static string ToHexString(this byte[] bytes)
	{
		var sb = new StringBuilder(bytes.Length * 2);
		foreach (var b in bytes)
			sb.Append(b.ToString("X2"));
		return sb.ToString();
	}
}
