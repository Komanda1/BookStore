# Bookstore

---

## Содержание

- [Общее устройство](#общее-устройство)
- [Установка и запуск](#установка-и-запуск)
- [Быстрый старт](#быстрый-старт)
- [Модель предметной области](#модель-предметной-области)
  - [Library](#library)
  - [Book](#book)
  - [BookCase](#bookcase)
  - [BookStore](#bookstore-класс)
- [Типичные сценарии](#типичные-сценарии)
  - [Создание книг](#создание-книг)
  - [Работа со шкафами](#работа-со-шкафами)
  - [Работа с магазином](#работа-с-магазином)
- [Обработка ошибок](#обработка-ошибок)
- [Структура файлов данных](#структура-файлов-данных)

---

## Общее устройство

Пространство имён `Bookstore` содержит набор классов для управления простым книжным магазином в памяти, без базы данных.

Основные элементы:

- `Book` — книга с уникальным Id, названием, автором, жанром, страницами, ценой и статусом продажи.
- `BookCase` — шкаф для книг одного жанра с заданной вместимостью.
- `BookStore` — магазин, который содержит шкафы, умеет добавлять книги, продавать их и считать баланс.
- `Library` — глобальный список всех созданных книг (вне зависимости от того, добавлены ли они в магазин).

---

## Установка и запуск

1. Скопируйте файлы с пространством имён `Bookstore` в свой solution или добавьте как отдельный проект Class Library.
2. Подключите пространство имён в коде:

```csharp
using Bookstore;
```

3. Убедитесь, что рядом с исполняемым файлом доступны текстовые файлы:

```text
BooksNames.txt
BooksAuthors.txt
BooksGenres.txt
```

Они используются для генерации случайных названий, авторов и жанров.

---

## Быстрый старт

Ниже — минимальный пример, который создаёт магазин, добавляет в него несколько книг и продаёт одну из них.

```csharp
using System;
using Bookstore;

class Program
{
    static void Main()
    {
        // Создаём магазин с максимум 3 шкафами
        var store = new BookStore(maxCases: 3);

        // Создаём несколько книг (часть полей генерируется автоматически)
        var novel = new Book(genre: "Роман");
        var fantasy = new Book(genre: "Фантастика");
        var detective = new Book(genre: "Детектив");

        // Добавляем книги в магазин
        store.AddBookToStore(novel);
        store.AddBookToStore(fantasy);
        store.AddBookToStore(detective);

        // Находим и продаём книгу
        var toSell = store.FindBookById(fantasy.Id);
        store.SellBook(toSell);

        Console.WriteLine($"Баланс магазина: {store.Balance} руб.");
    }
}
```

---

## Модель предметной области

### Library

`Library` — статический "глобальный каталог" всех созданных книг.

```csharp
// Получить список всех книг в системе
foreach (var book in Library.Books)
{
    Console.WriteLine($"{book.Id}: {book.Name} ({book.Genre})");
}
```

Особенности:

- Любой вызов `new Book(...)` автоматически добавляет книгу в `Library.Books`.
- Коллекция может использоваться для отладки, статистики или глобального поиска.

---

### Book

`Book` описывает одну книгу и отвечает за генерацию значений по умолчанию и продажу.

**Основные свойства:**

- `int Id` — уникальный идентификатор (автоинкремент).
- `string Name` — название книги, делается уникальным при конфликте.
- `string Author` — автор книги.
- `string Genre` — жанр книги.
- `int PageNumber` — число страниц (по умолчанию 50–1000).
- `decimal Price` — цена (по умолчанию 100–1500 рублей).
- `bool IsSold` — флаг, продана книга или нет.

**Конструктор:**

```csharp
var customBook = new Book(
    name: "Война и мир",
    author: "Л. Н. Толстой",
    genre: "Роман",
    pageNumber: 1200,
    price: 999m
);

// Частично заполненные данные — остальное генерируется автоматически
var randomBook = new Book(genre: "Фантастика");
```

Если параметр не указан:

- `Name` берётся из `BooksNames.txt` и при необходимости уникализируется.
- `Author` берётся из `BooksAuthors.txt`.
- `Genre` берётся из `BooksGenres.txt`.
- `PageNumber` и `Price` генерируются случайно в заданных диапазонах.

**Продажа:**

```csharp
decimal income = customBook.Sell();
Console.WriteLine($"Книга продана за {income} руб.");
Console.WriteLine($"Статус: {(customBook.IsSold ? "продана" : "в наличии")}");
```

- При первой продаже `Sell()` помечает книгу как проданную и возвращает цену.
- При повторном вызове будет выброшен `InvalidOperationException`.

---

### BookCase

`BookCase` — шкаф для книг одного жанра, с ограниченной вместимостью.

**Свойства:**

- `string Genre` — жанр книг в шкафу.
- `int Capacity` — максимальное количество книг.
- `IReadOnlyList<Book> Books` — текущие книги в шкафу.
- `bool HasSpace` — есть ли ещё место.

**Создание шкафа:**

```csharp
var fantasyCase = new BookCase(genre: "Фантастика", capacity: 20);
```

**Добавление и удаление книг:**

```csharp
var book = new Book(genre: "Фантастика");

if (fantasyCase.HasSpace)
{
    fantasyCase.AddBook(book);
}

// Удаление
bool removed = fantasyCase.RemoveBook(book);
```

Ограничения при `AddBook(book)`:

- `book` не должен быть `null`.
- В шкафу должно быть свободное место.
- Жанр книги должен совпадать с жанром шкафа (без учёта регистра).
- Нельзя добавлять уже проданные книги (`IsSold == true`).

**Поиск в пределах шкафа:**

```csharp
var byId = fantasyCase.FindById(1);
var byName = fantasyCase.FindByName("Война и мир");
```

**Смена жанра:**

```csharp
// Допустимо только для пустого шкафа
fantasyCase.ReassignGenre("Детектив");
```

- Если в шкафу ещё есть книги — будет `InvalidOperationException`.
- Новый жанр не может быть пустым.

---

### BookStore (класс)

`BookStore` — магазин, который управляет наборами шкафов и балансом.

**Свойства:**

- `IReadOnlyList<BookCase> Cases` — список шкафов магазина.
- `int MaxCases` — максимальное количество шкафов.
- `decimal Balance` — текущий денежный баланс магазина.

**Создание магазина:**

```csharp
var store = new BookStore(maxCases: 5);
```

Если `maxCases <= 0`, выбрасывается `ArgumentException`.

**Поиск шкафа по жанру:**

```csharp
var fantasyCase = store.FindCaseByGenre("Фантастика");
```

Если жанр пустой/из пробелов — `ArgumentException`.

**Создание или переиспользование шкафа:**

```csharp
// Найдет шкаф жанра "Фантастика" или пересоздаст пустой,
// или создаст новый с вместимостью по умолчанию (10)
var caseForFantasy = store.CreateOrReuseCase("Фантастика", defaultCapacity: 15);
```

Алгоритм:

1. Попробовать найти шкаф нужного жанра.
2. Если нет — найти пустой шкаф и переназначить жанр.
3. Если и пустых нет — создать новый, если не превышен `MaxCases`.
4. Если шкафов уже `MaxCases` и пустых нет — `InvalidOperationException`.

**Добавление книги в магазин:**

```csharp
var book = new Book(genre: "Фантастика");

store.AddBookToStore(book);
// По необходимости будет создан/переназначен шкаф нужного жанра
```

- Если `book == null` — `ArgumentNullException`.
- Если для жанра нет места — `InvalidOperationException`.

**Поиск книги по всему магазину:**

```csharp
var foundById = store.FindBookById(3);
var foundByName = store.FindBookByName("Война и мир");
```

Возвращает `Book` или `null`, если книга не найдена ни в одном шкафу.

**Продажа книги через магазин:**

```csharp
var bookToSell = store.FindBookByName("Война и мир");
if (bookToSell != null)
{
    store.SellBook(bookToSell);
    Console.WriteLine($"Новый баланс: {store.Balance}");
}
```

- Магазин находит шкаф, которому принадлежит книга.
- Вызывает `book.Sell()`, удаляет книгу из шкафа и увеличивает `Balance` на цену книги.
- Если книга не найдена ни в одном шкафу — `InvalidOperationException`.
- Если передан `null` — `ArgumentNullException`.

**Удаление шкафа:**

```csharp
var caseToRemove = store.FindCaseByGenre("Детектив");
store.RemoveCase(caseToRemove); // Только если в шкафу нет книг
```

- Можно удалить только пустой шкаф.
- Если шкаф содержит книги — `InvalidOperationException`.
- Если `bookCase == null` — `ArgumentNullException`.

---

## Типичные сценарии

### Создание книг

```csharp
// Полная информация
var classic = new Book(
    name: "Преступление и наказание",
    author: "Ф. М. Достоевский",
    genre: "Роман",
    pageNumber: 672,
    price: 750m
);

// Частичная информация — остальное генерируется
var randomGenreBook = new Book(name: "Случайная книга");
var fullyRandomBook = new Book();
```

---

### Работа со шкафами

```csharp
var sciFiCase = new BookCase("Фантастика", capacity: 10);

for (int i = 0; i < 5; i++)
{
    var book = new Book(genre: "Фантастика");
    sciFiCase.AddBook(book);
}

Console.WriteLine($"Книг в шкафу: {sciFiCase.Books.Count}");

// Поиск по Id
var firstBook = sciFiCase.FindById(1);

// Удаление книги
sciFiCase.RemoveBook(firstBook);
```

---

### Работа с магазином

```csharp
var store = new BookStore(maxCases: 3);

// Добавляем несколько книг разных жанров
var novel = new Book(genre: "Роман");
var fantasy = new Book(genre: "Фантастика");
var detective = new Book(genre: "Детектив");

store.AddBookToStore(novel);
store.AddBookToStore(fantasy);
store.AddBookToStore(detective);

// Найти и продать книгу
var toSell = store.FindBookById(fantasy.Id);
store.SellBook(toSell);

Console.WriteLine($"Баланс магазина: {store.Balance} руб.");

// Удалить пустой шкаф
var caseToRemove = store.FindCaseByGenre("Детектив");
store.RemoveCase(caseToRemove); // Только если в шкафу нет книг
```

---

## Обработка ошибок

Основные исключения, которые могут возникать:

- `ArgumentNullException`
  - Передача `null` вместо `Book` или `BookCase` в методах `AddBook`, `AddBookToStore`, `SellBook`, `RemoveCase`.

- `ArgumentException`
  - Пустой жанр при создании `BookCase` или при `ReassignGenre`.
  - Пустой жанр в методах `FindCaseByGenre`, `CreateOrReuseCase`.
  - `maxCases <= 0` в конструкторе `BookStore`.

- `InvalidOperationException`
  - Попытка создать `Book` с пустыми обязательными полями (название, автор, жанр).
  - Повторная продажа книги (`Book.Sell` при `IsSold == true`).
  - Добавление книги в полный шкаф.
  - Жанр книги не совпадает с жанром шкафа.
  - Попытка добавить проданную книгу в шкаф.
  - Попытка изменить жанр шкафа, в котором ещё есть книги.
  - Достигнуто максимальное количество шкафов при `CreateOrReuseCase`.
  - Попытка продать книгу, которой нет ни в одном шкафу.
  - Попытка удалить непустой шкаф.

---

## Структура файлов данных

Классы используют текстовые файлы со строками, одна строка — одно значение.

Пример `BooksNames.txt`:

```text
Тайна старого дома
Последний герой
Лунный свет
Огненный путь
Забытая библиотека
```

Пример `BooksAuthors.txt`:

```text
Аркадий Стругацкий
Борис Стругацкий
Алексей Толстой
Рэй Брэдбери
Урсула Ле Гуин
```

Пример `BooksGenres.txt`:

```text
Фантастика
Роман
Детектив
Фэнтези
Приключения
```

Файлы должны быть доступны по указанным путям относительно рабочей директории приложения.
