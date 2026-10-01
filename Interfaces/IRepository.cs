namespace LibraryApp.Interfaces;

/// <summary>
/// Обобщённый интерфейс хранилища сущностей.
/// </summary>
/// <typeparam name="T">Тип хранимой сущности.</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Добавляет сущность в хранилище.
    /// </summary>
    /// <param name="item">Добавляемая сущность.</param>
    void Add(T item);

    /// <summary>
    /// Возвращает сущность по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сущности.</param>
    /// <returns>Найденная сущность или <c>null</c>, если не найдена.</returns>
    T? GetById(int id);

    /// <summary>
    /// Возвращает все сущности из хранилища.
    /// </summary>
    /// <returns>Перечисление всех сущностей.</returns>
    IEnumerable<T> GetAll();

    /// <summary>
    /// Обновляет существующую сущность в хранилище.
    /// </summary>
    /// <param name="item">Сущность с обновлёнными данными.</param>
    void Update(T item);
}