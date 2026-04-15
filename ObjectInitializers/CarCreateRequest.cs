using System.Security.Cryptography.X509Certificates;

namespace V1
{
    public sealed record CarCreateRequest(
        string make,
        string model,
        int year,
        string market,
        bool leftHandDrive,
        int engineCapacity);
}

namespace V2
{
    public sealed record CarCreateRequest
    {
        public required string Make { get; set; }
        public required string Model { get; set; }
        public required int Year { get; set; }
        public required string Market { get; set; }
        public required bool LeftHandDrive { get; set; }
        public required int EngineCapacity { get; set; }
    }
}