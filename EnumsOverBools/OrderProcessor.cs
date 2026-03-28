namespace OrderProcessor.v1
{
    public class OrderProcessor
    {
        public decimal ComputePrice(bool gross)
        {
            if (gross)
                return 100;
            return 84;
        }
    }
}

namespace OrderProcessor.v2
{
    public enum PriceMode
    {
        Gross,
        Net
    }

    public class OrderProcessor
    {
        public decimal ComputePrice(PriceMode mode)
        {
            switch (mode)
            {
                case PriceMode.Net:
                    return 84;
                default:
                    return 100;
            }
        }
    }
}