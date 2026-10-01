using LibraryApp.Interfaces;
using LibraryApp.Models;
using LibraryApp.Repositories;
using LibraryApp.Services;
using LibraryApp.UI;

IRepository<Book> bookRepo = new InMemoryRepository<Book>();
IRepository<Reader> readerRepo = new InMemoryRepository<Reader>();
IRepository<Loan> loanRepo = new InMemoryRepository<Loan>();

ILibraryService service = new LibraryService(bookRepo, readerRepo, loanRepo);
var ui = new ConsoleUI(service);
ui.Run();