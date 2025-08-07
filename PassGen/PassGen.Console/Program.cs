using PassGen;
using Spectre.Console;

var passwordLength = AnsiConsole.Prompt(
    new TextPrompt<int>("How long should the password be?"));
var numbers = AnsiConsole.Prompt(
    new TextPrompt<int>("How many numbers should the password contain?"));
var symbols = AnsiConsole.Prompt(
    new TextPrompt<int>("How many symbols should the password contain?"));

AnsiConsole.MarkupLineInterpolated(
    $"Generating password of length {passwordLength} with {numbers} numbers and {symbols}...");

try
{
    var password = PasswordGenerator.GeneratePassword(numbers, symbols, passwordLength);

    AnsiConsole.MarkupLineInterpolated($"The generated password is [bold red]{password}[/]");
}
catch (Exception ex)
{
    AnsiConsole.MarkupLineInterpolated($"[bold red]Error generating password: {ex.Message}[/]");
}