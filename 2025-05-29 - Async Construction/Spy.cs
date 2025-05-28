namespace v1
{
    public sealed class Spy
    {
        public string FirstName { get; }
        public string Surname { get; }

        public Spy(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
            //await PlaySong();
        }

        // Play theme song here
        public async Task PlaySong()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Playing that song!");
        }
    }
}

namespace v2
{
    public sealed class Spy
    {
        public string FirstName { get; }
        public string Surname { get; }

        private Spy(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        // Play theme song here
        public async Task PlaySong()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Playing that song!");
        }

        /// <summary>
        /// Factory method to return a spy
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        public static async Task<Spy> CreateSpy(string firstName, string surname)
        {
            // Call private constructor
            var spy = new Spy(firstName, surname);
            // Call async method
            await spy.PlaySong();
            return spy;
        }
    }
}