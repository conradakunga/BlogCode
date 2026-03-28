using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var entry = new ComputeDontStore.v1.OrderEntry
{
    Name = "Chocolate Biscuits",
    Quantity = 10,
    Price = 125.40M,
    TaxRate = 0.16M,
    GrossAmount = 1_254.00M,
    Taxes = 200.64M,
    NetAmount = 1_053.36M
};

Log.Information("Entry of {Item} has gross value of {Gross:#,0.00}, taxes of {Taxes} and a Net Price of {Net:#,0.00}",
    entry.Name, entry.GrossAmount, entry.Taxes, entry.NetAmount);

var entry2 = new ComputeDontStore.v2.OrderEntry
{
    Name = "Chocolate Biscuits",
    Quantity = 10,
    Price = 125.40M,
    TaxRate = 0.16M
};

Log.Information("Entry of {Item} has gross value of {Gross:#,0.00}, taxes of {Taxes} and a Net Price of {Net:#,0.00}",
    entry.Name, entry.GrossAmount, entry.Taxes, entry.NetAmount);