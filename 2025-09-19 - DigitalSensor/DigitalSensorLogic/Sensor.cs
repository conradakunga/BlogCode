namespace V1
{
    public class Sensor
    {
        public int Display { get; }

        public Sensor(int input)
        {
            Display = input;
        }
    }
}

namespace V2
{
    public class Sensor
    {
        public int Display { get; }

        public Sensor(int input)
        {
            if (input < 0)
                Display = 0;
            else if (input > 10)
                Display = 10;
            else
                Display = input;
        }
    }
}

namespace V3
{
    public class Sensor
    {
        public int Display { get; }

        public Sensor(int input)
        {
            Display = input switch
            {
                < 0 => 0,
                > 10 => 10,
                _ => input
            };
        }
    }
}

namespace V4
{
    public class Sensor
    {
        public int Display { get; }

        public Sensor(int input)
        {
            Display = Math.Clamp(input, 0, 10);
        }
    }
}