namespace v1
{
    public sealed class SpyProcessor
    {
        public void ProcessSpies(List<Spy> spies)
        {
            foreach (Spy spy in spies)
            {
                Console.WriteLine($"Processing {spy.FullName}...");
            }
        }
    }
}

namespace v2
{
    public sealed class SpyProcessor
    {
        public void ProcessSpies(IEnumerable<Spy> spies)
        {
            foreach (Spy spy in spies)
            {
                Console.WriteLine($"Processing {spy.FullName}...");
            }
        }
    }
}