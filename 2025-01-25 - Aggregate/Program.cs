int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

// var sum = numbers.Aggregate(0, (runningTotal, element) => runningTotal + element);
// Console.WriteLine(sum);

var sum = numbers.Aggregate(
    // Initialize the values we need for intermediate computation
    (runningTotal: 0M, elementCount: 0M),
    // As we advance, increment each of the intermediate values
    (intermediateComputation, element) =>
    (
        // Running total increases by the VALUE of each element
        runningTotal: intermediateComputation.runningTotal + element,
        // Element count increases by the COUNT of each element
        elementCount: intermediateComputation.elementCount += 1
    ),
    // Use our final values to compute the average
    result => result.elementCount > 0 ? result.runningTotal / result.elementCount : 0);
Console.WriteLine(sum);

Transaction[] transactions =
[
    new Transaction { Price = 100, Quantity = 1000 },
    new Transaction { Price = 95, Quantity = 800 },
    new Transaction { Price = 110, Quantity = 700 },
    new Transaction { Price = 105, Quantity = 900 },
    new Transaction { Price = 110, Quantity = 100 },
];

StockTransaction[] stockTransactions =
[
    new StockTransaction { Stock = "Apple", Price = 100, Quantity = 1000 },
    new StockTransaction { Stock = "Microsoft", Price = 95, Quantity = 800 },
    new StockTransaction { Stock = "Apple", Price = 110, Quantity = 700 },
    new StockTransaction { Stock = "Microsoft", Price = 105, Quantity = 900 },
    new StockTransaction { Stock = "Apple", Price = 110, Quantity = 100 },
];

var weightedPrice = transactions.Aggregate(
    // Initialize the values we need for intermediate computation
    (priceQuantityTotal: 0M, quantityTotal: 0M),
    // As we advance, increment each of the intermediate values
    (intermediateComputation, element) =>
    (
        // Running priceQuantityTotal increases by the product of price and quantity of each transaction
        priceQuantityTotal: intermediateComputation.priceQuantityTotal + element.Price * element.Quantity,
        // Running quantityTotal increases by the quantity of each transaction
        quantityTotal: intermediateComputation.quantityTotal + element.Quantity
    ),
    // Use our final values to compute the average
    result => result.quantityTotal > 0 ? result.priceQuantityTotal / result.quantityTotal : 0);

Console.WriteLine(weightedPrice);


var stockWeightedPrices = stockTransactions.AggregateBy(x =>
            // Partition our transactions by Stock
            x.Stock,
        // Initialize the values we need for intermediate computation
        (priceQuantityTotal: 0M, quantityTotal: 0M),
        // As we advance, increment each of the intermediate values
        (intermediateComputation, element) =>
        (
            // Running priceQuantityTotal increases by the product of price and quantity of each transaction
            priceQuantityTotal: intermediateComputation.priceQuantityTotal + element.Price * element.Quantity,
            // Running quantityTotal increases by the quantity of each transaction
            quantityTotal: intermediateComputation.quantityTotal + element.Quantity
        )).Select(x => new
    {
        Stock = x.Key,
        WeightedAveragePrice = x.Value.quantityTotal > 0 ? x.Value.priceQuantityTotal / x.Value.quantityTotal : 0
    })
    .ToArray();

foreach (var item in stockWeightedPrices)
    Console.WriteLine($"Weighted Average Price For {item.Stock} is {item.WeightedAveragePrice:#,0.0000}");