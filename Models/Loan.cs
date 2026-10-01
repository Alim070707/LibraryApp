namespace LibraryApp.Models;

/// <summary>
/// Модель записи о выдаче книги читателю.
/// </summary>
public class Loan
{
    /// <summary>
    /// Уникальный идентификатор записи о выдаче.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор выданной книги.
    /// </summary>
    public int BookId { get; set; }

    /// <summary>
    /// Идентификатор читателя, взявшего книгу.
    /// </summary>
    public int ReaderId { get; set; }

    /// <summary>
    /// Дата выдачи книги.
    /// </summary>
    public DateTime BorrowedAt { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Loan"/>.
    /// </summary>
    /// <param name="id">Идентификатор записи.</param>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="readerId">Идентификатор читателя.</param>
    public Loan(int id, int bookId, int readerId)
    {
        Id = id;
        BookId = bookId;
        ReaderId = readerId;
        BorrowedAt = DateTime.Now;
    }

    /// <summary>
    /// Возвращает строковое представление записи о выдаче.
    /// </summary>
    /// <returns>Строка вида "Loan #Id: Book BookId → Reader ReaderId (дата)".</returns>
    public override string ToString()
        => $"Выдача #{Id}: книга {BookId} → читатель {ReaderId} ({BorrowedAt:dd.MM.yyyy HH:mm})";
}