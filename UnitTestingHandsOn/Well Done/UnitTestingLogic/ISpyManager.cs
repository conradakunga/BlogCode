namespace UnitTestingLogic;

public interface ISpyManager
{
    public Guid Add(CreateSpyRequest request);
    public void Edit(Guid spyID, UpdateSpyRequest request);
    public void Delete(Guid spyID);
    public Spy? Get(Guid spyID);
    public List<Spy> List();
    public List<Spy> Search(string search);
    public List<Spy> GenerateRandom(int number);
}