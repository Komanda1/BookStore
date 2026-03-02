namespace Bookstore
{
    /// <summary>
    /// Класс Book
    /// </summary>
    public class Book
    {
        private static int lastId = 0;
        private static readonly Random rnd = new Random();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PageNumber { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// Конструктор класса Book
        /// </summary>
        /// <param name="id">ID книги</param>
        /// <param name="name">Название книги</param>
        /// <param name="author">Автор книги</param>
        /// <param name="genre">Жанр книги</param>
        /// <param name="pageNumber">Количество страниц</param>
        /// <param name="price">Цена</param>
        public Book(
            string name = null,
            string author = null,
            string genre = null,
            int? pageNumber = null,
            decimal? price = null)
        {
            Id = GetId();
            Name = name ?? GetRandomLineFromFile("BooksNames.txt"); ;
            Author = author ?? GetRandomLineFromFile("BooksAuthors.txt"); ;
            Genre = genre ?? GetRandomLineFromFile("BooksGenres.txt"); ;
            PageNumber = pageNumber ?? rnd.Next(50, 1001); // 50 - 1000 cтраниц
            Price = price ?? (decimal)rnd.Next(100, 1501); // 100 - 1500 руб
        }

        private static int GetId()
        {
            lastId++;
            return lastId;
        }

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
                throw new Exception("Empty file");

            int targetIndex = rnd.Next(count); // 0..count-1

            //Второй проход для чтения самой строки
            using (var reader = new StreamReader(path))
            {
                for (int i = 0; i < targetIndex; i++)
                    reader.ReadLine();

                return reader.ReadLine() ?? string.Empty;
            }

        }
    }
}
