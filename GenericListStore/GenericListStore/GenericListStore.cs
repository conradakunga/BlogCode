namespace GenericListStore;

public class GenericListStore
{
    private readonly Dictionary<string, object> _dictLists;

    /// <summary>
    /// Lists held
    /// </summary>
    public int Count => _dictLists.Count;

    public GenericListStore()
    {
        _dictLists = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    }

    public void Add<T>(string name, List<T> list)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(list));

        if (!_dictLists.TryAdd(name, list))
            throw new ArgumentException($"A list with the name '{name}' already exists.", nameof(name));
    }

    // Get the list with the correct type
    public List<T> Get<T>(string name)
    {
        if (!_dictLists.TryGetValue(name, out var list))
            throw new KeyNotFoundException($"No list found with the name '{name}'.");

        if (list is List<T> typedList)
            return typedList;

        throw new InvalidCastException($"List '{name}' does not store {typeof(T).Name} items");
    }
}