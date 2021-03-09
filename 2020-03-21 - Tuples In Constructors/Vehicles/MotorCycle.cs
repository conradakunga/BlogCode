namespace Vehicles
{
    public class MotorCycle
    {
        public string Make { get; }
        public string Model { get; }
        public int CC { get; }
        public string Serial { get; }
        public MotorCycle(string make, string model, string serial, int cc)
        {
            Make = make;
            Model = model;
            Serial = serial;
            CC = cc;
        }
        public (string Make, string Model) GetMakeAndModel() => (Make, Model);
    }
}