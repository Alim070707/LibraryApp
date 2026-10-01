using LibraryApp.Interfaces;
using LibraryApp.Models;

namespace LibraryApp.UI;

/// <summary>
/// Консольный интерфейс для работы с библиотекой.
/// </summary>
public class ConsoleUI
{
    private readonly ILibraryService _service;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ConsoleUI"/>.
    /// </summary>
    /// <param name="service">Сервис библиотеки.</param>
    public ConsoleUI(ILibraryService service)
    {
        _service = service;
    }

    /// <summary>
    /// Запускает главный цикл приложения.
    /// </summary>
    public void Run()
    {
        Seed();

        while (true)
        {
            PrintMenu();
            var choice = Console.ReadLine();
            Console.WriteLine();

            try
            {
                switch (choice)
                {
                    case "1": ListBooks(); break;
                    case "2": BorrowBookFlow(); break;
                    case "3": ListLoans(); break;
                    case "0": return;
                    default: Console.WriteLine("Неизвестная команда."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine();
        }
    }

    private static void PrintMenu()
    {
        Console.WriteLine("=== Библиотека ===");
        Console.WriteLine("1 — список книг");
        Console.WriteLine("2 — выдать книгу");
        Console.WriteLine("3 — список выдач");
        Console.WriteLine("0 — выход");
        Console.Write("Выбор: ");
    }

    private void ListBooks()
    {
        foreach (var book in _service.GetAllBooks())
            Console.WriteLine(book);
    }

    private void BorrowBookFlow()
    {
        Console.Write("Id книги: ");
        var bookId = int.Parse(Console.ReadLine()!);

        Console.Write("Id читателя: ");
        var readerId = int.Parse(Console.ReadLine()!);

        var loan = _service.BorrowBook(bookId, readerId);
        Console.WriteLine($"Успешно: {loan}");
    }

    private void ListLoans()
    {
        foreach (var loan in _service.GetAllLoans())
            Console.WriteLine(loan);
    }

    private void Seed()
    {
        _service.AddBook("Война и мир", "Л. Н. Толстой");
        _service.AddBook("Преступление и наказание", "Ф. М. Достоевский");
        _service.AddReader("Иванов Иван");
        _service.AddReader("Петрова Анна");
    }
}