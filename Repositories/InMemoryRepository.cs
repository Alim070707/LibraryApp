using LibraryApp.Interfaces;

namespace LibraryApp.Repositories;

/// <summary>
/// Реализация хранилища сущностей в оперативной памяти.
/// </summary>
/// <typeparam name="T">Тип сущности. Должен иметь свойство <c>Id</c>.</typeparam>
public class InMemoryRepository<T> : IRepository<T> where T : class
{
    private readonly List<T> _items = new();

    /// <inheritdoc />
    public void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _items.Add(item);
    }

    /// <inheritdoc />
    public T? GetById(int id)
    {
        return _items.FirstOrDefault(x =>
            (int?)x.GetType().GetProperty("Id")?.GetValue(x) == id);
    }

    /// <inheritdoc />
    public IEnumerable<T> GetAll() => _items;

    /// <inheritdoc />
    public void Update(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        var existing = GetById((int)item.GetType().GetProperty("Id")!.GetValue(item)!);
        if (existing is null)
            throw new InvalidOperationException("Сущность не найдена в хранилище.");

        _items.Remove(existing);
        _items.Add(item);
    }
}