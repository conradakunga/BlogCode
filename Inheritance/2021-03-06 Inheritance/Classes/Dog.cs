namespace Inheritance
{
    public class Dog : LeggedAnimal
    {
        public override string MakeSound() => "Woof";
        public Dog() => Legs = 4;
    }
}