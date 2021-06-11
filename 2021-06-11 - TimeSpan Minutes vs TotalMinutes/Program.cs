using System;
using Serilog;

namespace TimeSpanExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new LoggerConfiguration();
            config.WriteTo.Console();
            Log.Logger = config.CreateLogger();

            var start = new TimeSpan(10, 0, 0);

            var firstEnd = new TimeSpan(10, 30, 0);

            Log.Information("Minutes: {minutes}", (firstEnd - start).Minutes);
            Log.Information("Total Minutes: {minutes}", (firstEnd - start).TotalMinutes);

            var secondEnd = new TimeSpan(11, 1, 0);

            Log.Information("Minutes: {minutes}", (secondEnd - start).Minutes);
            Log.Information("Total Minutes: {minutes}", (secondEnd - start).TotalMinutes);

            var thirdEnd = new TimeSpan(0, 12, 0, 30, 0);
            Log.Information("Minutes: {minutes}", (thirdEnd - start).Minutes);
            Log.Information("Total Minutes: {minutes}", (thirdEnd - start).TotalMinutes);

            var fourthEnd = new TimeSpan(0, 12, 0, 30, 50);
            var result = (fourthEnd - start);
            Log.Information("Minutes: {minutes}", result.Minutes);
            Log.Information("Total Minutes: {minutes}", result.TotalMinutes);
            Log.Information("Total Seconds: {minutes}", result.Seconds);
            Log.Information("Total MilliSeconds: {minutes}", result.Milliseconds);

           
        }
    }
}
