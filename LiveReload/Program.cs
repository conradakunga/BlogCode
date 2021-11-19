using (var timer = new PeriodicTimer(TimeSpan.FromSeconds(5)))
{
    while (await timer.WaitForNextTickAsync())
    {
        WriteToConsole(DateTime.Now);
    }
}
void WriteToConsole(DateTime time)
{
    Console.WriteLine($"Still firing at {time}");
}