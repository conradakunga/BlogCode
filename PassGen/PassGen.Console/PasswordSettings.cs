using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace PassGen.Console;

public sealed class PasswordSettings : CommandSettings
{
    [CommandOption("-l|--length <LENGTH>")]
    [Description("Length of the password (required)")]
    [DefaultValue(15)]
    public int PasswordLength { get; set; }

    [CommandOption("-n|--numbers")]
    [Description("Number of digits required in the password")]
    public int Numbers { get; set; }

    [CommandOption("-s|--symbols")]
    [Description("Number of special symbols required in the password")]
    public int Symbols { get; set; }

    [CommandOption("-r|--readable")]
    [Description("Whether passwords should not contaim ambiguous characters")]
    public bool HumanReadable { get; set; }

    [CommandOption("-m|--memorable")]
    [Description("Whether passwords generated should be memorable, no capitalization")]
    public bool MemorableUncapitalized { get; set; }

    [CommandOption("-c|--memorableCapitalized")]
    [Description("Whether passwords generated should be memorable and capitalized")]
    public bool MemorableCapitalized { get; set; }

    [CommandOption("-p|--passwordCount")]
    [Description("The number of passwords to generate")]
    [DefaultValue(1)]
    public int PasswordCount { get; set; }

    public override ValidationResult Validate()
    {
        if (PasswordCount < 0)
            return ValidationResult.Error("Password count must be greater than 0.");

        if (Numbers < 0)
            return ValidationResult.Error("Numbers must be greater than or equal to 0.");

        if (Symbols < 0)
            return ValidationResult.Error("Symbols must be greater than or equal to 0.");

        if (PasswordLength < Constants.MinimumPasswordLength)
            return ValidationResult.Error(
                $"Password length must be at least {Constants.MinimumPasswordLength} characters.");

        return ValidationResult.Success();
    }
}