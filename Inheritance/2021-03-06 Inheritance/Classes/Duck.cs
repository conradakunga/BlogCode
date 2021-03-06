namespace Inheritance
{
    public class Duck : WingedAnimal
    {
        public override string MakeSound() => "Quack";
        public Duck() => (Legs, HasFeathers) = (2, true);
    }
}