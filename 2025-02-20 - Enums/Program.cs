using V5;

var burger = new Burger
{
    Condiment = Condiments.None
};

Console.WriteLine(burger.Condiment);

if (!Enum.IsDefined(typeof(Condiments), 1000))
{
    Console.WriteLine("The value is invalid");
}

if (burger.Condiment.HasFlag(Condiments.TomatoSauce))
    Console.WriteLine("This burger has tomato sauce");
else
    Console.WriteLine("This burger does not have tomato sauce");

if (burger.Condiment.HasFlag(Condiments.Mayonnaise))
    Console.WriteLine("This burger has mayonnaise");
else
    Console.WriteLine("This burger does not have mayonnaise");

if (burger.Condiment.HasFlag(Condiments.BarbequeSauce))
    Console.WriteLine("This burger has barbeque sauce");
else
    Console.WriteLine("This burger does not have barbeque sauce");

if (burger.Condiment.HasFlag(Condiments.Ketchup))
    Console.WriteLine("This burger has ketchup");
else
    Console.WriteLine("This burger does not have ketchup");