{
    // Initialize a list
    List<string> namesList = new List<string>() { "Brenda", "Latisha", "Linda", "Felicia" };
    // Initialize an array
    string[] nameArray = new string[] { "Brenda", "Latisha", "Linda", "Felicia" };
    // Initialize a HashSet
    HashSet<string> nameHashSet = new HashSet<string> { "Brenda", "Latisha", "Linda", "Felicia" };
}
{
    // Initialize a list
    List<string> namesList = new() { "Brenda", "Latisha", "Linda", "Felicia" };
    // Initialize a HashSet
    HashSet<string> nameHashSet = new() { "Brenda", "Latisha", "Linda", "Felicia" };
}
{
    // Initialize a list
    List<string> namesList = ["Brenda", "Latisha", "Linda", "Felicia"];
    // Initialize an array
    string[] nameArray = ["Brenda", "Latisha", "Linda", "Felicia"];
    // Initialize a HashSet
    HashSet<string> nameHashSet = ["Brenda", "Latisha", "Linda", "Felicia"];
}

{
    List<string> namesList = [with(capacity: 4), "Brenda", "Latisha", "Linda", "Felicia"];
    namesList.ForEach(Console.WriteLine);
}
{
    string[] otherCollection = ["Brenda", "Latisha", "Linda", "Felicia"];
    List<string> namesList = [with(capacity: 4), .. otherCollection];
}