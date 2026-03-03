namespace Bookstore
{
    /// <summary>
    /// Класс BookCase
    /// </summary>
    public class BookCase
    {
        public string Genre { get; private set; }
        public int Capacity { get; }


        private readonly List<Book> books = new();

        /// <summary>
        /// Список книг
        /// </summary>
        public IReadOnlyList<Book> Books => books;

        /// <summary>
        /// Конструктор класса BookCase
        /// </summary>
        /// <param name="genre">Жанр</param>
        /// <param name="capacity">Количество книг</param>
        /// <exception cref="ArgumentException">Жанр шкафа не может быть пустым, Вместимость должна быть > 0</exception>
        public BookCase(string genre, int capacity)
        {
            if (string.IsNullOrWhiteSpace(genre))
                throw new ArgumentException("Жанр шкафа не может быть пустым.");

            if (capacity <= 0)
                throw new ArgumentException("Вместимость должна быть > 0.");

            Genre = genre;
            Capacity = capacity;
        }

        public bool HasSpace => books.Count < Capacity;

        /// <summary>
        /// Метод добавления книги
        /// </summary>
        /// <param name="book">Книга</param>
        /// <exception cref="ArgumentNullException">Книга не может быть null</exception>
        /// <exception cref="InvalidOperationException">В шкафу нет места, Жанр книги не совпадает с жанром шкафа, Нельзя добавить проданную книгу</exception>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (!HasSpace)
                throw new InvalidOperationException("В шкафу нет места.");

            //StringComparison.OrdinalIgnoreCase для регистронезависимости
            if (!string.Equals(book.Genre, Genre, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Жанр книги не совпадает с жанром шкафа.");

            if (book.IsSold)
                throw new InvalidOperationException("Нельзя добавить проданную книгу.");

            books.Add(book);
        }

        /// <summary>
        /// Метод поиска книги по id
        /// </summary>
        /// <param name="id">Id книги</param>
        /// <returns>Найденная книга</returns>
        public Book FindById(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        /// <summary>
        /// Метод поиска книги по названию
        /// </summary>
        /// <param name="name">Название книги</param>
        /// <returns>Найденная книга</returns>
        public Book FindByName(string name)
        {
            return books.FirstOrDefault(b => string.Equals(b.Name, name, StringComparison.OrdinalIgnoreCase));
        }
        
        /// <summary>
        /// Метод получения списка книг
        /// </summary>
        /// <returns>Список книг</returns>
        public IEnumerable<Book> GetBooksInOrder()
        {
            return books; 
        }
        /// <summary>
        /// Метод удаления книги
        /// </summary>
        /// <param name="book">Книга</param>
        /// <returns>Удалена ли книга</returns>
        internal bool RemoveBook(Book book)
        {
            return books.Remove(book);
        }
        /// <summary>
        /// Метод смены жанра
        /// </summary>
        /// <param name="newGenre">Новый жанр</param>
        /// <exception cref="InvalidOperationException">Нельзя сменить жанр, пока в шкафу есть книги</exception>
        /// <exception cref="ArgumentException">Жанр не может быть пустым</exception>
        public void ReassignGenre(string newGenre)
        {
            if (books.Count > 0)
                throw new InvalidOperationException("Нельзя сменить жанр, пока в шкафу есть книги.");

            if (string.IsNullOrWhiteSpace(newGenre))
                throw new ArgumentException("Жанр не может быть пустым.");

            Genre = newGenre;
        }

        public int OccupiedCount => books.Count;
    }
}
