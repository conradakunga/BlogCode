using System.Net;
using System.Net.Sockets;

Console.WriteLine($"TCPListener free port: {TcpListenerGetFreePort()}");
Console.WriteLine($"Socket free port: {SocketGetFreePort()}");
return;

int TcpListenerGetFreePort()
{
    using var listener = new TcpListener(IPAddress.Loopback, 0);
    listener.Start();
    return ((IPEndPoint)listener.LocalEndpoint).Port;
}

int SocketGetFreePort()
{
    using (var s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
    {
        s.Bind(new IPEndPoint(IPAddress.Loopback, 0));
        return ((IPEndPoint)s.LocalEndPoint!).Port;
    }
}