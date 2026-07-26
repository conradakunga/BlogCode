void Main()
{
    Product[] products =
    [
        new Product { ProductID = 1, Name = "Mango" },
        new Product { ProductID = 2, Name = "Banana" },
        new Product { ProductID = 3, Name = "Potato" },
        new Product { ProductID = 4, Name = "Cabbage" },
    ];

    Order[] orders =
    [
        new Order { OrderID = 1, ProductID = 1, Quantity = 10 },
        new Order { OrderID = 1, ProductID = 2, Quantity = 13 },
        new Order { OrderID = 2, ProductID = 3, Quantity = 5 },
        new Order { OrderID = 2, ProductID = 4, Quantity = 8 },
    ];

    var result = products.Join(orders,
        product => product.ProductID,
        order => order.ProductID,
        (product, order) => (product, order));

    foreach (var (product, order) in result)
    {
        Console.WriteLine($"Product: {product.Name}, Quantity: {order.Quantity}");
    }

    var newResult = products.Join(orders,
        product => product.ProductID,
        order => order.ProductID);

    foreach (var (product, order) in newResult)
    {
        Console.WriteLine($"Product: {product.Name}, Quantity: {order.Quantity}");
    }
}