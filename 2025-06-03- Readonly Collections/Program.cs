var spy = new Spy { FirstName = "James", Surname = "Bond" };

spy.AddAgency("MI-5");
spy.AddAgency("MI-6");

Console.WriteLine($"{spy.FirstName} {spy.Surname} is in  {spy.Agencies.Count()}");