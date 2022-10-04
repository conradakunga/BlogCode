var snacks = new[] { "Strawberry Juice", "Banana Jam", "Peach Juice", "Banana Pie", "Strawberry Crumble", "Kiwi Yoghurt", "Apple Crumble", "Apple Pie", "Strawberry Jam", "Mango Yoghurt", "Apple Juice", "Peach Jam", "Peach Pie", "Mango Cake", "Kiwi Pie", "Banana Crumble", "Strawberry Cake", "Peach Cake", "Kiwi Crumble", "Peach Crumble", "Peach Yoghurt", "Kiwi Jam", "Apple Yoghurt", "Banana Cake", "Mango Pie", "Banana Yoghurt", "Apple Cake", "Banana Juice", "Kiwi Juice", "Mango Crumble", "Kiwi Cake", "Apple Jam", "Mango Jam", "Mango Juice", "Strawberry Pie", "Strawberry Yoghurt" };

// Filter snacks containing 'Jam'
var jams = snacks.Where(snack => snack.Contains("Jam"));

foreach (var jam in jams)
{
    Console.WriteLine(jam);
}

Console.WriteLine();

// Setup what we want to filter
var filter = new[] { "Banana", "Strawberry", "Kiwi" };

// Filter snacks meeting the criteria
var filteredSnacks = snacks.Where(snack => filter.Any(filterString => snack.Contains(filterString)));

foreach (var filteredSnack in filteredSnacks)
{
    Console.WriteLine(filteredSnack);
}