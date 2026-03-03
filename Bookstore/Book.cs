namespace Bookstore
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

        public int Id { get;}
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
            string name = null,
            string author = null,
            string genre = null,
            int? pageNumber = null,
            decimal? price = null)
        {
            Id = GetId();
            Name = MakeUniqueName(name) ?? GenerateUniqueName();
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
        private static string GenerateUniqueName()
        {
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
}
