// Create a processor

using OrderProcessor.v2;

var proc = new OrderProcessor.v1.OrderProcessor();
// Compute and return the price
var amount = proc.ComputePrice(gross: true);

Console.WriteLine(amount);

var proc2 = new OrderProcessor.v2.OrderProcessor();
// Compute and return the price
amount = proc2.ComputePrice(PriceMode.Gross);

Console.WriteLine(amount);