public sealed record CreateBureauRequest
{
    public string Name { get; set; } = null!;
    public string LogoText { get; set; }
}