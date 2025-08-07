using System.ComponentModel;
using PassGen;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class PasswordSettings : CommandSettings
{
    [CommandOption("-l|--length <LENGTH>")]
    [Description("Length of the password (required)")]
    public byte PasswordLength { get; set; }

    [CommandOption("-n|--numbers")]
    [Description("Number of digits required in the password")]
    public byte Numbers { get; set; }

    [CommandOption("-s|--symbols")]
    [Description("Number of special symbols required in the password")]
    public byte Symbols { get; set; }

    [CommandOption("-r|--readable")]
    [Description("Whether passwords should not contaim ambiguous characters")]
    public bool HumanReadable { get; set; }

    public override ValidationResult Validate()
    {
        if (PasswordLength < Constants.MinimumPasswordLength)
            return ValidationResult.Error(
                $"Password length must be at least {Constants.MinimumPasswordLength} characters.");
        return ValidationResult.Success();
    }
}