/*namespace Bookstore
{
    /// <summary>
    /// Класс BookStore
    /// </summary>
    public class BookStore
    {

        private int lastBookId = 0;

        private int GetNextBookId()
        {
            lastBookId++;
            return lastBookId;
        }

        public int GetLastBookId()
        {
            return lastBookId;
        }

        private readonly List<GameController> cases = new();
        public IReadOnlyList<GameController> Cases => cases;

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
        public GameController? FindCaseByGenre(string genre)
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
        public GameController CreateOrReuseCase(string genre, int defaultCapacity = 10)
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
            var newCase = new GameController(genre, capacity: defaultCapacity);
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

            // если Id ещё не назначен — назначаем при первом добавлении в магазин
            if (book.Id == 0)
            {
                book.Id = GetNextBookId();
            }

            var bookCase = FindCaseByGenre(book.Genre);

            if (bookCase == null)
            {
                bookCase = CreateOrReuseCase(book.Genre, defaultCapacity);
            }

            if (!bookCase.HasSpace)
                throw new InvalidOperationException("В шкафу для этого жанра нет места.");

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
        public void RemoveCase(GameController bookCase)
        {
            if (bookCase == null)
                throw new ArgumentNullException(nameof(bookCase));

            if (bookCase.Books.Count > 0)
                throw new InvalidOperationException("Нельзя удалить шкаф, пока в нём есть книги.");

            cases.Remove(bookCase);
        }

    }
}
*/

namespace Bookstore
{
    /// <summary>
    /// Класс книжного магазина
    /// </summary>
    public class BookStore
    {
        private List<BookShelf> _shelves = new List<BookShelf>();
        private List<Book> _deliveryQueue = new List<Book>();
        private List<Book> _myDeliveryQueue = new List<Book>();
        private List<Customer> _customerQueue = new List<Customer>();
        private List<(string Name, string Author)> _database = new List<(string, string)>();
        public int MaxShelves { get; }
        public decimal Balance { get; set; }
        public int UnsatisfiedCustomers { get; set; }
        public int SatisfiedCustomers { get; set; }
        public List<Book> DeliveryQueue => _deliveryQueue;
        public List<Customer> CustomerQueue => _customerQueue;
        public List<BookShelf> Shelves => _shelves;
        public List<Book> DeliveryMyBooksQueue => _myDeliveryQueue;

        /// <summary>
        /// Конструктор магазина
        /// </summary>
        /// <param name="maxShelves">Максимальное кол-во шкафов</param>
        /// <param name="startBalance">Начальный баланс</param>
        /// <exception cref="ArgumentException"></exception>
        public BookStore(int maxShelves,
            decimal startBalance = 1000)
        {
            if (maxShelves <= 0)
                throw new ArgumentException("Максимальное количество шкафов должно быть больше 0");

            if (startBalance < 0)
                throw new ArgumentException("Баланс не может быть отрицательным");

            MaxShelves = maxShelves;
            Balance = startBalance;
            UnsatisfiedCustomers = 0;
            SatisfiedCustomers = 0;
            LoadDatabase();
        }

        /// <summary>
        /// Загрузка данных из файла
        /// </summary>
        private void LoadDatabase()
        {
            foreach (var line in File.ReadLines("NameAuthor.txt"))
            {
                if (line.Contains(' '))
                {
                    var parts = line.Split(' ');
                    _database.Add((parts[0].Trim(), parts[1].Trim()));
                }
            }

        }

        /// <summary>
        /// Сохранение новой книги в файл
        /// </summary>
        /// <param name="name">Название книги</param>
        /// <param name="author">Автор</param>
        private void SaveNewBookToDatabase(string name, string author)
        {
            File.AppendAllText("NameAuthor.txt", $"{Environment.NewLine}{name} | {author}");
        }

        /// <summary>
        /// Заказ конкретной книги
        /// </summary>
        /// <param name="name">Название книги</param>
        /// <param name="author">Автор</param>
        /// <param name="genre">Жанр</param>
        /// <param name="pages">Кол-во страниц</param>
        /// <param name="price">Цена</param>
        /// <param name="message">Сообщение о результате</param>
        /// <returns>Заказана ли книга</returns>
        public bool OrderBook(string name,
            string author,
            string genre,
            int pages,
            decimal price,
            out string message)
        {
            message = "";
            if (Balance - price < 0)
            {
                message = "У вас недостаточно средств на балансе";
                return false;
            }

            Balance -= price;

            var book = new Book(name, author, genre, pages, price);
            _deliveryQueue.Add(book);

            _database.Add((name, author));
            SaveNewBookToDatabase(name, author);
            return true;
        }

        /// <summary>
        /// Добавление случайной книги в очередь поставок
        /// </summary>
        public void AddRandomDelivery()
        {
            var book = Book.CreateWithPossibleError();
            _deliveryQueue.Add(book);
        }

        /// <summary>
        /// Добавление заказанной книги в очередь поставок
        /// </summary>
        public void AddMyDelivery()
        {
            _deliveryQueue.Add(_myDeliveryQueue[0]);
            _myDeliveryQueue.Remove(_myDeliveryQueue[0]);
        }

        /// <summary>
        /// Добавление покупателя в очередь
        /// </summary>
        public void AddCustomer()
        {
            var customer = Customer.GenerateRandom();
            _customerQueue.Add(customer);
        }

        /// <summary>
        /// Добавление книги в шкаф
        /// </summary>
        /// <param name="genre">Жанр</param>
        /// <param name="book">Книга</param>
        /// <returns>Добавлена ли книга</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool AddBookToShelf(string genre, Book book, out string message)
        {
            message = "";
            var shelf = FindOrCreateShelf(genre);
            if (shelf == null)
            {
                message = "Нет места для нового жанра. Распродайте шкаф!";
                return false;
            }

            if (!shelf.HasSpace)
            {
                message = "В шкафу нет места. Книга останется в очереди";
                return false;
            }

            shelf.AddBook(book);
            message = $"Книга \"{book.Name}\" добавлена";
            return true;
        }

        /// <summary>
        /// Принятие книги из поставки
        /// </summary>
        /// <param name="book">Книга</param>
        /// <param name="isPlagiat">Флаг плагиата</param>
        /// <param name="isError">Флаг ошибки</param>
        /// <param name="fine">Штраф</param>
        /// <param name="message">Сообщение о результате</param>
        /// <returns>Принята ли книга</returns>
        public bool AcceptDelivery(Book book,
            bool isPlagiat,
            bool isError,
            out decimal fine,
            out string message)
        {
            message = "";
            fine = 0;

            if (!_deliveryQueue.Contains(book))
            {
                message = "Книга не найдена в очереди поставок.";
                return false;
            }

            // Списание денег
            if (Balance < book.BasePrice)
            {
                message = "Недостаточно средств!";
                return false;
            }

            Balance -= book.BasePrice;

            if (!AddBookToShelf(book.Genre, book, out message))
            {
                return false;
            }

            _deliveryQueue.Remove(book);

            if (isPlagiat || isError)
            {
                fine = 150;
                Balance -= fine;
                message = $"Книга содержит ошибки! Штраф: {fine}₽";
            }
            else
            {
                message = "Книга успешно принята!";
            }

            DeliveryQueue.Remove(book);

            return true;

        }

        /// <summary>
        /// Отклонение книги из поставки
        /// </summary>
        /// <param name="book">Книга</param>
        /// <param name="isPlagiat">Флаг плагиата</param>
        /// <param name="isError">Флаг ошибки</param>
        /// <param name="reward">Премия</param>
        /// <param name="message">Сообщение о результате</param>
        /// <returns>Отклонена ли книга</returns>
        public bool RejectDelivery(Book book,
            bool isPlagiat,
            bool isError,
            out decimal reward,
            out string message)
        {
            reward = 0;
            message = "";

            if (!_deliveryQueue.Contains(book))
            {
                message = "Книга не найдена в очереди";
                return false;
            }

            _deliveryQueue.Remove(book);

            // Премия за нахождение ошибки
            if (isPlagiat || isError)
            {
                reward = 100;
                Balance += reward;
                message = $"Ошибка найдена! Премия: {reward}₽";
            }
            else
            {
                message = "Книга отклонена";
            }

            DeliveryQueue.Remove(book);

            return true;
        }

        /// <summary>
        /// Продажа книги покупателю
        /// </summary>
        /// <param name="customer">Покупатель</param>
        /// <param name="book">Книга</param>
        /// <param name="sellPrice">Цена с наценкой</param>
        /// <param name="message">Сообщение о результате</param>
        /// <returns></returns>
        public bool SellToCustomer(Customer customer,
            Book book,
            decimal sellPrice,
            out string message)
        {
            message = "";

            // Проверка цены (не более 15% наценки)
            if (sellPrice > book.BasePrice * 1.15m)
            {
                message = "Цена превышает допустимую наценку 15%!";
                UnsatisfiedCustomers++;
                _customerQueue.Remove(customer);
                return false;
            }

            // Проверка соответствия запросу
            bool matchesRequest = customer.RequestType == CustomerRequestType.SpecificBook
                ? (string.Equals(book.Name, customer.DesiredName, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(book.Author, customer.DesiredAuthor, StringComparison.OrdinalIgnoreCase))
                : string.Equals(book.Genre, customer.DesiredGenre, StringComparison.OrdinalIgnoreCase);

            if (!matchesRequest)
            {
                message = "Книга не соответствует запросу покупателя!";
                UnsatisfiedCustomers++;
                _customerQueue.Remove(customer);
                return false;
            }

            // Продажа
            var shelf = _shelves.FirstOrDefault(s => s.Books.Contains(book));
            if (shelf == null)
            {
                message = "Книга не найдена в магазине!";
                return false;
            }

            Balance += sellPrice;
            shelf.RemoveBook(book);
            _customerQueue.Remove(customer);
            SatisfiedCustomers++;

            message = $"Книга продана за {sellPrice}₽!";
            return true;
        }

        public void NotSellToCustomer(Customer customer, out string message)
        {
            message = "Вы отказали покупателю!";
            UnsatisfiedCustomers++;
            _customerQueue.Remove(customer);
        }

        /// <summary>
        /// Продажа книги без покупателя (по базовой цене)
        /// </summary>
        /// <param name="book">Книга</param>
        /// <param name="message">Сообщение о результате</param>
        /// <returns></returns>
        public bool SellBook(Book book,
            out string message)
        {
            message = "";

            var shelf = _shelves.FirstOrDefault(s => s.Books.Contains(book));
            if (shelf == null)
            {
                message = "Книга не найдена!";
                return false;
            }

            Balance += book.BasePrice;
            shelf.RemoveBook(book);
            message = $"Книга продана за {book.BasePrice}₽!";
            return true;
        }

        /// <summary>
        /// Поиск или создание шкафа для жанра
        /// </summary>
        /// <param name="genre">Жанр</param>
        /// <returns>Шкаф</returns>
        private BookShelf FindOrCreateShelf(string genre)
        {
            var Shelf = _shelves.FirstOrDefault(s => string.Equals(s.Genre, genre, StringComparison.OrdinalIgnoreCase));

            if (Shelf != null && Shelf.HasSpace)
                return Shelf;

            var emptyShelf = _shelves.FirstOrDefault(s => s.Count == 0);
            if (emptyShelf != null)
            {
                emptyShelf.ChangeGenre(genre);
                return emptyShelf;
            }

            if (_shelves.Count < MaxShelves)
            {
                var newShelf = new BookShelf(genre);
                _shelves.Add(newShelf);
                return newShelf;
            }

            return null;
        }

        /// <summary>
        /// Получение книг по жанру
        /// </summary>
        /// <param name="genre">Жанр</param>
        /// <returns>Книги с таким жанром</returns>
        public List<Book> GetBooksByGenre(string genre)
        {
            var result = new List<Book>();
            foreach (var shelf in _shelves)
            {
                if (string.Equals(shelf.Genre, genre, StringComparison.OrdinalIgnoreCase))
                {
                    result.AddRange(shelf.Books);
                }
            }
            return result;
        }

        /// <summary>
        /// Получение всех жанров
        /// </summary>
        public List<string> GetAllGenres()
        {
            return _shelves.Select(s => s.Genre).ToList();
        }

        /// <summary>
        /// Проверка условия поражения
        /// </summary>
        /// <param name="maxQueueSize">Максимальная очередь</param>
        /// <param name="maxUnsatisfied">Максимальное кол-во разочарованных клиентов</param>
        /// <returns>(Поражение, Причина)</returns>
        public (bool IsGameOver, string Reason) CheckGameOver(int maxQueueSize, int maxUnsatisfied)
        {
            if (_customerQueue.Count > maxQueueSize)
                return (true, $"Очередь покупателей превышена: {_customerQueue.Count} > {maxQueueSize}");

            if (UnsatisfiedCustomers >= maxUnsatisfied)
                return (true, $"Слишком много недовольных клиентов: {UnsatisfiedCustomers}");

            if (Balance <= 0)
                return (true, "Баланс магазина исчерпан!");

            return (false, "");
        }

        /// <summary>
        /// Статистика игры
        /// </summary>
        public string GetStatistics()
        {
            return $"Баланс: {Balance}₽\n" +
                   $"Довольных клиентов: {SatisfiedCustomers}\n" +
                   $"Недовольных клиентов: {UnsatisfiedCustomers}\n" +
                   $"Шкафов: {_shelves.Count}/{MaxShelves}\n" +
                   $"Книг в магазине: {_shelves.Sum(s => s.Count)}";
        }

        /// <summary>
        /// Возвращает список всех жанров, для которых есть шкафы в магазине
        /// </summary>
        public List<string> GetAvailableGenres()
        {
            // Возвращаем жанры из всех шкафов, отсортированные по алфавиту
            return _shelves.Select(shelf => shelf.Genre)
                          .OrderBy(genre => genre)
                          .ToList();
        }

        public BookShelf FindCaseByGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
                return null;

            return _shelves.FirstOrDefault(shelf =>
                string.Equals(shelf.Genre, genre, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Ищет книгу по уникальному идентификатору во всех шкафах магазина.
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Найденная книга или null, если книга не найдена</returns>
        public Book FindBookById(int id)
        {
            foreach (var shelf in _shelves)
            {
                var found = shelf.FindById(id);
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
            foreach (var shelf in _shelves)
            {
                var found = shelf.FindByName(name);
                if (found != null)
                    return found;
            }
            return null;
            return _shelves.FirstOrDefault(shelf => shelf.FindByName(name) != null)?.Books.FirstOrDefault() ?? null;
        }

        /// <summary>
        /// Продажа книги (без покупателя, по базовой цене)
        /// </summary>
        /// <param name="book">Продаваемая книга</param>
        /// <exception cref="ArgumentNullException">Если книга null</exception>
        /// <exception cref="InvalidOperationException">
        /// Если книга уже продана, не найдена в магазине или находится в очереди поставок
        /// </exception>
        public void SellBook(Book book)
        {
            // Проверка на null
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Книга не может быть null");

            // Проверка, что книга ещё не продана
            if (book.IsSold)
                throw new InvalidOperationException($"Книга \"{book.Name}\" уже была продана ранее");

            // Проверка, что книга не в очереди поставок
            if (_deliveryQueue.Contains(book))
                throw new InvalidOperationException($"Книга \"{book.Name}\" ещё не принята в магазин. Сначала примите поставку.");

            // Ищем шкаф, содержащий эту книгу
            var shelf = _shelves.FirstOrDefault(s => s.Books.Contains(book));

            if (shelf == null)
                throw new InvalidOperationException($"Книга \"{book.Name}\" не найдена в магазине");

            bool removed = shelf.RemoveBook(book);

            if (!removed)
                throw new InvalidOperationException($"Не удалось удалить книгу \"{book.Name}\" из шкафа \"{shelf.Genre}\"");

            Balance += book.BasePrice;
            book.IsSold = true;
        }

        /*public void AddBookToStore(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "Книга не может быть null");

            // Проверяем, есть ли достаточно средств для покупки книги
            if (Balance < book.BasePrice)
                throw new InvalidOperationException($"Недостаточно средств для покупки книги. Нужно: {book.BasePrice:C}, доступно: {Balance:C}");

            // Находим или создаём шкаф для этого жанра
            var shelf = FindOrCreateShelf(book.Genre);

            if (shelf == null)
                throw new InvalidOperationException($"Нет места для нового жанра. Максимум шкафов: {MaxShelves}");

            if (!shelf.HasSpace)
                throw new InvalidOperationException($"В шкафу жанра '{book.Genre}' нет места. Вместимость: {shelf.Capacity}, занято: {shelf.Count}");

            // Добавляем книгу в шкаф
            shelf.AddBook(book);

            // Списываем стоимость книги с баланса
            Balance -= book.BasePrice;

            // Обновляем ID книги (если нужно)
            // book.Id = GetNextBookId(); // если требуется назначить новый ID
        }*/

    }
}