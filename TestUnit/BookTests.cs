using Bookstore;
using NuGet.Frameworks;
using NUnit.Framework.Constraints;

namespace TestUnit
{
    [TestFixture]
    public class BookTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Constructor_WithAllParameters_SetsPropertiesCorrectly()
        {
            string name = "1984";
            string author = "Джордж Оруэлл";
            string genre = "Фантастика";
            int pages = 328;
            decimal price = 500m;

            var book = new Book(name, author, genre, pages, price);

            Assert.Multiple(() =>
            {
                Assert.That(book.Name, Is.EqualTo(name));
                Assert.That(book.Author, Is.EqualTo(author));
                Assert.That(book.Genre, Is.EqualTo(genre));
                Assert.That(book.PageNumber, Is.EqualTo(pages));
                Assert.That(book.BasePrice, Is.EqualTo(price));
                Assert.That(book.SellPrice, Is.EqualTo(price));
                Assert.That(book.IsSold, Is.False);
                Assert.That(book.IsPlagiat, Is.False);
                Assert.That(book.IsError, Is.False);
                Assert.That(book.IsOrdered, Is.False);
            });
        }

        [Test]
        public void Constructor_WithIsOrderedTrue_SetsIsOrderedCorrectly()
        {
            var book = new Book("Книга", "Автор", "Жанр", 100, 500m, isOrdered: true);

            Assert.That(book.IsOrdered, Is.True);
        }

        [Test]
        public void Constructor_WithIsOrderedFalse_SetsIsOrderedCorrectly()
        {
            var book = new Book("Книга", "Автор", "Жанр", 100, 500m, isOrdered: false);

            Assert.That(book.IsOrdered, Is.False);
        }

        [Test]
        public void Constructor_EmptyAuthor_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Book("Название", "", "Жанр", 100, 500m));

            Assert.That(ex.Message, Does.Contain("Название, автор и жанр не могут быть пустыми"));
        }

        [Test]
        public void Constructor_EmptyName_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Book("", "Автор", "Жанр", 100, 500m));

            Assert.That(ex.Message, Does.Contain("Название, автор и жанр не могут быть пустыми"));
        }

        [Test]
        public void Constructor_EmptyGenre_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Book("Название", "Автор", "", 100, 500m));

            Assert.That(ex.Message, Does.Contain("Название, автор и жанр не могут быть пустыми"));
        }

        [Test]
        public void Constructor_WhitespaceNmae_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Book("   ", "Автор", "", 100, 500m));
        }

        [Test]
        public void Constructor_ZeroPages_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Book("Название", "Автор", "Жанр", 0, 500m));

            Assert.That(ex.Message, Does.Contain("Количество страниц должно быть больше 0"));
        }

        [Test]
        public void Constructor_NegativePages_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Book("Название", "Автор", "Жанр", -10, 500m));
        }

        [Test]
        public void Constructor_ZeroPrice_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Book("Название", "Автор", "Жанр", 100, 0m));

            Assert.That(ex.Message, Does.Contain("Цена должна быть больше 0"));
        }

        [Test]
        public void Constructor_NegativePrice_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Book("Название", "Автор", "Жанр", 100, -50m));
        }

        [Test]
        public void Constructor_NoParameters_GeneratesRandomData()
        {
            var book = new Book();

            Assert.Multiple(() =>
            {
                Assert.That(book.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(book.Author, Is.Not.Null.And.Not.Empty);
                Assert.That(book.Genre, Is.Not.Null.And.Not.Empty);
                Assert.That(book.PageNumber, Is.InRange(50, 1000));
                Assert.That(book.BasePrice, Is.InRange(100, 1500));
                Assert.That(book.IsSold, Is.False);
                Assert.That(book.IsPlagiat, Is.False);
                Assert.That(book.IsError, Is.False);
                Assert.That(book.IsOrdered, Is.False);
            });
        }


        [Test]
        public void Sell_NewBook_MarksAsSoldAndReturnsPrice()
        {
            var book = new Book("Тест", "Автор", "Жанр", 100, 500m);

            decimal income = book.Sell();

            Assert.Multiple(() =>
            {
                Assert.That(income, Is.EqualTo(500m));
                Assert.That(book.IsSold, Is.True);
            });
        }

        [Test]
        public void Sell_AlreadySoldBook_ThrowsInvalidOperationException()
        {
            var book = new Book("Тест", "Автор", "Жанр", 100, 500m);
            book.Sell();

            var ex = Assert.Throws<InvalidOperationException>(() => book.Sell());
            Assert.That(ex.Message, Is.EqualTo("Книга уже продана"));
        }

        [Test]
        public void Sell_DoesNotChangeOtherProperties()
        {
            var book = new Book("1984", "Оруэлл", "Фантастика", 328, 500m);

            book.Sell();

            Assert.Multiple(() =>
            {
                Assert.That(book.Name, Is.EqualTo("1984"));
                Assert.That(book.Author, Is.EqualTo("Оруэлл"));
                Assert.That(book.Genre, Is.EqualTo("Фантастика"));
                Assert.That(book.PageNumber, Is.EqualTo(328));
                Assert.That(book.BasePrice, Is.EqualTo(500m));
            });
        }

        [Test]
        public void CheckPlagiat_SameNameDifferentAuthor_ReturnsTrue()
        {
            var book1 = new Book("1984", "Оруэлл", "Фантастика", 300, 500m);
            var book2 = new Book("1984", "Не Оруэлл", "Фантастика", 300, 500m);

            bool isPlagiat = book1.CheckPlagiat(book2);

            Assert.That(isPlagiat, Is.True);
        }

        [Test]
        public void CheckPlagiat_SameNameSameAuthor_ReturnsFalse()
        {
            var book1 = new Book("1984", "Оруэлл", "Фантастика", 300, 500m);
            var book2 = new Book("1984", "Оруэлл", "Фантастика", 300, 500m);

            bool isPlagiat = book1.CheckPlagiat(book2);

            Assert.That(isPlagiat, Is.False);
        }

        [Test]
        public void CheckPlagiat_CaseInsensitive_ReturnsTrue()
        {
            var book1 = new Book("1984", "Оруэлл", "Фантастика", 300, 500m);
            var book2 = new Book("1984", "другой автор", "Фантастика", 300, 500m);

            bool isPlagiat = book1.CheckPlagiat(book2);

            Assert.That(isPlagiat, Is.True);
        }

        [Test]
        public void GenerateRandom_SetsAllFields()
        {
            var book = new Book("Старое имя", "Старый автор", "Старый жанр", 100, 100m);

            book.GenerateRandom();

            Assert.Multiple(() =>
            {
                Assert.That(book.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(book.Author, Is.Not.Null.And.Not.Empty);
                Assert.That(book.Genre, Is.Not.Null.And.Not.Empty);
                Assert.That(book.PageNumber, Is.InRange(50, 1000));
                Assert.That(book.BasePrice, Is.InRange(100, 1500));
                Assert.That(book.IsSold, Is.False);
                Assert.That(book.IsPlagiat, Is.False);
                Assert.That(book.IsError, Is.False);
            });
        }

        [Test]
        public void CreateWithPossibleError_AlwaysReturnsNonNullBook()
        {
            var book = Book.CreateWithPossibleError();

            Assert.That(book, Is.Not.Null);
        }

        [Test]
        public void CreateWithPossibleError_SetsAllBasicFields()
        {
            var book = Book.CreateWithPossibleError();

            Assert.Multiple(() =>
            {
                Assert.That(book.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(book.Author, Is.Not.Null.And.Not.Empty);
                Assert.That(book.Genre, Is.Not.Null.And.Not.Empty);
                Assert.That(book.PageNumber, Is.InRange(50, 1000));
                Assert.That(book.BasePrice, Is.InRange(100, 1500));
            });
        }

        [Test]
        public void GetRandomNameAuthorPair_ReturnsValidPair()
        {
            var (name, author) = Book.GetRandomNameAuthorPair();

            Assert.Multiple(() =>
            {
                Assert.That(name, Is.Not.Null.And.Not.Empty);
                Assert.That(author, Is.Not.Null.And.Not.Empty);
            });
        }

        [Test]
        public void GetRandomLineFromFile_GenresFile_ReturnsNonEmptyString()
        {
            string line = Book.GetRandomLineFromFile("Genres.txt");

            Assert.That(line, Is.Not.Null.And.Not.Empty);
        }
    }
}
