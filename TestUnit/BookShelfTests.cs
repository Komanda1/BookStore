using Bookstore;

namespace TestUnit
{
    [TestFixture]
    public class BookShelfTests
    {
        private BookShelf _shelf;
        private const string DefaultGenre = "Фантастика";
        private const int DefaultCapacity = 10;

        [SetUp]
        public void Setup()
        {
            _shelf = new BookShelf(DefaultGenre, DefaultCapacity);
        }

        [Test]
        public void Constructor_ValidParameters_SetsPropertiesCorrectly()
        { 
            string genre = "Детектив";
            int capacity = 15;

            var shelf = new BookShelf(genre, capacity);

            Assert.Multiple(() =>
            {
                Assert.That(shelf.Genre, Is.EqualTo(genre));
                Assert.That(shelf.Capacity, Is.EqualTo(capacity));
                Assert.That(shelf.Count, Is.EqualTo(0));
                Assert.That(shelf.HasSpace, Is.True);
                Assert.That(shelf.Books, Is.Empty);
            });
        }

        [Test]
        public void Constructor_DefaultCapacity_SetsCapacityTo10()
        {
            var shelf = new BookShelf("Роман");

            Assert.That(shelf.Capacity, Is.EqualTo(10));
        }

        [Test]
        public void Constructor_EmptyGenre_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new BookShelf("", 10));

            Assert.That(ex.Message, Does.Contain("Жанр должен иметь название"));
        }

        [Test]
        public void Constructor_WhitespaceGenre_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new BookShelf("   ", 10));
        }

        [Test]
        public void Constructor_ZeroCapacity_ThrowsArgumentException()
        {
            // ACT & ASSERT
            var ex = Assert.Throws<ArgumentException>(() =>
                new BookShelf("Фантастика", 0));

            Assert.That(ex.Message, Does.Contain("Вместимость должна быть больше 0"));
        }

        [Test]
        public void Constructor_NegativeCapacity_ThrowsArgumentException()
        {
            // ACT & ASSERT
            Assert.Throws<ArgumentException>(() =>
                new BookShelf("Фантастика", -5));
        }

        [Test]
        public void AddBook_ValidBook_AddsSuccessfully()
        {
            var book = TestHelpers.CreateTestBook(genre: DefaultGenre);
            book.SetId(1);

            _shelf.AddBook(book);

            Assert.Multiple(() =>
            {
                Assert.That(_shelf.Count, Is.EqualTo(1));
                Assert.That(_shelf.Books, Contains.Item(book));
                Assert.That(_shelf.HasSpace, Is.True);
            });
        }

        [Test]
        public void AddBook_NullBook_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _shelf.AddBook(null));
        }

        [Test]
        public void AddBook_WhenFull_ThrowsInvalidOperationException()
        {
            var smallShelf = new BookShelf(DefaultGenre, capacity: 1);
            var book1 = TestHelpers.CreateTestBook(genre: DefaultGenre);
            var book2 = TestHelpers.CreateTestBook(genre: DefaultGenre);
            book1.SetId(1);
            book2.SetId(2);
            smallShelf.AddBook(book1);

            var ex = Assert.Throws<InvalidOperationException>(() =>
                smallShelf.AddBook(book2));

            Assert.That(ex.Message, Is.EqualTo("В шкафу нет места"));
        }

        [Test]
        public void AddBook_WrongGenre_ThrowsInvalidOperationException()
        {
            var book = TestHelpers.CreateTestBook(genre: "Детектив");

            var ex = Assert.Throws<InvalidOperationException>(() =>
                _shelf.AddBook(book));

            Assert.That(ex.Message, Does.Contain("Книга должна быть жанра"));
            Assert.That(ex.Message, Does.Contain(DefaultGenre));
        }

        [Test]
        public void AddBook_SoldBook_ThrowsInvalidOperationException()
        {
            var book = TestHelpers.CreateTestBook(genre: DefaultGenre);
            book.Sell();

            var ex = Assert.Throws<InvalidOperationException>(() =>
                _shelf.AddBook(book));

            Assert.That(ex.Message, Is.EqualTo("Нельзя добавить уже проданную книгу"));
        }

        [Test]
        public void AddBook_MultipleBooks_IncreasesCount()
        {
            var book1 = TestHelpers.CreateTestBook(genre: DefaultGenre);
            var book2 = TestHelpers.CreateTestBook(genre: DefaultGenre);
            var book3 = TestHelpers.CreateTestBook(genre: DefaultGenre);
            book1.SetId(1);
            book2.SetId(2);
            book3.SetId(3);

            _shelf.AddBook(book1);
            _shelf.AddBook(book2);
            _shelf.AddBook(book3);

            Assert.That(_shelf.Count, Is.EqualTo(3));
        }

        [Test]
        public void FindById_ExistingBook_ReturnsBook()
        {
            var book = TestHelpers.CreateTestBook(genre: DefaultGenre);
            book.SetId(42);
            _shelf.AddBook(book);

            var found = _shelf.FindById(42);

            Assert.That(found, Is.EqualTo(book));
        }

        [Test]
        public void FindById_NonExistingBook_ReturnsNull()
        {
            var book = TestHelpers.CreateTestBook(genre: DefaultGenre);

            book.SetId(1);
            _shelf.AddBook(book);
            var found = _shelf.FindById(999);

            Assert.That(found, Is.Null);
        }

        [Test]
        public void FindByName_ExistingBook_ReturnsBook()
        {
            string bookName = "УникальноеНазваниеКниги";
            var book = TestHelpers.CreateTestBook(name: bookName, genre: DefaultGenre);
            book.SetId(1);
            _shelf.AddBook(book);

            var found = _shelf.FindByName(bookName);

            Assert.That(found, Is.EqualTo(book));
        }

        [Test]
        public void FindByName_StartsWith_ReturnsBook()
        {
            var book = TestHelpers.CreateTestBook(name: "Мастер и Маргарита", genre: DefaultGenre);
            book.SetId(1);
            _shelf.AddBook(book);

            var found = _shelf.FindByName("Мастер");

            Assert.That(found, Is.EqualTo(book));
        }

        [Test]
        public void FindByName_CaseInsensitive_ReturnsBook()
        {
            var book = TestHelpers.CreateTestBook(name: "Мастер и Маргарита", genre: DefaultGenre);
            book.SetId(1);
            _shelf.AddBook(book);

            var found = _shelf.FindByName("мастер");

            Assert.That(found, Is.EqualTo(book));
        }

        [Test]
        public void FindByName_NonExistingBook_ReturnsNull()
        {
            var book = TestHelpers.CreateTestBook(name: "Существующая книга", genre: DefaultGenre);
            book.SetId(1);
            _shelf.AddBook(book);

            var found = _shelf.FindByName("Несуществующая");

            Assert.That(found, Is.Null);
        }

        [Test]
        public void RemoveBook_ExistingBook_ReturnsTrue()
        {
            var book = TestHelpers.CreateTestBook(genre: DefaultGenre);
            book.SetId(1);
            _shelf.AddBook(book);

            bool removed = _shelf.RemoveBook(book);

            Assert.Multiple(() =>
            {
                Assert.That(removed, Is.True);
                Assert.That(_shelf.Count, Is.EqualTo(0));
                Assert.That(_shelf.Books, Does.Not.Contain(book));
            });
        }

        [Test]
        public void RemoveBook_NonExistingBook_ReturnsFalse()
        {
            var book = TestHelpers.CreateTestBook(genre: DefaultGenre);
            book.SetId(1);

            bool removed = _shelf.RemoveBook(book);

            Assert.That(removed, Is.False);
        }

        [Test]
        public void RemoveBook_NullBook_ThrowsException()
        {
            bool removed = _shelf.RemoveBook(null);

            Assert.That(removed, Is.False);
        }

        [Test]
        public void GetBooksInOrder_ReturnsBooksSortedById()
        {
            var book3 = TestHelpers.CreateTestBook(name: "Книга 3", genre: DefaultGenre);
            var book1 = TestHelpers.CreateTestBook(name: "Книга 1", genre: DefaultGenre);
            var book2 = TestHelpers.CreateTestBook(name: "Книга 2", genre: DefaultGenre);

            book1.SetId(1);
            book2.SetId(2);
            book3.SetId(3);

            _shelf.AddBook(book3);
            _shelf.AddBook(book1);
            _shelf.AddBook(book2);

            var ordered = _shelf.GetBooksInOrder().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(ordered.Count, Is.EqualTo(3));
                Assert.That(ordered[0].Id, Is.EqualTo(1));
                Assert.That(ordered[1].Id, Is.EqualTo(2));
                Assert.That(ordered[2].Id, Is.EqualTo(3));
            });
        }

        [Test]
        public void GetBooksInOrder_EmptyShelf_ReturnsEmptyList()
        {
            var ordered = _shelf.GetBooksInOrder();

            Assert.That(ordered, Is.Empty);
        }

        [Test]
        public void SellAll_WithMultipleBooks_ReturnsTotalSumAndClearsShelf()
        {
            var book1 = TestHelpers.CreateTestBook(genre: DefaultGenre, price: 100m);
            var book2 = TestHelpers.CreateTestBook(genre: DefaultGenre, price: 200m);
            var book3 = TestHelpers.CreateTestBook(genre: DefaultGenre, price: 300m);
            book1.SetId(1);
            book2.SetId(2);
            book3.SetId(3);

            _shelf.AddBook(book1);
            _shelf.AddBook(book2);
            _shelf.AddBook(book3);

            decimal total = _shelf.SellAll();

            Assert.Multiple(() =>
            {
                Assert.That(total, Is.EqualTo(600m));
                Assert.That(_shelf.Count, Is.EqualTo(0));
                Assert.That(_shelf.Books, Is.Empty);
                Assert.That(book1.IsSold, Is.True);
                Assert.That(book2.IsSold, Is.True);
                Assert.That(book3.IsSold, Is.True);
            });
        }

        [Test]
        public void SellAll_EmptyShelf_ReturnsZero()
        {
            decimal total = _shelf.SellAll();

            Assert.That(total, Is.EqualTo(0));
        }

        [Test]
        public void ChangeGenre_EmptyShelf_ChangesGenre()
        {
            string newGenre = "Детектив";

            _shelf.ChangeGenre(newGenre);

            Assert.That(_shelf.Genre, Is.EqualTo(newGenre));
        }

        [Test]
        public void ChangeGenre_NonEmptyShelf_ThrowsInvalidOperationException()
        {
            var book = TestHelpers.CreateTestBook(genre: DefaultGenre);
            book.SetId(1);
            _shelf.AddBook(book);

            var ex = Assert.Throws<InvalidOperationException>(() =>
                _shelf.ChangeGenre("Детектив"));

            Assert.That(ex.Message, Is.EqualTo("Нельзя сменить жанр непустого шкафа"));
        }

        [Test]
        public void ChangeGenre_EmptyGenre_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _shelf.ChangeGenre(""));

            Assert.That(ex.Message, Does.Contain("Необходимо указать название жанра"));
        }

        [Test]
        public void ChangeGenre_WhitespaceGenre_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                _shelf.ChangeGenre("   "));
        }

        [Test]
        public void ToString_ReturnsCorrectFormat()
        {
            var book1 = TestHelpers.CreateTestBook(genre: DefaultGenre);
            var book2 = TestHelpers.CreateTestBook(genre: DefaultGenre);
            book1.SetId(1);
            book2.SetId(2);
            _shelf.AddBook(book1);
            _shelf.AddBook(book2);

            string result = _shelf.ToString();

            Assert.That(result, Is.EqualTo($"{DefaultGenre} (2/{DefaultCapacity})"));
        }

        [Test]
        public void ToString_EmptyShelf_ReturnsCorrectFormat()
        {
            string result = _shelf.ToString();

            Assert.That(result, Is.EqualTo($"{DefaultGenre} (0/{DefaultCapacity})"));
        }
    }
}