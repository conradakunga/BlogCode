namespace GenericListStore;

public sealed class GenericListStore
{
    private readonly Dictionary<string, object> _dictLists;

    /// <summary>
    /// Lists held
    /// </summary>
    public int Count => _dictLists.Count;

    /// <summary>
    /// Constructs a new GenericListStore
    /// </summary>
    public GenericListStore()
    {
        // We want the name to be case-insensitive
        _dictLists = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Add a list to the collection
    /// </summary>
    /// <param name="name"></param>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentException"></exception>
    public void Add<T>(string name, List<T> list)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nameof(list));

        if (!_dictLists.TryAdd(name, list))
            throw new ArgumentException($"A list with the name '{name}' already exists.", nameof(name));
    }

    /// <summary>
    /// Get the list with the correct type
    /// </summary>
    /// <param name="name"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    /// <exception cref="InvalidCastException"></exception>
    public List<T> Get<T>(string name)
    {
        if (!_dictLists.TryGetValue(name, out var list))
            throw new KeyNotFoundException($"No list found with the name '{name}'.");

        if (list is List<T> typedList)
            return typedList;

        throw new InvalidCastException($"List '{name}' does not store {typeof(T).Name} items");
    }

    /// <summary>
    /// Remove a list from the store
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    public void Remove(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }

        // Check if the key exists
        if (!_dictLists.ContainsKey(name))
            throw new KeyNotFoundException($"No list found with the name '{name}'.");

        _dictLists.Remove(name);
    }
}