using System.Text;

try
{
    throw new Exception("This is the level 1",
        new Exception("This is the level 2", new Exception("This is the level 3")));
}
catch (Exception ex)
{
    // Console.WriteLine(ex.Message);
    StringBuilder sb = new();
    Console.WriteLine(GetMessage(ex, sb));
}

try
{
    throw new Exception("This is the level 1",
        new Exception("This is the level 2", new Exception("This is the level 3")));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

return;

string GetMessage(Exception ex, StringBuilder sb)
{
    sb.AppendLine(ex.Message);
    if (ex.InnerException is not null)
    {
        GetMessage(ex.InnerException, sb);
    }

    return sb.ToString();
}