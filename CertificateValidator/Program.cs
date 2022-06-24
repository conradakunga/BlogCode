// create a variable for the domain
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

var domain = "innova.co.ke";
// create a variable for the port. This is usually 443
var port = 443;

// create a TCP client
using (var client = new TcpClient(hostname: domain, port: port))
{
    // Get a stream from the TcpClient
    using (var stream = new SslStream(innerStream: client.GetStream(), leaveInnerStreamOpen: true))
    {
        // authenticate the stream
        await stream.AuthenticateAsClientAsync(targetHost: domain);
        // retrieve the certificate
        var certificate = new X509Certificate2(certificate: stream.RemoteCertificate);
        // Get the main parameters
        var subject = certificate.Subject;
        var Issuer = certificate.Issuer;
    }
}