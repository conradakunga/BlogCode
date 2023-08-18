using System.Reflection;

public class Vehicle
{
    readonly Model _model;
    private Make _Make
    {
        get
        {
            return _model.GetType() // Retrieve the type
                        .GetMember(_model.ToString()) //Get the member info for the passed field (Camry)
                        .First() // Retrieve the first item
                        .GetCustomAttribute<MakeOfAttribute>()! // Get the attribute specified
                        .Make; // Get the make and return it
        }
    }

    public Model Model => _model;
    public Make Make => _Make;

    public Vehicle(Model model)
    {
        _model = model;
    }
}
