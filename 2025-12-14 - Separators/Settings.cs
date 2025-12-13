using System.ComponentModel.DataAnnotations;

public sealed class Settings
{
    [Required(AllowEmptyStrings = true)] public string DecimalSeparator { get; set; } = ".";
    [Required(AllowEmptyStrings = true)] public string ThousandSeparator { get; set; } = ",";
}