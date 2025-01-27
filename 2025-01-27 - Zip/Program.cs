var numbers = Enumerable.Range(1, 10);
var powers = Enumerable.Range(1, 10);

var numbersWithPowers = numbers.Zip(powers, (number, power) =>
    number * power
).ToList();

numbersWithPowers.ForEach(Console.WriteLine);

string[] firstNames = ["James", "Jason", "Evelyn", "Roz", "Harry"];
string[] surnames = ["Bond", "Bourne", "Salt", "Myers", "Pearce"];

var products = firstNames.Zip(surnames, (firstName, surname) => $"{firstName} {surname}").ToList();

products.ForEach(Console.WriteLine);

string[] stocks = ["Microsoft", "Safaricom"];
int[] quantities = [1_000, 1_500, 800];
decimal[] prices = [100, 20, 75];

// Combine the stock and quantity into an anonymous type
var stockQuantities = stocks.Zip(quantities, (stock, quantity) => new { stock, quantity }).ToList();
// Combine the previous step with the prices into a second type
var stockValues = stockQuantities.Zip(prices,
    (stockQuantity, price) => new { Stock = stockQuantity.stock, Value = stockQuantity.quantity * price }).ToList();

// Output our results
stockValues.ForEach(item => Console.WriteLine($"The value of {item.Stock} is {item.Value:#,0.00}"));