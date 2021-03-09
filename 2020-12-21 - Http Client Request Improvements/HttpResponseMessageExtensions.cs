using System.Net.Http;

namespace HttpClientRequest
{
    public static class HttpResponseMessageExtensions
    {
        public static bool IsRedirect(this HttpResponseMessage message)
        {
            return (int)message.StatusCode >= 300 && (int)message.StatusCode <= 399;
        }
    }
}