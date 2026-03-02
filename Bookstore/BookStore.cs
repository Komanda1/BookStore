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
    }
}
