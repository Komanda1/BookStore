using Bookstore;

namespace TestUnit
{
    public static class TestHelpers
    {
        public static Book CreateTestBook(
            string name = "Тестовая книга",
            string author = "Тестовый автор",
            string genre = "Фантастика",
            int pageNumber = 300,
            decimal price = 500m)
        {
            return new Book(name, author, genre, pageNumber, price);
        }
    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Library.Books.Clear();
        }

        [Test]
        public void CreatesBookCase()
        {
            string genre = "Фантастика";
            int capacity = 10;

            // Действие - выполняем тестируемый метод
            var bookCase = new BookCase(genre, capacity);

            // Проверка - проверяем, что результат правильный
            Assert.That(bookCase.Genre, Is.EqualTo(genre));
            Assert.That(bookCase.Capacity, Is.EqualTo(capacity));
            Assert.That(bookCase.HasSpace, Is.True);
            Assert.That(bookCase.OccupiedCount, Is.EqualTo(0));
        }

        [Test]
        public void EmptyGenre_ThrowsArgumentException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new BookCase("", 10));

            Assert.That(exception.Message, Does.Contain("не может быть пустым"));
        }

        [Test]
        public void ZeroCapacity_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new BookCase("Фантастика", 0));
        }

        [Test]
        public void AddBook()
        {
            // ARRANGE - используем хелпер
            var bookCase = new BookCase("Фантастика", 10);
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");

            // ACT
            bookCase.AddBook(book);

            // ASSERT
            Assert.That(bookCase.OccupiedCount, Is.EqualTo(1));
            Assert.That(bookCase.Books, Contains.Item(book));
        }

        [Test]
        public void AddBook_WhenFull_ThrowsInvalidOperationException()
        {
            // ARRANGE
            var bookCase = new BookCase("Фантастика", 1);
            var book1 = TestHelpers.CreateTestBook(name: "Книга 1", genre: "Фантастика");
            var book2 = TestHelpers.CreateTestBook(name: "Книга 2", genre: "Фантастика");

            bookCase.AddBook(book1);

            // ACT & ASSERT
            var exception = Assert.Throws<InvalidOperationException>(() =>
                bookCase.AddBook(book2));

            Assert.That(exception.Message, Is.EqualTo("В шкафу нет места."));
        }

        [Test]
        public void AddBook_WrongGenre_ThrowsInvalidOperationException()
        {
            // ARRANGE
            var bookCase = new BookCase("Фантастика", 10);
            var book = TestHelpers.CreateTestBook(genre: "История");

            // ACT & ASSERT
            var exception = Assert.Throws<InvalidOperationException>(() =>
                bookCase.AddBook(book));

            Assert.That(exception.Message, Is.EqualTo("Жанр книги не совпадает с жанром шкафа."));
        }

        [Test]
        public void AddBook_NullBook_ThrowsArgumentNullException()
        {
            // ARRANGE
            var bookCase = new BookCase("Фантастика", 10);

            // ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() =>
                bookCase.AddBook(null));
        }

        [Test]
        public void AddBook_SoldBook_ThrowsInvalidOperationException()
        {
            // ARRANGE
            var bookCase = new BookCase("Фантастика", 10);
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");

            book.Sell();

            // ACT & ASSERT
            var exception = Assert.Throws<InvalidOperationException>(() =>
                bookCase.AddBook(book));

            Assert.That(exception.Message, Is.EqualTo("Нельзя добавить проданную книгу."));
        }

        [Test]
        public void FindById_ExistingBook_ReturnsBook()
        {
            // ARRANGE
            var bookCase = new BookCase("Фантастика", 10);
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");

            // Сохраняем ID до добавления (он будет 1)
            bookCase.AddBook(book);
            int bookId = book.Id;

            // ACT
            var found = bookCase.FindById(bookId);

            // ASSERT
            Assert.That(found, Is.EqualTo(book));
        }

        [Test]
        public void FindById_NonExistingBook_ReturnsNull()
        {
            // ARRANGE
            var bookCase = new BookCase("Фантастика", 10);

            // ACT
            var found = bookCase.FindById(999);

            // ASSERT
            Assert.That(found, Is.Null);
        }

        [Test]
        public void FindByName_ExistingBook_ReturnsBook()
        {
            // ARRANGE
            var bookCase = new BookCase("Фантастика", 10);
            var book = TestHelpers.CreateTestBook(name: "Уникальное название", genre: "Фантастика");

            bookCase.AddBook(book);

            // ACT
            var found = bookCase.FindByName("Уникальное название");

            // ASSERT
            Assert.That(found, Is.EqualTo(book));
        }

        [Test]
        public void FindByName_NonExistingBook_ReturnsNull()
        {
            // ARRANGE
            var bookCase = new BookCase("Фантастика", 10);

            // ACT
            var found = bookCase.FindByName("Несуществующая книга");

            // ASSERT
            Assert.That(found, Is.Null);
        }

        [Test]
        public void ReassignGenre_EmptyCase_ChangesGenre()
        {
            // ARRANGE
            var bookCase = new BookCase("Фантастика", 10);
            string newGenre = "Детектив";

            // ACT
            bookCase.ReassignGenre(newGenre);

            // ASSERT
            Assert.That(bookCase.Genre, Is.EqualTo(newGenre));
        }

        [Test]
        public void ReassignGenre_NonEmptyCase_ThrowsInvalidOperationException()
        {
            // ARRANGE
            var bookCase = new BookCase("Фантастика", 10);
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            bookCase.AddBook(book);

            // ACT & ASSERT
            Assert.Throws<InvalidOperationException>(() =>
                bookCase.ReassignGenre("Детектив"));
        }

        [Test]
        public void ReassignGenre_EmptyGenre_ThrowsArgumentException()
        {
            // ARRANGE
            var bookCase = new BookCase("Фантастика", 10);

            // ACT & ASSERT
            Assert.Throws<ArgumentException>(() =>
                bookCase.ReassignGenre(""));
        }
    }

    [TestFixture]
    public class BookStoreTests
    {
        private BookStore _store;
        private const int DefaultMaxCases = 5;

        [SetUp]
        public void Setup()
        {
            // Очищаем статический список книг
            Library.Books.Clear();
            // Создаем новый магазин для каждого теста
            _store = new BookStore(DefaultMaxCases);
        }

        [Test]
        public void Constructor_ValidMaxCases_CreatesStore()
        {
            // ARRANGE
            int maxCases = 10;

            // ACT
            var store = new BookStore(maxCases);

            // ASSERT
            Assert.That(store.MaxCases, Is.EqualTo(maxCases));
            Assert.That(store.Cases, Is.Empty);
            Assert.That(store.Balance, Is.EqualTo(0));
            Assert.That(store.GetLastBookId(), Is.EqualTo(0));
        }

        [Test]
        public void Constructor_ZeroMaxCases_ThrowsArgumentException()
        {
            // ACT & ASSERT
            var exception = Assert.Throws<ArgumentException>(() =>
                new BookStore(0));

            Assert.That(exception.Message, Does.Contain("должно быть > 0"));
        }

        [Test]
        public void Constructor_NegativeMaxCases_ThrowsArgumentException()
        {
            // ACT & ASSERT
            Assert.Throws<ArgumentException>(() =>
                new BookStore(-1));
        }

        [Test]
        public void AddBookToStore_NewBook_CreatesCaseAndAddsBook()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");

            // ACT
            _store.AddBookToStore(book);

            // ASSERT
            Assert.That(_store.Cases.Count, Is.EqualTo(1));
            Assert.That(_store.Cases[0].Genre, Is.EqualTo("Фантастика"));
            Assert.That(_store.Cases[0].OccupiedCount, Is.EqualTo(1));
            Assert.That(_store.Cases[0].Books, Contains.Item(book));
            Assert.That(book.Id, Is.GreaterThan(0)); // ID должен быть назначен
        }

        [Test]
        public void AddBookToStore_MultipleBooksSameGenre_UsesSameCase()
        {
            // ARRANGE
            var book1 = TestHelpers.CreateTestBook(name: "Книга 1", genre: "Фантастика");
            var book2 = TestHelpers.CreateTestBook(name: "Книга 2", genre: "Фантастика");

            // ACT
            _store.AddBookToStore(book1);
            _store.AddBookToStore(book2);

            // ASSERT
            Assert.That(_store.Cases.Count, Is.EqualTo(1));
            Assert.That(_store.Cases[0].OccupiedCount, Is.EqualTo(2));
        }

        [Test]
        public void AddBookToStore_DifferentGenres_CreatesDifferentCases()
        {
            // ARRANGE
            var book1 = TestHelpers.CreateTestBook(genre: "Фантастика");
            var book2 = TestHelpers.CreateTestBook(genre: "Детектив");
            var book3 = TestHelpers.CreateTestBook(genre: "Роман");

            // ACT
            _store.AddBookToStore(book1);
            _store.AddBookToStore(book2);
            _store.AddBookToStore(book3);

            // ASSERT
            Assert.That(_store.Cases.Count, Is.EqualTo(3));
            Assert.That(_store.Cases.Select(c => c.Genre),
                Is.EquivalentTo(new[] { "Фантастика", "Детектив", "Роман" }));
        }

        [Test]
        public void AddBookToStore_WhenAllCasesFullAndMaxCasesReached_ThrowsException()
        {
            // ARRANGE
            // Заполняем все шкафы до максимума
            for (int i = 0; i < DefaultMaxCases; i++)
            {
                var book = TestHelpers.CreateTestBook(genre: $"Жанр{i}");
                _store.AddBookToStore(book, defaultCapacity: 1);
            }

            // Пытаемся добавить книгу нового жанра
            var extraBook = TestHelpers.CreateTestBook(genre: "Новый жанр");

            // ACT & ASSERT
            var exception = Assert.Throws<InvalidOperationException>(() =>
                _store.AddBookToStore(extraBook));

            Assert.That(exception.Message, Does.Contain("максимальное количество шкафов"));
        }

        [Test]
        public void AddBookToStore_NullBook_ThrowsArgumentNullException()
        {
            // ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() =>
                _store.AddBookToStore(null));
        }

        [Test]
        public void FindBookById_ExistingBook_ReturnsBook()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            _store.AddBookToStore(book);
            int bookId = book.Id;

            // ACT
            var found = _store.FindBookById(bookId);

            // ASSERT
            Assert.That(found, Is.EqualTo(book));
        }

        [Test]
        public void FindBookById_NonExistingBook_ReturnsNull()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            _store.AddBookToStore(book);

            // ACT
            var found = _store.FindBookById(999);

            // ASSERT
            Assert.That(found, Is.Null);
        }

        [Test]
        public void FindBookByName_ExistingBook_ReturnsBook()
        {
            // ARRANGE
            string uniqueName = "Совершенно уникальное название";
            var book = TestHelpers.CreateTestBook(name: uniqueName, genre: "Фантастика");
            _store.AddBookToStore(book);

            // ACT
            var found = _store.FindBookByName(uniqueName);

            // ASSERT
            Assert.That(found, Is.EqualTo(book));
        }

        [Test]
        public void FindBookByName_NonExistingBook_ReturnsNull()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            _store.AddBookToStore(book);

            // ACT
            var found = _store.FindBookByName("Несуществующая книга");

            // ASSERT
            Assert.That(found, Is.Null);
        }

        [Test]
        public void FindBookByName_CaseInsensitive_ReturnsBook()
        {
            // ARRANGE
            string uniqueName = "Уникальное Название";
            var book = TestHelpers.CreateTestBook(name: uniqueName, genre: "Фантастика");
            _store.AddBookToStore(book);

            // ACT - ищем с другим регистром
            var found = _store.FindBookByName("уникальное название");

            // ASSERT
            Assert.That(found, Is.EqualTo(book));
        }

        [Test]
        public void SellBook_ExistingBook_RemovesBookAndAddsToBalance()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика", price: 500m);
            _store.AddBookToStore(book);
            decimal initialBalance = _store.Balance;

            // ACT
            _store.SellBook(book);

            // ASSERT
            Assert.That(_store.Balance, Is.EqualTo(initialBalance + 500m));
            Assert.That(book.IsSold, Is.True);

            // Книга должна быть удалена из шкафа
            var found = _store.FindBookById(book.Id);
            Assert.That(found, Is.Null);
        }

        [Test]
        public void SellBook_BookNotInStore_ThrowsInvalidOperationException()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            // НЕ добавляем книгу в магазин

            // ACT & ASSERT
            var exception = Assert.Throws<InvalidOperationException>(() =>
                _store.SellBook(book));

            Assert.That(exception.Message, Is.EqualTo("Книга не найдена в магазине."));
        }

        [Test]
        public void SellBook_NullBook_ThrowsArgumentNullException()
        {
            // ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() =>
                _store.SellBook(null));
        }

        [Test]
        public void SellBook_AlreadySoldBook_ThrowsInvalidOperationException()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            _store.AddBookToStore(book);

            // Продаем первый раз
            _store.SellBook(book);

            // ACT & ASSERT - пытаемся продать снова
            var exception = Assert.Throws<InvalidOperationException>(() =>
                _store.SellBook(book));

            Assert.That(exception.Message, Is.EqualTo("Книга не найдена в магазине."));
        }

        [Test]
        public void FindCaseByGenre_ExistingGenre_ReturnsCase()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            _store.AddBookToStore(book);

            // ACT
            var found = _store.FindCaseByGenre("Фантастика");

            // ASSERT
            Assert.That(found, Is.Not.Null);
            Assert.That(found.Genre, Is.EqualTo("Фантастика"));
        }

        [Test]
        public void FindCaseByGenre_NonExistingGenre_ReturnsNull()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            _store.AddBookToStore(book);

            // ACT
            var found = _store.FindCaseByGenre("Несуществующий жанр");

            // ASSERT
            Assert.That(found, Is.Null);
        }

        [Test]
        public void FindCaseByGenre_EmptyGenre_ThrowsArgumentException()
        {
            // ACT & ASSERT
            Assert.Throws<ArgumentException>(() =>
                _store.FindCaseByGenre(""));
        }

        [Test]
        public void GetAvailableGenres_ReturnsDistinctGenres()
        {
            // ARRANGE
            _store.AddBookToStore(TestHelpers.CreateTestBook(genre: "Фантастика"));
            _store.AddBookToStore(TestHelpers.CreateTestBook(genre: "Фантастика"));
            _store.AddBookToStore(TestHelpers.CreateTestBook(genre: "Детектив"));
            _store.AddBookToStore(TestHelpers.CreateTestBook(genre: "Роман"));
            _store.AddBookToStore(TestHelpers.CreateTestBook(genre: "Роман"));

            // ACT
            var genres = _store.GetAvailableGenres();

            // ASSERT
            Assert.That(genres.Count, Is.EqualTo(3));
            Assert.That(genres, Is.EquivalentTo(new[] { "Фантастика", "Детектив", "Роман" }));
        }

        [Test]
        public void RemoveCase_EmptyCase_RemovesSuccessfully()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            _store.AddBookToStore(book);
            var fantasyCase = _store.FindCaseByGenre("Фантастика");

            // Продаем книгу - шкаф становится пустым
            _store.SellBook(book);

            // ACT
            _store.RemoveCase(fantasyCase);

            // ASSERT
            Assert.That(_store.Cases, Does.Not.Contain(fantasyCase));
            Assert.That(_store.Cases.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveCase_NonEmptyCase_ThrowsInvalidOperationException()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            _store.AddBookToStore(book);
            var fantasyCase = _store.FindCaseByGenre("Фантастика");

            // ACT & ASSERT
            var exception = Assert.Throws<InvalidOperationException>(() =>
                _store.RemoveCase(fantasyCase));

            Assert.That(exception.Message, Does.Contain("Нельзя удалить шкаф, пока в нём есть книги."));
        }

        [Test]
        public void RemoveCase_NullCase_ThrowsArgumentNullException()
        {
            // ACT & ASSERT
            Assert.Throws<ArgumentNullException>(() =>
                _store.RemoveCase(null));
        }

        [Test]
        public void CreateOrReuseCase_ExistingGenre_ReturnsExistingCase()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            _store.AddBookToStore(book);
            var originalCase = _store.FindCaseByGenre("Фантастика");

            // ACT
            var result = _store.CreateOrReuseCase("Фантастика");

            // ASSERT
            Assert.That(result, Is.EqualTo(originalCase));
        }

        [Test]
        public void CreateOrReuseCase_EmptyCaseAvailable_ReusesAndChangesGenre()
        {
            // ARRANGE
            var book = TestHelpers.CreateTestBook(genre: "Фантастика");
            _store.AddBookToStore(book);
            var fantasyCase = _store.FindCaseByGenre("Фантастика");

            // Продаем книгу - шкаф пустой
            _store.SellBook(book);

            // ACT - запрашиваем шкаф для другого жанра
            var result = _store.CreateOrReuseCase("Детектив");

            // ASSERT
            Assert.That(result, Is.EqualTo(fantasyCase));
            Assert.That(result.Genre, Is.EqualTo("Детектив"));
            Assert.That(_store.Cases.Count, Is.EqualTo(1));
        }

        [Test]
        public void CreateOrReuseCase_NewGenre_CreatesNewCase()
        {
            // ARRANGE
            _store.AddBookToStore(TestHelpers.CreateTestBook(genre: "Фантастика"));

            // ACT
            var result = _store.CreateOrReuseCase("Детектив", defaultCapacity: 15);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Genre, Is.EqualTo("Детектив"));
            Assert.That(result.Capacity, Is.EqualTo(15));
            Assert.That(_store.Cases.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetLastBookId_AfterAddingBooks_ReturnsCorrectId()
        {
            // ARRANGE
            Assert.That(_store.GetLastBookId(), Is.EqualTo(0));

            var book1 = TestHelpers.CreateTestBook(genre: "Фантастика");
            _store.AddBookToStore(book1);

            // ACT
            int lastId = _store.GetLastBookId();

            // ASSERT
            Assert.That(lastId, Is.EqualTo(book1.Id));

            // Добавляем еще книгу
            var book2 = TestHelpers.CreateTestBook(genre: "Детектив");
            _store.AddBookToStore(book2);

            Assert.That(_store.GetLastBookId(), Is.EqualTo(book2.Id));
        }
    }
}