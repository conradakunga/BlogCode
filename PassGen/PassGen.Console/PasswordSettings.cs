using System.ComponentModel;
using PassGen;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class PasswordSettings : CommandSettings
{
    [CommandOption("-l|--length <LENGTH>")]
    [Description("Length of the password (required)")]
    public int PasswordLength { get; set; }

    [CommandOption("-n|--numbers")]
    [Description("Number of digits required in the password")]
    public int Numbers { get; set; }

    [CommandOption("-s|--symbols")]
    [Description("Number of special symbols required in the password")]
    public int Symbols { get; set; }

    public override ValidationResult Validate()
    {
        if (Symbols < 0)
            return ValidationResult.Error(
                "Symbols cannot be less than 0");

        if (Numbers < 0)
            return ValidationResult.Error(
                "Numbers cannot be less than 0");

        if (PasswordLength < Constants.MinimumPasswordLength)
            return ValidationResult.Error(
                $"Password length must be at least {Constants.MinimumPasswordLength} characters.");
        return ValidationResult.Success();
    }
}