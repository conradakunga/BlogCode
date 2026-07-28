using System.Security.Cryptography;

{
    using (var alice = ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256))
    {
        using (var bob = ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256))
        {
            // Get alice's secret in a byte array
            var aliceSecret = alice.DeriveKeyMaterial(bob.PublicKey);
            // Get bob's secret in a byte array
            var bobSecret = bob.DeriveKeyMaterial(alice.PublicKey);

            // verify the secrets match
            var match = CryptographicOperations.FixedTimeEquals(aliceSecret, bobSecret);
            Console.WriteLine(match);
        }
    }
}
// .NET 11
{
    // Generate key pairs for alice
    using (var alice = X25519DiffieHellman.GenerateKey())
    {
        // Generate key pairs for bob
        using (var bob = X25519DiffieHellman.GenerateKey())
        {
            // get alice's secret with bob's key
            byte[] aliceShared = alice.DeriveRawSecretAgreement(bob);
            // get boob's secret with alice's key
            byte[] bobShared = bob.DeriveRawSecretAgreement(alice);
            // Check if they are equal
            Console.WriteLine(CryptographicOperations.FixedTimeEquals(aliceShared, bobShared));
        }
    }
}
{
    // Generate key pairs for alice
    using var alice = X25519DiffieHellman.GenerateKey();
    // Generate key pairs for bob
    using var bob = X25519DiffieHellman.GenerateKey();
    // get alice's secret with bob's key
    byte[] aliceShared = alice.DeriveRawSecretAgreement(bob);
    // get boob's secret with alice's key
    byte[] bobShared = bob.DeriveRawSecretAgreement(alice);
    // Check if they are equal
    Console.WriteLine(CryptographicOperations.FixedTimeEquals(aliceShared, bobShared));
}