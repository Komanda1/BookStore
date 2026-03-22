/*namespace Bookstore
{
    /// <summary>
    /// Класс BookCase
    /// </summary>
    public class GameController
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
        public GameController(string genre, int capacity)
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
*/

namespace Bookstore
{
    /// <summary>
    /// Класс книжного шкафа
    /// </summary>
    public class BookShelf
    {
        private readonly List<Book> _books = new List<Book>();
        public string Genre { get; private set; }
        public int Capacity { get; }
        public int Count => _books.Count;
        public bool HasSpace => _books.Count < Capacity;
        public List<Book> Books => _books;

        /// <summary>
        /// Конструктор шкафа
        /// </summary>
        /// <param name="genre">Название жанра</param>
        /// <param name="capacity">Вместимость</param>
        /// <exception cref="ArgumentException"></exception>
        public BookShelf(string genre,
            int capacity = 10)
        {
            if (string.IsNullOrWhiteSpace(genre))
                throw new ArgumentException("Жанр должен иметь название");

            if (capacity <= 0)
                throw new ArgumentException("Вместимость должна быть больше 0");

            Genre = genre;
            Capacity = capacity;
        }

        /// <summary>
        /// Добавление книги в шкаф
        /// </summary>
        /// <param name="book">Название книги </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (!HasSpace)
                throw new InvalidOperationException("В шкафу нет места");

            if (!string.Equals(book.Genre, Genre, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"Книга должна быть жанра '{Genre}', а не '{book.Genre}'");

            if (book.IsSold)
                throw new InvalidOperationException("Нельзя добавить уже проданную книгу");

            Book.AddBook();
            _books.Add(book);
        }

        /// <summary>
        /// Поиск книги по ID
        /// </summary>
        /// <param name="id">Id книги</param>
        /// <returns>Найденная книга</returns>
        public Book FindById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        /// <summary>
        /// Поиск книги по названию
        /// </summary>
        /// <param name="name"> название книги </param>
        /// <returns>Найденная книга</returns>
        public Book FindByName(string name)
        {
            return _books.FirstOrDefault(b => b.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Удаление книги из шкафа
        /// </summary>
        /// <param name="book"> название книги </param>
        /// <returns></returns>
        public bool RemoveBook(Book book)
        {
            return _books.Remove(book);
        }

        /// <summary>
        /// Получение списка книг в порядке ID
        /// </summary>
        /// <returns>Список книг</returns>
        public IEnumerable<Book> GetBooksInOrder()
        {
            return _books.OrderBy(book => book.Id).ToList();
        }

        /// <summary>
        /// Очистка шкафа (продажа всех книг)
        /// </summary>
        /// <returns>Общая выручка</returns>
        public decimal SellAll()
        {
            decimal total = 0;
            foreach (var book in _books)
            {
                total += book.Sell();
            }
            _books.Clear();
            return total;
        }

        /// <summary>
        /// Смена жанра шкафа (только если пуст)
        /// </summary>
        /// <param name="newGenre">Название нового жанра</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void ChangeGenre(string newGenre)
        {
            if (_books.Count > 0)
                throw new InvalidOperationException("Нельзя сменить жанр непустого шкафа");

            if (string.IsNullOrWhiteSpace(newGenre))
                throw new ArgumentException("Необходимо указать название жанра");

            Genre = newGenre;
        }

        /// <summary>
        /// Ввод информации о шкафе
        /// </summary>
        /// <returns>Информация</returns>
        public override string ToString()
        {
            return $"{Genre} ({_books.Count}/{Capacity})";
        }
    }
}