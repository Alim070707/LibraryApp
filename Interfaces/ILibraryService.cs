using LibraryApp.Models;

namespace LibraryApp.Interfaces;

/// <summary>
/// Интерфейс сервиса управления библиотекой.
/// </summary>
public interface ILibraryService
{
    /// <summary>
    /// Регистрирует новую книгу в библиотеке.
    /// </summary>
    /// <param name="title">Название книги.</param>
    /// <param name="author">Автор книги.</param>
    /// <returns>Созданная книга.</returns>
    Book AddBook(string title, string author);

    /// <summary>
    /// Регистрирует нового читателя.
    /// </summary>
    /// <param name="fullName">Полное имя читателя.</param>
    /// <returns>Созданный читатель.</returns>
    Reader AddReader(string fullName);

    /// <summary>
    /// Выдаёт книгу читателю.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="readerId">Идентификатор читателя.</param>
    /// <returns>Созданная запись о выдаче.</returns>
    /// <exception cref="InvalidOperationException">
    /// Книга или читатель не найдены, либо книга уже выдана.
    /// </exception>
    Loan BorrowBook(int bookId, int readerId);

    /// <summary>
    /// Возвращает список всех книг.
    /// </summary>
    /// <returns>Перечисление книг.</returns>
    IEnumerable<Book> GetAllBooks();

    /// <summary>
    /// Возвращает список всех записей о выдачах.
    /// </summary>
    /// <returns>Перечисление записей о выдачах.</returns>
    IEnumerable<Loan> GetAllLoans();
}