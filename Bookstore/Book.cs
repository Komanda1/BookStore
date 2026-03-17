/*using System.Xml.Linq;

namespace Book
{
    /// <summary>
    /// Статический список всех книг
    /// </summary>
     public static class Library
     {
         /// <summary>
         /// Список всех книг
         /// </summary>
         public static List<Book> Books { get; } = new();
     }

     /// <summary>
     /// Класс Book
     /// </summary>
     public class Book
     {
         private static int lastId = 0;
         private static readonly Random rnd = new Random();

         public int Id { get; internal set; }
         public string Name { get; set; }
         public string Author { get; set; }
         public string Genre { get; set; }
         public int PageNumber { get; set; }
         public decimal Price { get; set; }

         public bool IsSold { get; private set; }

         /// <summary>
         /// Конструктор класса Book
         /// </summary>
         /// <param name="name">Название книги</param>
         /// <param name="author">Автор книги</param>
         /// <param name="genre">Жанр книги</param>
         /// <param name="pageNumber">Количество страниц</param>
         /// <param name="price">Цена</param>
         /// <exception cref="InvalidOperationException">Книга не может быть создана с пустыми полями</exception>
         public Book(
             string? name = null,
             string? author = null,
             string? genre = null,
             int? pageNumber = null,
             decimal? price = null)
         {
             //Id = GetId();
             Name = GenerateUniqueName(name);
             Author = author ?? GetRandomLineFromFile("BooksAuthors.txt");
             Genre = genre ?? GetRandomLineFromFile("BooksGenres.txt");
             PageNumber = pageNumber ?? rnd.Next(50, 1101); // 50 - 1100 cтраниц
             Price = price ?? (decimal)rnd.Next(100, 1501); // 100 - 1500 руб

             if (string.IsNullOrWhiteSpace(Name) ||
                 string.IsNullOrWhiteSpace(Author) ||
                 string.IsNullOrWhiteSpace(Genre))
             {
                 throw new InvalidOperationException("Книга не может быть создана с пустыми полями.");
             }

             Library.Books.Add(this);
         }

         private static int GetId()
         {
             lastId++;
             return lastId;
         }

         /// <summary>
         /// Метод для получения случайной строки из файла
         /// </summary>
         /// <param name="path">Путь к файлу</param>
         /// <returns>Случайная строка</returns>
         /// <exception cref="Exception">Пустой файл</exception>
         private static string GetRandomLineFromFile(string path)
         {
             int count = 0;

             //Первый проход для получения количества строк в файле
             using (var reader = new StreamReader(path))
             {
                 while (reader.ReadLine() != null)
                     count++;
             }

             if (count == 0)
                 throw new Exception("Пустой файл.");

             int targetIndex = rnd.Next(count); // 0 - count-1

             //Второй проход для чтения самой строки
             using (var reader = new StreamReader(path))
             {
                 for (int i = 0; i < targetIndex; i++)
                     reader.ReadLine();

                 return reader.ReadLine() ?? string.Empty;
             }
         }

         /// <summary>
         /// Метод для генерации уникального имени книги
         /// </summary>
         /// <returns></returns>
         private static string GenerateUniqueName(string? name)
         {
             if (name != null)
                 return MakeUniqueName(name);
             var baseName = GetRandomLineFromFile("BooksNames.txt");
             return MakeUniqueName(baseName);
         }

         /// <summary>
         /// Метод для создания уникального имени книги
         /// </summary>
         /// <param name="baseName">Название книги</param>
         /// <returns></returns>
         private static string MakeUniqueName(string baseName)
         {
             //Книги с тем же названием, но разные
             var sameNameBooks = Library.Books
                 .Where(b => b.Name.StartsWith(baseName, StringComparison.OrdinalIgnoreCase))
                 .Select(b => b.Name)
                 .ToList();

             if (sameNameBooks.Count == 0)
                 return baseName;

             int maxNumber = 1;

             foreach (var name in sameNameBooks)
             {
                 if (name.Equals(baseName, StringComparison.OrdinalIgnoreCase))
                 {
                     maxNumber = Math.Max(maxNumber, 1);
                 }
                 else
                 {
                     //Отрезаем базовую часть и читаем число
                     var rest = name.Substring(baseName.Length).TrimStart();
                     if (int.TryParse(rest, out int n))
                     {
                         if (n > maxNumber)
                             maxNumber = n;
                     }
                 }
             }

             return $"{baseName} {maxNumber + 1}";
         }

         /// <summary>
         /// Метод продажи книги
         /// </summary>
         /// <returns></returns>
         /// <exception cref="InvalidOperationException">Книга уже продана</exception>
         public decimal Sell()
         {
             if (IsSold)
                 throw new InvalidOperationException("Книга уже продана.");

             IsSold = true;
             return Price;
         }
     }
    */
using System;
using System.Text.RegularExpressions;

    namespace Bookstore
    {
        /// <summary>
        /// Класс, представляющий книгу в магазине
        /// </summary>
        public class Book
        {
            private static int lastId = 0;
            private static Random rnd = new Random();
            public int Id { get; set; }
            public string Name { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public int PageNumber { get; set; }
            public decimal BasePrice { get; set; }
            public decimal SellPrice => BasePrice;
            public bool IsSold { get; set; }
            public bool IsPlagiat { get; set; }
            public bool IsError { get; set; }

            /// <summary>
            /// Конструктор книги
            /// </summary>
            public Book(string name, string author, string genre, int pageNumber, decimal basePrice)
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(genre))
                    throw new ArgumentException("Название, автор и жанр не могут быть пустыми");

                if (pageNumber <= 0)
                    throw new ArgumentException("Количество страниц должно быть больше 0");

                if (basePrice <= 0)
                    throw new ArgumentException("Цена должна быть больше 0");

                Id = ++lastId;
                Name = name.Trim();
                Author = author.Trim();
                Genre = genre.Trim();
                PageNumber = pageNumber;
                BasePrice = basePrice;
                IsSold = false;
                IsPlagiat = false;
                IsError = false;
            }

            /// <summary>
            /// Конструктор для случайной генерации
            /// </summary>
            public Book()
            {
                Id = ++lastId;
                GenerateRandom();
            }

            /// <summary>
            /// Случайная генерация книги из файлов
            /// </summary>
            public void GenerateRandom()
            {
                var nameAuthor = GetRandomNameAuthorPair();
                Name = nameAuthor.Name;
                Author = nameAuthor.Author;
                Genre = GetRandomLineFromFile("Genres.txt");
                PageNumber = rnd.Next(50, 1001);
                BasePrice = rnd.Next(100, 1501);
                IsSold = false;
                IsPlagiarism = false;
                HasTypo = false;
            }

            /// <summary>
            /// Создание книги с возможными ошибками (плагиат/опечатка)
            /// </summary>
            public static Book CreateWithPossibleError()
            {
                var book = new Book();

                // 30% шанс ошибки
                if (rnd.Next(100) < 30)
                {
                    if (rnd.Next(2) == 0)
                    {
                        // Плагиат - меняем автора
                        book.Author = GetRandomAuthorDifferentFrom(book.Author);
                        book.IsPlagiarism = true;
                    }
                    else
                    {
                        // Опечатка - меняем символ в названии
                        book.Name = CreateTypoInName(book.Name);
                        book.HasTypo = true;
                    }
                }

                return book;
            }

            /// <summary>
            /// Создание опечатки в названии
            /// </summary>
            private static string CreateTypoInName(string name)
            {
                if (string.IsNullOrEmpty(name) || name.Length < 2)
                    return name;

                var chars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                int index = rnd.Next(name.Length);
                char newChar;

                do
                {
                    newChar = chars[rnd.Next(chars.Length)];
                } while (newChar == name[index]); // Гарантируем, что символ изменится

                return name.Substring(0, index) + newChar + name.Substring(index + 1);
            }

            /// <summary>
            /// Продажа книги
            /// </summary>
            /// <returns>Цена продажи</returns>
            public decimal Sell()
            {
                if (IsSold)
                    throw new InvalidOperationException("Книга уже продана.");

                IsSold = true;
                return BasePrice;
            }

            /// <summary>
            /// Проверка на плагиат
            /// </summary>
            public bool CheckPlagiarism(Book existingBook)
            {
                return string.Equals(Name, existingBook.Name, StringComparison.OrdinalIgnoreCase) &&
                       !string.Equals(Author, existingBook.Author, StringComparison.OrdinalIgnoreCase);
            }

            /// <summary>
            /// Получение пары название-автор из файла
            /// </summary>
            private static (string Name, string Author) GetRandomNameAuthorPair()
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NameAuthor.txt");

                if (!File.Exists(path))
                    throw new FileNotFoundException("Файл NameAuthor.txt не найден.");

                var lines = File.ReadLines(path)
                               .Where(l => !string.IsNullOrWhiteSpace(l) && l.Contains('|'))
                               .ToList();

                if (lines.Count == 0)
                    throw new InvalidOperationException("Файл NameAuthor.txt пуст или некорректен.");

                var line = lines[rnd.Next(lines.Count)];
                var parts = line.Split('|');

                return (parts[0].Trim(), parts[1].Trim());
            }

            /// <summary>
            /// Получение случайного автора, отличного от указанного
            /// </summary>
            private static string GetRandomAuthorDifferentFrom(string excludeAuthor)
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NameAuthor.txt");
                var authors = File.ReadLines(path)
                                 .Where(l => !string.IsNullOrWhiteSpace(l) && l.Contains('|'))
                                 .Select(l => l.Split('|')[1].Trim())
                                 .Distinct()
                                 .Where(a => !string.Equals(a, excludeAuthor, StringComparison.OrdinalIgnoreCase))
                                 .ToList();

                if (authors.Count == 0)
                    return "Неизвестный Автор";

                return authors[rnd.Next(authors.Count)];
            }

            /// <summary>
            /// Чтение случайной строки из файла
            /// </summary>
            private static string GetRandomLineFromFile(string fileName)
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                if (!File.Exists(path))
                    return "Фантастика";

                var lines = File.ReadLines(path)
                               .Where(l => !string.IsNullOrWhiteSpace(l))
                               .ToList();

                return lines.Count > 0 ? lines[rnd.Next(lines.Count)] : "Фантастика";
            }

            /// <summary>
            /// Переопределение ToString для отображения
            /// </summary>
            public override string ToString()
            {
                string errors = "";
                if (IsPlagiarism) errors += " [ПЛАГИАТ]";
                if (HasTypo) errors += " [ОПЕЧАТКА]";

                return $"[{Id}] {Name} - {Author} ({Genre}){errors}";
            }
        }
    }
