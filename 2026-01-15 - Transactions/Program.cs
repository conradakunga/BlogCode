using Microsoft.Data.SqlClient;
using Serilog;
using TransactionWork.v1;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

//
// Original
//
{
    await using (var cn = new SqlConnection(
                     "Data Source=.;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=true"))
    {
        // Open the connection
        await cn.OpenAsync();
        // Create a transaction
        await using (var trans = await cn.BeginTransactionAsync())
        {
            // Create the processor
            var processor = new TransactionProcessor();
            // Do the first bit of work
            var firstResult = await processor.DoThisThing(cn, trans);
            // Do the next bit of work
            var secondResult = await processor.DoTheOtherThing(cn, trans);
            trans.Commit();
            Log.Information("Success!");
        }
    }
}
//
// Multliple connections
//
{
    var cn1 = new SqlConnection(
        "Data Source=.;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=true");
    await cn1.OpenAsync();

    var cn2 = new SqlConnection(
        "Data Source=.;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=true");
    await cn2.OpenAsync();

    var trans1 = await cn1.BeginTransactionAsync();
    var trans2 = await cn2.BeginTransactionAsync();
    // Create the processor
    var processor = new TransactionProcessor();
    // Do the first bit of work
    var firstResult = await processor.DoThisThing(cn1, trans1);
    // Do the next bit of work
    var secondResult = await processor.DoTheOtherThing(cn2, trans2);
    trans1.Commit();
    trans2.Commit();
    Log.Information("Success!");
}
//
// Final refactor
//
await using (var cn = new SqlConnection(
                 "Data Source=.;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=true"))
{
    // Open the connection
    await cn.OpenAsync();
    // Create a transaction
    await using (var trans = await cn.BeginTransactionAsync())
    {
        // Create the processor
        var processor = new TransactionWork.v2.TransactionProcessor();
        // Do the first bit of work
        var firstResult = await processor.DoThisThing(trans);
        // Do the next bit of work
        var secondResult = await processor.DoTheOtherThing(trans);
        trans.Commit();
        Log.Information("Success!");
    }
}