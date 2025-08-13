using Spectre.Console;
using Spectre.Console.Cli;
using TextCopy;

namespace PassGen.Console;

public sealed class GeneratePasswordCommand : Command<PasswordSettings>
{
    public override int Execute(CommandContext context, PasswordSettings settings)
    {
        // Temporary list  to store number of generated passwords
        var passwordList = new List<string>(settings.PasswordCount);
        for (var i = 0; i < settings.PasswordCount; i++)
        {
            string password;
            if (settings.MemorableUncapitalized)
            {
                //Generate memorable password
                password = PasswordGenerator.GenerateMemorablePassword();

                AnsiConsole.MarkupLine(
                    $"Generating memorable password, uncapitalized [blue]({i + 1} of {settings.PasswordCount})[/]");
            }
            else if (settings.MemorableCapitalized)
            {
                password = PasswordGenerator.GenerateMemorablePassword(true);

                AnsiConsole.MarkupLine(
                    $"Generating memorable password, capitalized [blue]({i + 1} of {settings.PasswordCount})[/]");
            }
            else
            {
                // Generate password
                password =
                    PasswordGenerator.GeneratePassword(settings.Numbers, settings.Symbols, settings.PasswordLength,
                        settings.HumanReadable);

                AnsiConsole.MarkupLine(
                    $"Generating password [blue]({i + 1} of {settings.PasswordCount})[/] with length {settings.PasswordLength}, {settings.Symbols} symbols and {settings.Numbers} digits with {(settings.HumanReadable ? "NO " : "")}ambiguous characters");
            }

            passwordList.Add(password);
        }

        var finalPassword = string.Join(Environment.NewLine, passwordList);
        // Copy generated password to clipboard
        ClipboardService.SetText(finalPassword);
        AnsiConsole.MarkupLine($"[green]Generated successfully, and copied to clipboard[/]");

        // Ask the user to confirm password display
        var viewPassword = AnsiConsole.Prompt(
            new ConfirmationPrompt("View?"));

        // If user said yes, print the password
        if (viewPassword)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"[bold]{Markup.Escape(finalPassword)}[/]");
        }

        return 0;
    }
}