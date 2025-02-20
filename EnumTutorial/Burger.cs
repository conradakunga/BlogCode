namespace V1
{
    public class Burger
    {
        public bool TomatoSauce { get; set; }
        public bool Mayonnaise { get; set; }
        public bool BarbecueSauce { get; set; }
        public bool Ketchup { get; set; }
    }
}

namespace V2
{
    public class Burger
    {
        public int Condiment { get; set; }
    }

    public static class CondimentCodes
    {
        public const int TomatoSauce = 1;
        public const int Mayonnaise = 2;
        public const int BarbecueSauce = 3;
        public const int Ketchup = 4;
    }
}

namespace V3
{
    public class Burger
    {
        public string Condiment { get; set; } = "";
    }

    public static class CondimentCodes
    {
        public const string TomatoSauce = nameof(TomatoSauce);
        public const string Mayonnaise = nameof(Mayonnaise);
        public const string BarbecueSauce = nameof(BarbecueSauce);
        public const string Ketchup = nameof(Ketchup);
    }
}

namespace V4
{
    public enum Condiments
    {
        TomatoSauce = 1000,
        Mayonnaise = 1001,
        BarbequeSauce = 1002,
        Ketchup = 1003,
    }

    public class Burger
    {
        public Condiments Condiment { get; set; }
    }
}

namespace V5
{
    [Flags]
    public enum Condiments
    {
        None = 0,
        TomatoSauce = 1,
        Mayonnaise = 2,
        BarbequeSauce = 4,
        Ketchup = 8,
        EggCondiments = Mayonnaise | BarbequeSauce,
        TomatoCondiments = TomatoSauce | Ketchup,
        Everything = EggCondiments | TomatoCondiments
    }

    public class Burger
    {
        public Condiments Condiment { get; set; }
    }
}