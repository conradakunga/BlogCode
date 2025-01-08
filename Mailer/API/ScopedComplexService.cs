namespace API;

public class ScopedComplexService
{
    private readonly ScopedNumberGenerator _numberGenerator;
    public int Number => _numberGenerator.Number;

    public ScopedComplexService(ScopedNumberGenerator numberGenerator)
    {
        _numberGenerator = numberGenerator;
    }
}