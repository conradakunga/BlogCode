using EasyNetQ;

namespace Logic;

[Queue("ActiveSpies")]
public sealed class Spy
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
}