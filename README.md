# LibraryApp

Учебный проект — консольное приложение «Библиотека» на C# / .NET 10.

## Описание

Приложение позволяет:
- хранить список книг и читателей;
- выдавать книги читателям;
- просматривать историю выдач.

## Архитектура

- **Models** — модели данных (`Book`, `Reader`, `Loan`).
- **Interfaces** — контракты (`IRepository<T>`, `ILibraryService`).
- **Repositories** — реализация хранилища в памяти (`InMemoryRepository<T>`).
- **Services** — бизнес-логика (`LibraryService`).
- **UI** — консольный интерфейс (`ConsoleUI`).

## Запуск

```bash
dotnet run
```

## Документация

- [Диаграмма классов](docs/class-diagram.md)
- [Диаграмма последовательности](docs/sequence-diagram.md)

## XML-документация

В `.csproj` включена генерация XML-файла документации (`GenerateDocumentationFile=true`).
Все публичные члены снабжены XML-комментариями (`///`), которые отображаются в IntelliSense.