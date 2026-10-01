using LibraryApp.Interfaces;
using LibraryApp.Models;

namespace LibraryApp.Services;

/// <summary>
/// Сервис управления библиотекой: книги, читатели, выдачи.
/// </summary>
public class LibraryService : ILibraryService
{
    private readonly IRepository<Book> _books;
    private readonly IRepository<Reader> _readers;
    private readonly IRepository<Loan> _loans;

    private int _bookCounter = 1;
    private int _readerCounter = 1;
    private int _loanCounter = 1;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="LibraryService"/>.
    /// </summary>
    /// <param name="books">Хранилище книг.</param>
    /// <param name="readers">Хранилище читателей.</param>
    /// <param name="loans">Хранилище записей о выдачах.</param>
    public LibraryService(
        IRepository<Book> books,
        IRepository<Reader> readers,
        IRepository<Loan> loans)
    {
        _books = books;
        _readers = readers;
        _loans = loans;
    }

    /// <inheritdoc />
    public Book AddBook(string title, string author)
    {
        var book = new Book(_bookCounter++, title, author);
        _books.Add(book);
        return book;
    }

    /// <inheritdoc />
    public Reader AddReader(string fullName)
    {
        var reader = new Reader(_readerCounter++, fullName);
        _readers.Add(reader);
        return reader;
    }

    /// <inheritdoc />
    public Loan BorrowBook(int bookId, int readerId)
    {
        var book = _books.GetById(bookId)
            ?? throw new InvalidOperationException($"Книга с Id={bookId} не найдена.");

        var reader = _readers.GetById(readerId)
            ?? throw new InvalidOperationException($"Читатель с Id={readerId} не найден.");

        if (book.IsBorrowed)
            throw new InvalidOperationException($"Книга \"{book.Title}\" уже выдана.");

        book.IsBorrowed = true;
        _books.Update(book);

        var loan = new Loan(_loanCounter++, bookId, readerId);
        _loans.Add(loan);

        return loan;
    }

    /// <inheritdoc />
    public IEnumerable<Book> GetAllBooks() => _books.GetAll();

    /// <inheritdoc />
    public IEnumerable<Loan> GetAllLoans() => _loans.GetAll();
}