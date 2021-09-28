var numbers = Enumerable.Range(1, 15);

var oldLastFive = numbers.TakeLast(5);
var newLastFive = numbers.Take(^5..);

Print(oldLastFive);
Print(newLastFive);

var oldTakeFiveSkipTwo = numbers.Take(5).Skip(2);
var newTakeFiveSkipTwo = numbers.Take(2..5);

Print(oldTakeFiveSkipTwo);
Print(newTakeFiveSkipTwo);

var oldTakeTwoSkipFive = numbers.Take(2).Skip(5);
var newTakeTwoSkipFive = numbers.Take(2..5);

Print(oldTakeTwoSkipFive);
Print(newTakeTwoSkipFive);


var oldSkipFive = numbers.Skip(5);
var newSkipFive = numbers.Take(5..);

Print(oldSkipFive);
Print(newSkipFive);

var oldSkipLastFive = numbers.SkipLast(5);
var newSkipLastFive = numbers.Take(..^5);

Print(oldSkipLastFive);
Print(newSkipLastFive);

var oldLastTenSkipLast5 = numbers.TakeLast(10).SkipLast(5);
var newLastTenSkipLast5 = numbers.Take(^10..^5);

Print(oldLastTenSkipLast5);
Print(newLastTenSkipLast5);

void Print(IEnumerable<int> numbers)
{
	Console.WriteLine(string.Join(",", numbers));
}