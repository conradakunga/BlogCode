public sealed record Country
{
    public Guid CountryID { get; set; }
    public string Name { get; set; } = null!;
}