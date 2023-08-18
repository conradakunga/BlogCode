
[AttributeUsage(AttributeTargets.Field)]
public class MakeOfAttribute : Attribute
{
    public Make Make { get; }
    public MakeOfAttribute(Make make)
    {
        Make = make;
    }
}