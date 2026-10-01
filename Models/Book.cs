namespace LibraryApp.Models;

/// <summary>
/// Модель книги в библиотеке.
/// </summary>
public class Book
{
    /// <summary>
    /// Уникальный идентификатор книги.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название книги.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Автор книги.
    /// </summary>
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Признак того, что книга выдана читателю.
    /// </summary>
    public bool IsBorrowed { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Book"/>.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <param name="title">Название книги.</param>
    /// <param name="author">Автор книги.</param>
    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
        IsBorrowed = false;
    }

    /// <summary>
    /// Возвращает строковое представление книги.
    /// </summary>
    /// <returns>Строка вида "Id: Title — Author (выдана/доступна)".</returns>
    public override string ToString()
        => $"[{Id}] {Title} — {Author} ({(IsBorrowed ? "выдана" : "доступна")})";
}