namespace Bookstore
{
    /// <summary>
    /// Класс Book
    /// </summary>
    public class Book
    {
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
        public Book(int id, string name, string author, string genre, int pageNumber, decimal price)
        {
            Id = id;
            Name = name;
            Author = author;
            Genre = genre;
            PageNumber = pageNumber;
            Price = price;
        }

        public void BookGeniratoin(Book book)
        {
        //Генерация
        }
    }
}
