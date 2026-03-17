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
        /// <param name="Name"> название книги </param>
        /// <param name="Author"> автор </param>
        /// <param name="Genre"> жанр </param>
        /// <param name="PageNumber">кол-во страниц </param>
        /// <param name="BasePrice"> цена книги </param>
        /// <exception cref="ArgumentException"></exception>
        public Book(string Name, string Author, string Genre, int PageNumber, decimal BasePrice)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Author) || string.IsNullOrWhiteSpace(Genre))
                throw new ArgumentException("Название, автор и жанр не могут быть пустыми");

            if (PageNumber <= 0)
                throw new ArgumentException("Количество страниц должно быть больше 0");

            if (BasePrice <= 0)
                throw new ArgumentException("Цена должна быть больше 0");

            Id = lastId + 1;
            Name = Name;
            Author = Author;
            Genre = Genre;
            PageNumber = PageNumber;
            BasePrice = BasePrice;
            IsSold = false;
            IsPlagiat = false;
            IsError = false;
        }

        /// <summary>
        /// Конструктор для случайной генерации
        /// </summary>
        public Book()
        {
            Id = lastId + 1;
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
            IsPlagiat = false;
            IsError = false;
        }

        /// <summary>
        /// Создание книги с возможными ошибками
        /// </summary>
        public static Book CreateWithPossibleError()
        {
            var book = new Book();
            // 30% шанс ошибки
            if (rnd.Next(100) < 30)
            {
                if (rnd.Next(2) == 0)
                {
                    // Плагиат: меняем автора
                    book.Author = GetRandomAuthorDifferent(book.Author);
                    book.IsPlagiat = true;
                }
                else
                {
                    // Опечатка: меняем символ в названии
                    book.Name = CreateErrorInName(book.Name);
                    book.IsError = true;
                }
            }
            return book;
        }

        /// <summary>
        /// Создание опечатки в названии
        /// </summary>
        /// <param name="name"> название книги </param>
        /// <returns> измененное название </returns>
        private static string CreateErrorInName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            var chars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int index = rnd.Next(name.Length);
            char newChar;

            do
            {
                newChar = chars[rnd.Next(chars.Length)];
            }
            while (newChar == name[index]);

            return name.Substring(0, index) + newChar + name.Substring(index + 1);
        }

        /// <summary>
        /// Продажа книги
        /// </summary>
        /// <returns> цена книги (базовая)  </returns>
        /// <exception cref="InvalidOperationException"></exception>
        public decimal Sell()
        {
            if (IsSold)
                throw new InvalidOperationException("Книга уже продана");
            IsSold = true;
            return BasePrice;
        }

        /// <summary>
        /// Проверка на плагиат
        /// </summary>
        /// <param name="book"> название проверяемой книги </param>
        /// <returns></returns>
        public bool CheckPlagiat(Book book)
        {
            return string.Equals(Name, book.Name, StringComparison.OrdinalIgnoreCase) && !string.Equals(Author, book.Author, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Получение пары название-автор из файла
        /// </summary>
        /// <returns> название книги и автор</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static (string Name, string Author) GetRandomNameAuthorPair()
        {
            var lines = File.ReadLines("NameAuthor.txt").Where(l => !string.IsNullOrWhiteSpace(l) && l.Contains('|')).ToList();

            if (lines.Count == 0)
                throw new InvalidOperationException("Файл NameAuthor.txt пуст или некорректен");

            var line = lines[rnd.Next(lines.Count)];
            var parts = line.Split('|');
            return (parts[0].Trim(), parts[1].Trim());
        }

        /// <summary>
        /// Получение случайного автора, отличного от указанного
        /// </summary>
        /// <param name="Author"> текущий автор </param>
        /// <returns></returns>
        private static string GetRandomAuthorDifferent(string Author)
        {
            var authors = File.ReadLines("NameAuthor.txt").Where(l => !string.IsNullOrWhiteSpace(l) && l.Contains('|'))
                             .Select(l => l.Split('|')[1].Trim()).Where(a => !string.Equals(a, Author, StringComparison.OrdinalIgnoreCase)).ToList();

            if (authors.Count == 0)
                return "Не найден автор, отличный от указанного";

            return authors[rnd.Next(authors.Count)];
        }

        /// <summary>
        /// Чтение случайной строки из файла
        /// </summary>
        /// <param name="path"> файл </param>
        /// <returns> строка </returns>
        /// <exception cref="Exception"></exception>
        public static string GetRandomLineFromFile(string path)
        {
            int count = 0;
            // Первый проход для получения количества строк в файле
            using (var reader = new StreamReader(path))
            {
                while (reader.ReadLine() != null)
                    count++;
            }

            if (count == 0)
                throw new Exception("Пустой файл");

            int targetIndex = rnd.Next(count); // 0 - count-1

            // Второй проход для чтения самой строки
            using (var reader = new StreamReader(path))
            {
                for (int i = 0; i < targetIndex; i++)
                    reader.ReadLine();

                return reader.ReadLine() ?? string.Empty; // В случае null, вернем пустую строку
            }
        }
    }
}
