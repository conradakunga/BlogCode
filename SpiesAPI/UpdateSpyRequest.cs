namespace SpiesAPI;

public sealed record UpdateSpyRequest(Guid ID, string Name, DateOnly DateOfBirth);