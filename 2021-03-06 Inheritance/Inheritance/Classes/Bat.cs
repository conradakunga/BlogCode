namespace Inheritance
{
    public class Bat : WingedAnimal
    {
        public override string MakeSound() => "Squeak";
        public Bat() => (Legs, HasFeathers) = (2, false);

    }
}
