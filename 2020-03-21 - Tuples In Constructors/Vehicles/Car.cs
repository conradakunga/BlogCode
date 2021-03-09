namespace Vehicles
{
    public class Car
    {
        public string Make { get; }
        public string Model { get; }
        public int CC { get; }
        public string Serial { get; }

        public Car(string make, string model, string serial, int cc)
            => (Make, Model, CC, Serial) = (make, model, cc, serial);
    }
}