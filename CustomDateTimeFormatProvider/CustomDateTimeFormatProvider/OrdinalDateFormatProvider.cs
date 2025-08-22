namespace CustomDateTimeFormatProvider;

using System;
using System.Globalization;

public class OrdinalDateFormatProvider : IFormatProvider, ICustomFormatter
{
    private readonly IFormatProvider _baseProvider;

    public OrdinalDateFormatProvider() : this(CultureInfo.CurrentCulture)
    {
    }

    public OrdinalDateFormatProvider(IFormatProvider baseProvider)
    {
        _baseProvider = baseProvider;
    }

    public object GetFormat(Type? formatType)
    {
        ArgumentNullException.ThrowIfNull(formatType);

        if (formatType == typeof(ICustomFormatter)) return this;

        return _baseProvider.GetFormat(formatType)!;
    }

    public string Format(string? format, object? arg, IFormatProvider? formatProvider)
    {
        return arg switch
        {
            DateTime dt => FormatDate(dt, format),
            DateOnly dOnly => FormatDate(dOnly, format),
            _ => arg is IFormattable f ? f.ToString(format, _baseProvider) : arg?.ToString() ?? string.Empty
        };
    }

    private string FormatDate<T>(T date, string? format) where T : IFormattable
    {
        format ??= "G";

        if (format.Contains('o'))
        {
            int day = date switch
            {
                DateTime dt => dt.Day,
                DateOnly dOnly => dOnly.Day,
                _ => throw new InvalidOperationException()
            };

            var daySuffix = day.GetDaySuffix();
            var innerFormat = format.Replace("o", $"'{daySuffix}'");
            return date.ToString(innerFormat, _baseProvider);
        }

        return date.ToString(format, _baseProvider);
    }
}