using System.Net;

var result = await Dns.ResolveSrvAsync("_imaps._tcp.gmail.com");

if (result.ResponseCode == DnsResponseCode.NoError)
{
    if (result.Records.Count == 0)
    {
        Console.WriteLine("No SRV records found.");
    }
    else
    {
        foreach (var record in result.Records)
        {
            Console.WriteLine($"{record.Target}:{record.Port} Priority={record.Priority} Weight={record.Weight}");
        }
    }
}