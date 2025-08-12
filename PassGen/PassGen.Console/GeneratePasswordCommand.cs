using Spectre.Console;
using Spectre.Console.Cli;
using TextCopy;

namespace PassGen.Console;

public sealed class GeneratePasswordCommand : Command<PasswordSettings>
{
    public override int Execute(CommandContext context, PasswordSettings settings)
    {
        var password = "";
        if (settings.MemorableUncapitalized)
        {
            //Generate memorable password
            password = PasswordGenerator.GenerateMemorablePassword();

            AnsiConsole.MarkupLine(
                "Generating memorable password, uncapitalized");
        }
        else if (settings.MemorableCapitalized)
        {
            password = PasswordGenerator.GenerateMemorablePassword(true);

            AnsiConsole.MarkupLine(
                "Generating memorable password, capitalized");
        }
        else
        {
            // Generate password
            password =
                PasswordGenerator.GeneratePassword(settings.Numbers, settings.Symbols, settings.PasswordLength,
                    settings.HumanReadable);

            AnsiConsole.MarkupLine(
                $"Generating password with length {settings.PasswordLength}, {settings.Symbols} symbols and {settings.Numbers} digits with {(settings.HumanReadable ? "NO " : "")}ambiguous characters");
        }

        // Copy generated password to clipboard
        ClipboardService.SetText(password);
        AnsiConsole.MarkupLine($"[green]Generated Password successfully, and copied to clipboard[/]");

        // Ask the user to confirm password display
        var viewPassword = AnsiConsole.Prompt(
            new ConfirmationPrompt("View password?"));

        // If user said yes, print the password
        if (viewPassword)
            AnsiConsole.MarkupLine($"[bold]{Markup.Escape(password)}[/]");
        return 0;
    }
}