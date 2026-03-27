using Bookstore;

namespace TestUnit
{
    [TestFixture]
    public class BookStoreTests
    {
        private BookStore _store;
        private const int DefaultMaxShelves = 5;
        private const decimal DefaultBalance = 1000m;

        [SetUp]
        public void Setup()
        {
            _store = new BookStore(DefaultMaxShelves, DefaultBalance);
        }

        [Test]
        public void Constructor_ValidParameters_CreatesStore()
        {
            int maxShelves = 10;
            decimal balance = 2000m;

            var store = new BookStore(maxShelves, balance);

            Assert.Multiple(() =>
            {
                Assert.That(store.MaxShelves, Is.EqualTo(maxShelves));
                Assert.That(store.Balance, Is.EqualTo(balance));
                Assert.That(store.Shelves, Is.Empty);
                Assert.That(store.DeliveryQueue, Is.Empty);
                Assert.That(store.CustomerQueue, Is.Empty);
                Assert.That(store.UnsatisfiedCustomers, Is.EqualTo(0));
                Assert.That(store.SatisfiedCustomers, Is.EqualTo(0));
            });
        }

        [Test]
        public void Constructor_DefaultBalance_SetsBalanceTo1000()
        {
            var store = new BookStore(5);

            Assert.That(store.Balance, Is.EqualTo(1000m));
        }

        [Test]
        public void Constructor_ZeroMaxShelves_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new BookStore(0, 1000m));

            Assert.That(ex.Message, Does.Contain("Максимальное количество шкафов должно быть больше 0"));
        }

        [Test]
        public void Constructor_NegativeMaxShelves_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new BookStore(-5, 1000m));
        }

        [Test]
        public void Constructor_NegativeBalance_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new BookStore(5, -100m));

            Assert.That(ex.Message, Does.Contain("Баланс не может быть отрицательным"));
        }

        [Test]
        public void OrderBook_ValidBook_ReturnsTrueAndDeductsBalance()
        {
            decimal initialBalance = _store.Balance;

            bool result = _store.OrderBook("1984", "Оруэлл", "Фантастика", 300, 500m, out string message);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(message, Is.Empty);
                Assert.That(_store.Balance, Is.EqualTo(initialBalance - 500m));
                Assert.That(_store.DeliveryQueue.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void OrderBook_EmptyName_ReturnsFalseWithMessage()
        {
            bool result = _store.OrderBook("", "Оруэлл", "Фантастика", 300, 500m, out string message);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.False);
                Assert.That(message, Is.EqualTo("Название книги не может быть пустым"));
            });
        }

        [Test]
        public void OrderBook_EmptyAuthor_ReturnsFalseWithMessage()
        {
            bool result = _store.OrderBook("1984", "", "Фантастика", 300, 500m, out string message);

            Assert.That(result, Is.False);
            Assert.That(message, Is.EqualTo("Автор книги не может быть пустым"));
        }

        [Test]
        public void OrderBook_ZeroPages_ReturnsFalseWithMessage()
        {
            bool result = _store.OrderBook("1984", "Оруэлл", "Фантастика", 0, 500m, out string message);

            Assert.That(result, Is.False);
            Assert.That(message, Is.EqualTo("Количество страниц должно быть положительным"));
        }

        [Test]
        public void OrderBook_NegativePages_ReturnsFalseWithMessage()
        {
            bool result = _store.OrderBook("1984", "Оруэлл", "Фантастика", -50, 500m, out string message);

            Assert.That(result, Is.False);
            Assert.That(message, Is.EqualTo("Количество страниц должно быть положительным"));
        }

        [Test]
        public void OrderBook_ZeroPrice_ReturnsFalseWithMessage()
        {
            bool result = _store.OrderBook("1984", "Оруэлл", "Фантастика", 300, 0m, out string message);

            Assert.That(result, Is.False);
            Assert.That(message, Is.EqualTo("Цена должна быть положительной"));
        }

        [Test]
        public void OrderBook_InsufficientBalance_ReturnsFalseWithMessage()
        {
            var store = new BookStore(5, 100m);

            bool result = store.OrderBook("1984", "Оруэлл", "Фантастика", 300, 500m, out string message);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.False);
                Assert.That(message, Is.EqualTo("У вас недостаточно средств на балансе"));
                Assert.That(store.Balance, Is.EqualTo(100m));
            });
        }

        [Test]
        public void AddRandomDelivery_AddsBookToQueue()
        {
            _store.AddRandomDelivery();

            Assert.That(_store.DeliveryQueue.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddCustomer_AddsCustomerToQueue()
        {
            _store.AddCustomer();

            Assert.That(_store.CustomerQueue.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddBookToShelf_NewGenre_CreatesNewShelf()
        {
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");

            bool result = _store.AddBookToShelf("Фантастика", book, out string message);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(message, Does.Contain("добавлена"));
                Assert.That(_store.Shelves.Count, Is.EqualTo(1));
                Assert.That(_store.Shelves[0].Genre, Is.EqualTo("Фантастика"));
            });
        }

        [Test]
        public void GetBooksByGenre_ReturnsCorrectBooks()
        {
            var book1 = TestHelpers.CreateTestBook(genre: "Фантастика");
            var book2 = TestHelpers.CreateTestBook(genre: "Фантастика");
            var book3 = TestHelpers.CreateTestBook(genre: "Детектив");

            _store.AddBookToShelf("Фантастика", book1, out _);
            _store.AddBookToShelf("Фантастика", book2, out _);
            _store.AddBookToShelf("Детектив", book3, out _);

            var fantasyBooks = _store.GetBooksByGenre("Фантастика");

            Assert.Multiple(() =>
            {
                Assert.That(fantasyBooks.Count, Is.EqualTo(2));
                Assert.That(fantasyBooks, Contains.Item(book1));
                Assert.That(fantasyBooks, Contains.Item(book2));
                Assert.That(fantasyBooks, Does.Not.Contain(book3));
            });
        }

        [Test]
        public void GetAvailableGenres_ReturnsAllGenres()
        {
            _store.AddBookToShelf("Фантастика", TestHelpers.CreateTestBook(genre: "Фантастика"), out _);
            _store.AddBookToShelf("Детектив", TestHelpers.CreateTestBook(genre: "Детектив"), out _);
            _store.AddBookToShelf("Роман", TestHelpers.CreateTestBook(genre: "Роман"), out _);

            var genres = _store.GetAvailableGenres();

            Assert.That(genres, Is.EquivalentTo(new[] { "Детектив", "Роман", "Фантастика" }));
        }

        [Test]
        public void FindBookById_ExistingBook_ReturnsBook()
        {
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            book.SetId(42);
            _store.AddBookToShelf("Фантастика", book, out _);

            var found = _store.FindBookById(42);

            Assert.That(found, Is.EqualTo(book));
        }

        [Test]
        public void FindBookById_NonExistingBook_ReturnsNull()
        {
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            book.SetId(1);
            _store.AddBookToShelf("Фантастика", book, out _);

            var found = _store.FindBookById(999);

            Assert.That(found, Is.Null);
        }

        [Test]
        public void SellBook_ExistingBook_RemovesBookAndAddsToBalance()
        {
            var book = TestHelpers.CreateTestBook(genre: "Фантастика", price: 500m);
            book.SetId(1);
            _store.AddBookToShelf("Фантастика", book, out _);
            decimal initialBalance = _store.Balance;

            _store.SellBook(book);

            Assert.Multiple(() =>
            {
                Assert.That(_store.Balance, Is.EqualTo(initialBalance + 500m));
                Assert.That(book.IsSold, Is.True);
            });
        }

        [Test]
        public void SellBook_NullBook_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
                _store.SellBook(null));

            Assert.That(ex.Message, Does.Contain("Книга не может быть null"));
        }

        [Test]
        public void SellBook_AlreadySoldBook_ThrowsInvalidOperationException()
        {
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            book.SetId(1);
            _store.AddBookToShelf("Фантастика", book, out _);
            _store.SellBook(book);

            var ex = Assert.Throws<InvalidOperationException>(() =>
                _store.SellBook(book));

            Assert.That(ex.Message, Does.Contain("уже была продана"));
        }

        [Test]
        public void CheckGameOver_BalanceZero_ReturnsGameOver()
        {
            var store = new BookStore(5, 0);

            var (isGameOver, reason) = store.CheckGameOver(10, 5);

            Assert.Multiple(() =>
            {
                Assert.That(isGameOver, Is.True);
                Assert.That(reason, Does.Contain("Баланс магазина исчерпан"));
            });
        }

        [Test]
        public void CheckGameOver_QueueTooLong_ReturnsGameOver()
        {
            for (int i = 0; i < 6; i++)
            {
                _store.AddCustomer();
            }

            var (isGameOver, reason) = _store.CheckGameOver(5, 10);

            Assert.Multiple(() =>
            {
                Assert.That(isGameOver, Is.True);
                Assert.That(reason, Does.Contain("Очередь покупателей превышена"));
            });
        }

        [Test]
        public void CheckGameOver_AllConditionsOk_ReturnsNotGameOver()
        {
            var (isGameOver, reason) = _store.CheckGameOver(10, 5);

            Assert.Multiple(() =>
            {
                Assert.That(isGameOver, Is.False);
                Assert.That(reason, Is.Empty);
            });
        }

        [Test]
        public void GetStatistics_ReturnsNonEmptyString()
        {
            string stats = _store.GetStatistics();

            Assert.That(stats, Is.Not.Null.And.Not.Empty);
            Assert.That(stats, Does.Contain("Баланс"));
            Assert.That(stats, Does.Contain("Довольных клиентов"));
            Assert.That(stats, Does.Contain("Недовольных клиентов"));
        }
    }
}