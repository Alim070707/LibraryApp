namespace LibraryApp.Models;

/// <summary>
/// Модель читателя библиотеки.
/// </summary>
public class Reader
{
    /// <summary>
    /// Уникальный идентификатор читателя.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Полное имя читателя.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Reader"/>.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <param name="fullName">Полное имя.</param>
    public Reader(int id, string fullName)
    {
        Id = id;
        FullName = fullName;
    }

    /// <summary>
    /// Возвращает строковое представление читателя.
    /// </summary>
    /// <returns>Строка вида "Id: FullName".</returns>
    public override string ToString() => $"[{Id}] {FullName}";
}