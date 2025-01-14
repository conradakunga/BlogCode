public class ApplicationOptions
{
    public string APIKey { get; set; } = null!;
    public int RetryCount { get; set; }
    public int RequestsPerMinute { get; set; }
    public int RequestsPerDay { get; set; }
}