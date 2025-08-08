namespace PassGen;

public static class Constants
{
    public const string NumericAlphabet = "0123456789";
    public const string AmbiguousNumericAlphabet = "01";

    public const string CharacterAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    public const string AmbiguousCharacterAlphabet = "IJOijko";

    public const string SymbolAlphabet = "~!@#$%^&*()_+{}|:\"?><;[]\\;',./";
    public const int MinimumPasswordLength = 10;

    public const int MemorableWordCount = 4;
    public const int MinimumMemorableWordLength = 3;
    public const int MaximumMemorableWordLength = 8;
    public const char MemorablePasswordSeparator = '-';
}