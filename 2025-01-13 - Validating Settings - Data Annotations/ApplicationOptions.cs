using System.ComponentModel.DataAnnotations;

public class ApplicationOptions
{
    [Required]
    [StringLength(10)]
    [RegularExpression("^[A-Z]{10}$")]
    public string APIKey { get; set; } = null!;

    [Required] [Range(1, 5)] public int RetryCount { get; set; }
    [Range(0, 1_000)] [Required] public int RequestsPerMinute { get; set; }
    [Required] public int RequestsPerDay { get; set; }
}