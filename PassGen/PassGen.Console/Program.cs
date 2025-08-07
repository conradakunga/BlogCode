using PassGen;
using Spectre.Console;
using Spectre.Console.Cli;
using TextCopy;

var app = new CommandApp<GeneratePasswordCommand>();
return app.Run(args);

public class GeneratePasswordCommand : Command<PasswordSettings>
{
    public override int Execute(CommandContext context, PasswordSettings settings)
    {
        // Generate password
        string password =
            PasswordGenerator.GeneratePassword(settings.Numbers, settings.Symbols, settings.PasswordLength);

        AnsiConsole.MarkupLine(
            $"Generating password with length {settings.PasswordLength}, {settings.Symbols} symbols and {settings.Numbers} digits!");

        // Copy generated password to clipboard
        ClipboardService.SetText(password);

        AnsiConsole.MarkupLine($"[green]Generated Password successfully, and copied to clipboard[/]");
        return 0;
    }
}