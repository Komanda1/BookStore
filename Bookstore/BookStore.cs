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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bookstore
{
    /// <summary>
    /// Класс книжного магазина
    /// </summary>
    public class BookStore
    {
        private List<BookShelf> shelves = new List<BookShelf>();
        private List<Book> deliveryQueue = new List<Book>();
        private List<Customer> customerQueue = new List<Customer>();
        private List<(string Name, string Author)> database = new List<(string, string)>();
        public int MaxShelves { get; }
        public decimal Balance { get; set; }
        public int UnsatisfiedCustomers { get; set; }
        public int SatisfiedCustomers { get; set; }
        public List<Book> DeliveryQueue => deliveryQueue;
        public List<Customer> CustomerQueue => customerQueue;
        public List<BookShelf> Shelves => shelves;
        /// <summary>
        /// Конструктор магазина
        /// </summary>
        /// <param name="maxShelves"> максимальное кол-во шкафов </param>
        /// <param name="startBalance"> начальный баланс </param>
        /// <exception cref="ArgumentException"></exception>
        public BookStore(int maxShelves, decimal startBalance = 1000)
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
                    database.Add((parts[0].Trim(), parts[1].Trim()));
                }
            }
            
        }

        /// <summary>
        /// Заказ конкретной книги
        /// </summary>
        /// <param name="name"> название книги </param>
        /// <param name="author"> автор </param>
        /// <param name="genre"> жанр</param>
        /// <param name="pages"> кол-во страниц </param>
        /// <param name="price"> цена </param>
        /// <param name="message"> сообщение о результате </param>
        /// <returns></returns>
        public bool OrderBook(string name, string author, string genre, int pages, decimal price, out string message)
        {
            message = "";
            if (Balance < price)
                message="У вас недостаточно средств на балансе";
                return false;

            Balance -= price;

            var book = new Book(name, author, genre, pages, price);
            deliveryQueue.Add(book);

            database.Add((name, author));
            SaveNewBookToDatabase(name, author);
            return true;
        }

        /// <summary>
        /// Добавление случайной книги в очередь поставок
        /// </summary>
        public void AddRandomDelivery()
        {
            var book = Book.CreateWithPossibleError();
            deliveryQueue.Add(book);
        }

        /// <summary>
        /// Добавление покупателя в очередь
        /// </summary>
        public void AddCustomer()
        {
            var customer = Customer.GenerateRandom();
            customerQueue.Add(customer);
        }

        /// <summary>
        /// Принятие книги из поставки
        /// </summary>
        /// <param name="book"> книга </param>
        /// <param name="message"> сообщение о результате</param>
        /// <returns></returns>
        public bool AcceptDelivery(Book book, out string message)
        {
            message = "";

            if (!deliveryQueue.Contains(book))
            {
                message = "Книга не найдена в очереди поставок.";
                return false;
            }

            // Проверка на плагиат/опечатку
            if (book.IsPlagiat || book.IsError)
            {
                message = "ВНИМАНИЕ: Книга содержит ошибки!";
                // Принимаем, но с пометкой
            }

            // Поиск или создание шкафа
            var shelf = FindOrCreateShelf(book.Genre);

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

            // Списание денег
            if (Balance < book.BasePrice)
            {
                message = "Недостаточно средств!";
                return false;
            }

            Balance -= book.BasePrice;
            shelf.AddBook(book);
            deliveryQueue.Remove(book);

            message = "Книга успешно принята!";
            return true;
        }

        /// <summary>
        /// Отклонение книги из поставки
        /// </summary>
        /// <param name="book"> книга </param>
        /// <param name="isPlagiat"> флаг плагиата </param>
        /// <param name="isError"> флаг ошибки </param>
        /// <param name="reward"> премия </param>
        /// <param name="message"> сообщение о результате </param>
        /// <returns></returns>
        public bool RejectDelivery(Book book, bool isPlagiat, bool isError, out decimal reward, out string message)
        {
            reward = 0;
            message = "";

            if (!deliveryQueue.Contains(book))
            {
                message = "Книга не найдена в очереди";
                return false;
            }

            deliveryQueue.Remove(book);

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

            return true;
        }

        /// <summary>
        ///  Продажа книги покупателю
        /// </summary>
        /// <param name="customer"> покупатель </param>
        /// <param name="book"> книга </param>
        /// <param name="sellPrice"> цена с наценкой </param>
        /// <param name="message"> сообщение о результате </param>
        /// <returns></returns>
        public bool SellToCustomer(Customer customer, Book book, decimal sellPrice, out string message)
        {
            message = "";

            // Проверка цены (не более 15% наценки)
            if (sellPrice > book.BasePrice * 1.15m)
            {
                message = "Цена превышает допустимую наценку 15%!";
                UnsatisfiedCustomers++;
                customerQueue.Remove(customer);
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
                customerQueue.Remove(customer);
                return false;
            }

            // Продажа
            var shelf = shelves.FirstOrDefault(s => s.Books.Contains(book));
            if (shelf == null)
            {
                message = "Книга не найдена в магазине!";
                return false;
            }

            Balance += sellPrice;
            shelf.RemoveBook(book);
            customerQueue.Remove(customer);
            SatisfiedCustomers++;

            message = $"Книга продана за {sellPrice}₽!";
            return true;
        }

        /// <summary>
        /// Продажа книги без покупателя (по базовой цене)
        /// </summary>
        /// <param name="book"> книга </param>
        /// <param name="message"> сообщение о результате </param>
        /// <returns></returns>
        public bool SellBook(Book book, out string message)
        {
            message = "";

            var shelf = shelves.FirstOrDefault(s => s.Books.Contains(book));
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
        ///  Поиск или создание шкафа для жанра
        /// </summary>
        /// <param name="genre"> жанр </param>
        /// <returns></returns>
        private BookShelf FindOrCreateShelf(string genre)
        {
            var Shelf = shelves.FirstOrDefault(s => string.Equals(s.Genre, genre, StringComparison.OrdinalIgnoreCase));

            if (Shelf != null && Shelf.HasSpace)
                return Shelf;

            var emptyShelf = shelves.FirstOrDefault(s => s.Count == 0);
            if (emptyShelf != null)
            {
                emptyShelf.ChangeGenre(genre);
                return emptyShelf;
            }

            if (shelves.Count < MaxShelves)
            {
                var newShelf = new BookShelf(genre);
                shelves.Add(newShelf);
                return newShelf;
            }

            return null;
        }

        /// <summary>
        /// Получение книг по жанру
        /// </summary>
        /// <param name="genre"> жанр </param>
        /// <returns></returns>
        public List<Book> GetBooksByGenre(string genre)
        {
            var result = new List<Book>();
            foreach (var shelf in shelves)
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
            return shelves.Select(s => s.Genre).ToList();
        }

        /// <summary>
        /// Сохранение новой книги в файл
        /// </summary>
        /// <param name="name"> название книги </param>
        /// <param name="author"> автор </param>
        private void SaveNewBookToDatabase(string name, string author)
        {
            File.AppendAllText("NameAuthor.txt", $"{Environment.NewLine}{name} | {author}");
        }

        /// <summary>
        /// Проверка условия поражения
        /// </summary>
        /// <param name="maxQueueSize"> максимальная очередь </param>
        /// <param name="maxUnsatisfied"> максимальное кол-во разочарованных клиентов </param>
        /// <returns></returns>
        public (bool IsGameOver, string Reason) CheckGameOver(int maxQueueSize, int maxUnsatisfied)
        {
            if (customerQueue.Count > maxQueueSize)
                return (true, $"Очередь покупателей превышена: {customerQueue.Count} > {maxQueueSize}");

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
                   $"Шкафов: {shelves.Count}/{MaxShelves}\n" +
                   $"Книг в магазине: {shelves.Sum(s => s.Count)}";
        }
    }
}