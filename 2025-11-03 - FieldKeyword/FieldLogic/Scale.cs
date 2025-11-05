using System.Diagnostics.Contracts;


namespace FieldLogic.V1
{
    public sealed class Scale
    {
        public required int Temperature { get; init; }
    }
}

namespace FieldLogic.V2
{
    public sealed class Scale
    {
        private int _temperature;

        public int Temperature
        {
            get => _temperature;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        $"{value} is an invalid temperature. Must be greater than 0");
                _temperature = value;
            }
        }
    }
}

namespace FieldLogic.V3
{
    public sealed class Scale
    {
        public int Temperature
        {
            get;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        $"{value} is an invalid temperature. Must be greater than 0");
                field = value;
            }
        }
    }
}