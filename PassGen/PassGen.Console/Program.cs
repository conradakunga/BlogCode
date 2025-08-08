using PassGen;
using Spectre.Console;
using Spectre.Console.Cli;
using TextCopy;

var app = new CommandApp<GeneratePasswordCommand>();
return app.Run(args);

//
// The initial code
//
// var passwordLength = AnsiConsole.Prompt(
//     new TextPrompt<int>("How long should the password be?"));
//
// var numbers = AnsiConsole.Prompt(
//     new TextPrompt<int>("How many numbers should the password contain?"));
//
// var symbols = AnsiConsole.Prompt(
//     new TextPrompt<int>("How many symbols should the password contain?"));
//
// AnsiConsole.MarkupLineInterpolated(
//     $"Generating password of length {passwordLength} with {numbers} numbers and {symbols}...");
// try
// {
//     var password = PasswordGenerator.GeneratePassword(numbers, symbols, passwordLength);
//
//     AnsiConsole.MarkupLineInterpolated($"The generated password is [bold red]{password}[/]");
// }
// catch
//     (Exception ex)
// {
//     AnsiConsole.MarkupLineInterpolated($"[bold red]Error generating password: {ex.Message}[/]");
// }

public class GeneratePasswordCommand : Command<PasswordSettings>
{
    public override int Execute(CommandContext context, PasswordSettings settings)
    {
        // Generate password
        string password =
            PasswordGenerator.GeneratePassword(settings.Numbers, settings.Symbols, settings.PasswordLength,
                settings.HumanReadable);

        AnsiConsole.MarkupLine(
            $"Generating password with length {settings.PasswordLength}, {settings.Symbols} symbols and {settings.Numbers} digits with {(settings.HumanReadable ? "NO " : "")}ambiguous characters");

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