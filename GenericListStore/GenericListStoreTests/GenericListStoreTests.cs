using AwesomeAssertions;

namespace GenericListStoreTests;

using GenericListStore;

public class GenericListStoreTests
{
    [Fact]
    public void Store_Should_Initialize_Empty()
    {
        var store = new GenericListStore();
        store.Count.Should().Be(0);
    }

    [Fact]
    public void Store_Should_Store_Items_Correctly()
    {
        List<string> items = ["one", "two", "three"];
        var store = new GenericListStore();
        store.Add("strings", items);
        // Fetch items
        var returned = store.Get<string>("strings");
        returned.Should().BeEquivalentTo(items);
    }

    [Fact]
    public void Store_Should_Store_Multiple_Type_Items_Correctly()
    {
        List<string> stringItems = ["one", "two", "three"];
        List<int> intItems = [1, 2, 3, 4];

        var store = new GenericListStore();

        const string stringKey = "strings";
        const string intKey = "ints";

        store.Add(stringKey, stringItems);
        store.Add(intKey, intItems);

        // Fetch items
        var returnedStrings = store.Get<string>(stringKey);
        var returnedInts = store.Get<int>(intKey);
        returnedStrings.Should().BeEquivalentTo(stringItems);
        returnedInts.Should().BeEquivalentTo(intItems);
    }

    [Fact]
    public void Store_Should_Reject_Duplicate_Name()
    {
        List<string> first = ["one", "two", "three"];
        List<string> second = ["four", "five", "six"];

        var store = new GenericListStore();
        store.Add("strings", first);
        var ex = Record.Exception(() => store.Add("strings", second));
        ex.Should().BeOfType<ArgumentException>();
    }

    [Fact]
    public void Store_Should_Throw_Exception_On_Invalid_Cast()
    {
        List<string> first = ["one", "two", "three"];

        var store = new GenericListStore();
        store.Add("strings", first);

        var ex = Record.Exception(() => store.Get<int>("strings"));
        ex.Should().BeOfType<InvalidCastException>();
    }

    [Fact]
    public void Store_Should_Throw_Exception_For_Invalid_Name()
    {
        List<string> first = ["one", "two", "three"];

        var store = new GenericListStore();
        store.Add("strings", first);

        var ex = Record.Exception(() => store.Get<int>("DOESNOTEXIST"));
        ex.Should().BeOfType<KeyNotFoundException>();
    }
}