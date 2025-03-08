public class FieldAgent
{
    public int AgentID { get; }
    public string Name { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public AgentType AgentType { get; set; }
    public string? CountryOfPosting { get; set; }
    public bool HasDiplomaticCover { get; set; }
}