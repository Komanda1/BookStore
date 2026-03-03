namespace Bookstore
{
    /// <summary>
    /// Класс BookStore
    /// </summary>
    public class BookStore
    {
        private readonly List<BookCase> cases = new();
        public IReadOnlyList<BookCase> Cases => cases;

        public int MaxCases { get; }
        public decimal Balance { get; private set; }

        /// <summary>
        /// Конструктор класса BookStore
        /// </summary>
        /// <param name="maxCases">Максимальное количество шкафов</param>
        /// <exception cref="ArgumentException">Максимальное количество шкафов должно быть > 0</exception>
        public BookStore(int maxCases)
        {
            if (maxCases <= 0)
                throw new ArgumentException("Максимальное количество шкафов должно быть > 0.");

            MaxCases = maxCases;
        }

        /// <summary>
        /// Метод поиска шкафа по жанру
        /// </summary>
        /// <param name="genre">Жанр</param>
        /// <returns>Найденный шкаф</returns>
        /// <exception cref="ArgumentException">Жанр не может быть пустым</exception>
        public BookCase? FindCaseByGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
                throw new ArgumentException("Жанр не может быть пустым.");

            return cases.FirstOrDefault(c => string.Equals(c.Genre, genre, StringComparison.OrdinalIgnoreCase));
        }
        public List<string> GetAvailableGenres()
        {
            return cases.Select(c => c.Genre).Distinct().ToList();
        }

        /// <summary>
        /// Метод создания или использования шкафа
        /// </summary>
        /// <param name="genre">Жанр</param>
        /// <param name="defaultCapacity">Вместимость</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Жанр не может быть пустым.</exception>
        /// <exception cref="InvalidOperationException">Достигнуто максимальное количество шкафов</exception>
        public BookCase CreateOrReuseCase(string genre, int defaultCapacity = 10)
        {
            if (string.IsNullOrWhiteSpace(genre))
                throw new ArgumentException("Жанр не может быть пустым.");

            //Пробуем использовать существующий шкаф с нужным жанром
            var existing = FindCaseByGenre(genre);
            if (existing != null)
                return existing;

            //Иначе пробуем использовать пустой шкаф
            var emptyCase = cases.FirstOrDefault(c => !c.Books.Any());
            if (emptyCase != null)
            {
                emptyCase.ReassignGenre(genre);
                return emptyCase;
            }

            //Если пустых шкафов нет и нет места, то ошибка
            if (cases.Count >= MaxCases)
                throw new InvalidOperationException("Достигнуто максимальное количество шкафов.");

            //Создаем новый шкаф
            var newCase = new BookCase(genre, capacity: defaultCapacity);
            cases.Add(newCase);
            return newCase;
        }

        /// <summary>
        /// Добавляет книгу в магазин, автоматически находя или создавая шкаф нужного жанра.
        /// </summary>
        /// <param name="book">Книга для добавления</param>
        /// <param name="defaultCapacity">Вместимость шкафа по умолчанию, если создаётся новый</param>
        /// <exception cref="ArgumentNullException">Книга не может быть null</exception>
        /// <exception cref="InvalidOperationException">В шкафу для этого жанра нет места</exception>
        public void AddBookToStore(Book book, int defaultCapacity = 10)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            //Пробуем найти шкаф нужного жанра
            var bookCase = FindCaseByGenre(book.Genre);

            //Если шкафа с таким жанром нет, то создем или пересоздаем
            if (bookCase == null)
            {
                bookCase = CreateOrReuseCase(book.Genre, defaultCapacity);
            }

            //Проверяем наличие места
            if (!bookCase.HasSpace)
                throw new InvalidOperationException("В шкафу для этого жанра нет места.");

            //Добавляем книгу в найденный или созданный шкаф
            bookCase.AddBook(book);
        }

        /// <summary>
        /// Ищет книгу по уникальному идентификатору во всех шкафах магазина.
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Найденная книга или null, если книга не найдена</returns>
        public Book FindBookById(int id)
        {
            foreach (var bookCase in cases)
            {
                var found = bookCase.FindById(id);
                if (found != null)
                    return found;
            }
            return null;
        }

        /// <summary>
        /// Ищет книгу по названию во всех шкафах магазина.
        /// </summary>
        /// <param name="name">Название книги</param>
        /// <returns>Найденная книга или null, если книга не найдена</returns>
        public Book FindBookByName(string name)
        {
            foreach (var bookCase in cases)
            {
                var found = bookCase.FindByName(name);
                if (found != null)
                    return found;
            }
            return null;
        }

        /// <summary>
        /// Метод продажи книги
        /// </summary>
        /// <param name="book">Книга</param>
        /// <exception cref="ArgumentNullException">Книга не может быть null</exception>
        /// <exception cref="InvalidOperationException">Книга не найдена в магазине</exception>
        public void SellBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var ownerCase = cases.FirstOrDefault(c => c.Books.Contains(book));
            if (ownerCase == null)
                throw new InvalidOperationException("Книга не найдена в магазине.");

            decimal income = book.Sell();
            ownerCase.RemoveBook(book);
            Balance += income;
        }

        /// <summary>
        /// Удалить шкаф из магазина (только если он пустой)
        /// </summary>
        /// <param name="bookCase">Шкаф</param>
        /// <exception cref="ArgumentNullException">Шкаф не может быть null</exception>
        /// <exception cref="InvalidOperationException">Нельзя удалить непустой шкаф</exception>
        public void RemoveCase(BookCase bookCase)
        {
            if (bookCase == null)
                throw new ArgumentNullException(nameof(bookCase));

            if (bookCase.Books.Count > 0)
                throw new InvalidOperationException("Нельзя удалить шкаф, пока в нём есть книги.");

            cases.Remove(bookCase);
        }

    }
}
