{
    // Create a cancellation token source
    var cts = new CancellationTokenSource();
    // Create a timer that fires every 5 seconds
    using (var timer = new PeriodicTimer(TimeSpan.FromSeconds(5)))
    {
        // Create a counter to simulate logic
        var counter = 0;
        // Wire it to fire an event after the specified period
        while (await timer.WaitForNextTickAsync(cts.Token))
        {
            // Cancel when the counter gets to 5
            if (counter == 5)
                cts.Cancel();
            Console.WriteLine($"Running logic at {DateTime.Now}");
            counter++;
        }
    }
}

{
    // Create a cancellation token source that cancels after 20 seconds
    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    // Create a timer that fires every 5 seconds
    using (var timer = new PeriodicTimer(TimeSpan.FromSeconds(5)))
    {
        // Wire it to fire an event after the specified period
        while (await timer.WaitForNextTickAsync(cts.Token))
        {
            Console.WriteLine($"Firing Cancellable timer at {DateTime.Now}");
        }
    }
}

{
    // Create a cancellation token source
    var cts = new CancellationTokenSource();
    // Create a timer that fires every 5 seconds
    using (var timer = new PeriodicTimer(TimeSpan.FromSeconds(5)))
    {
        // Create a counter to simulate logic
        var counter = 0;
        // Wire it to fire an event after the specified period
        while (await timer.WaitForNextTickAsync(cts.Token))
        {
            // Cancel when the counter gets to 5
            if (counter == 5)
                cts.Cancel();
            Console.WriteLine($"Running logic at {DateTime.Now}");
            counter++;
        }
    }
}