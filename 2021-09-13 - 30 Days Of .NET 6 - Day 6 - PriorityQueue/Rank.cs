public class Rank
{
	public string Name { get; set; }
	public byte Weight { get; set; }
}

public class RankComparable : IComparer<Rank>
{
	public int Compare(Rank a, Rank b)
	{
		if (a.Weight == b.Weight)
			return 0;
		if (a.Weight > b.Weight)
			return -1;

		return 1;
	}
}