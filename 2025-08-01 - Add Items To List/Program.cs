{
    // Constructor initialization
    List<int> list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
}
{
    // Collection initialization
    List<int> list = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
}
{
    // Add single element
    List<int> list = [];
    list.Add(1);
    list.Add(2);
}
{
    // Add multiple elements
    List<int> list = [];
    list.AddRange([1, 2, 3, 4, 5, 6, 7, 8, 9]);
}
{
    // Add elements at particular position
    List<int> list = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    list.Insert(0, -1);
    list.ForEach(Console.Write);
    Console.WriteLine();
}
{
    // Add range of elements at particular position
    List<int> list = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    list.InsertRange(0, [-1, -2, -3, -4]);
    list.ForEach(Console.Write);
    Console.WriteLine();
}
{
    // Add range of elements at particular position
    List<int> list = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    var newList = list.Prepend(-1).ToList();
    newList.ForEach(Console.Write);
    Console.WriteLine();
}