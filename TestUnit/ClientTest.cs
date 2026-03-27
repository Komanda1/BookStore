using Bookstore;

namespace TestUnit
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void Constructor_SpecificBook_SetsPropertiesCorrectly()
        {
            string name = "1984";
            string author = "Джордж Оруэлл";
            decimal maxPrice = 500m;

            var customer = new Customer(name, author, maxPrice);

            Assert.Multiple(() =>
            {
                Assert.That(customer.RequestType, Is.EqualTo(CustomerRequestType.SpecificBook));
                Assert.That(customer.DesiredName, Is.EqualTo(name));
                Assert.That(customer.DesiredAuthor, Is.EqualTo(author));
                Assert.That(customer.DesiredGenre, Is.Null);
                Assert.That(customer.MaxPrice, Is.EqualTo(maxPrice));
            });
        }

        [Test]
        public void Constructor_SpecificBook_WithEmptyName_SetsEmptyName()
        {
            var customer = new Customer("", "Автор", 500m);

            Assert.That(customer.DesiredName, Is.EqualTo(""));
        }

        [Test]
        public void Constructor_SpecificBook_WithEmptyAuthor_SetsEmptyAuthor()
        {
            var customer = new Customer("Книга", "", 500m);

            Assert.That(customer.DesiredAuthor, Is.EqualTo(""));
        }

        [Test]
        public void Constructor_SpecificBook_WithZeroPrice_SetsZeroPrice()
        {
            var customer = new Customer("Книга", "Автор", 0m);

            Assert.That(customer.MaxPrice, Is.EqualTo(0m));
        }

        [Test]
        public void Constructor_SpecificBook_WithNegativePrice_SetsNegativePrice()
        {
            var customer = new Customer("Книга", "Автор", -100m);

            Assert.That(customer.MaxPrice, Is.EqualTo(-100m));
        }

        [Test]
        public void Constructor_ByGenre_SetsPropertiesCorrectly()
        {
            string genre = "Фантастика";
            decimal maxPrice = 500m;

            var customer = new Customer(genre, maxPrice);

            Assert.Multiple(() =>
            {
                Assert.That(customer.RequestType, Is.EqualTo(CustomerRequestType.Genre));
                Assert.That(customer.DesiredGenre, Is.EqualTo(genre));
                Assert.That(customer.DesiredName, Is.Null);
                Assert.That(customer.DesiredAuthor, Is.Null);
                Assert.That(customer.MaxPrice, Is.EqualTo(maxPrice));
            });
        }

        [Test]
        public void Constructor_ByGenre_WithEmptyGenre_SetsEmptyGenre()
        {
            var customer = new Customer("", 500m);

            Assert.That(customer.DesiredGenre, Is.EqualTo(""));
        }

        [Test]
        public void Constructor_ByGenre_WithZeroPrice_SetsZeroPrice()
        {
            var customer = new Customer("Фантастика", 0m);

            Assert.That(customer.MaxPrice, Is.EqualTo(0m));
        }

        [Test]
        public void Constructor_ByGenre_WithNegativePrice_SetsNegativePrice()
        {
            var customer = new Customer("Фантастика", -50m);

            Assert.That(customer.MaxPrice, Is.EqualTo(-50m));
        }

        [Test]
        public void GenerateRandom_ReturnsNonNullCustomer()
        {
            var customer = Customer.GenerateRandom();

            Assert.That(customer, Is.Not.Null);
        }

        [Test]
        public void GenerateRandom_SetsValidRequestType()
        {
            var customer = Customer.GenerateRandom();

            Assert.That(customer.RequestType, Is.AnyOf(CustomerRequestType.SpecificBook, CustomerRequestType.Genre));
        }

        [Test]
        public void GenerateRandom_ForSpecificBook_SetsNameAndAuthor()
        {
            var customer = Customer.GenerateRandom();

            if (customer.RequestType == CustomerRequestType.SpecificBook)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(customer.DesiredName, Is.Not.Null.And.Not.Empty);
                    Assert.That(customer.DesiredAuthor, Is.Not.Null.And.Not.Empty);
                    Assert.That(customer.MaxPrice, Is.InRange(200, 2000));
                });
            }
        }

        [Test]
        public void GenerateRandom_ForGenre_SetsGenre()
        {
            var customer = Customer.GenerateRandom();

            if (customer.RequestType == CustomerRequestType.Genre)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(customer.DesiredGenre, Is.Not.Null.And.Not.Empty);
                    Assert.That(customer.MaxPrice, Is.InRange(200, 2000));
                });
            }
        }

        [Test]
        public void GenerateRandom_PriceInRange()
        {
            var customer = Customer.GenerateRandom();

            Assert.That(customer.MaxPrice, Is.InRange(200, 2000));
        }

        [Test]
        public void GenerateRandom_MultipleCalls_ReturnsDifferentCustomers()
        {
            var customer1 = Customer.GenerateRandom();
            var customer2 = Customer.GenerateRandom();
            var customer3 = Customer.GenerateRandom();

            Assert.That(customer1, Is.Not.Null);
            Assert.That(customer2, Is.Not.Null);
            Assert.That(customer3, Is.Not.Null);
        }

        [Test]
        public void ToString_SpecificBook_ReturnsCorrectFormat()
        {
            var customer = new Customer("1984", "Оруэлл", 500m);

            string result = customer.ToString();

            Assert.That(result, Is.EqualTo("Хочет: \"1984\" (Оруэлл), до 500₽"));
        }

        [Test]
        public void ToString_SpecificBook_WithEmptyName_ReturnsCorrectFormat()
        {
            var customer = new Customer("", "Оруэлл", 500m);

            string result = customer.ToString();

            Assert.That(result, Is.EqualTo("Хочет: \"\" (Оруэлл), до 500₽"));
        }

        [Test]
        public void ToString_SpecificBook_WithEmptyAuthor_ReturnsCorrectFormat()
        {
            var customer = new Customer("1984", "", 500m);

            string result = customer.ToString();

            Assert.That(result, Is.EqualTo("Хочет: \"1984\" (), до 500₽"));
        }

        [Test]
        public void ToString_ByGenre_ReturnsCorrectFormat()
        {
            var customer = new Customer("Фантастика", 500m);

            string result = customer.ToString();

            Assert.That(result, Is.EqualTo("Хочет: жанр \"Фантастика\", до 500₽"));
        }

        [Test]
        public void ToString_ByGenre_WithEmptyGenre_ReturnsCorrectFormat()
        {
            var customer = new Customer("", 500m);

            string result = customer.ToString();

            Assert.That(result, Is.EqualTo("Хочет: жанр \"\", до 500₽"));
        }

        [Test]
        public void ToString_ByGenre_WithZeroPrice_ReturnsCorrectFormat()
        {
            var customer = new Customer("Фантастика", 0m);

            string result = customer.ToString();

            Assert.That(result, Is.EqualTo("Хочет: жанр \"Фантастика\", до 0₽"));
        }

        [Test]
        public void Constructor_SpecificBook_WithVeryLongName_WorksCorrectly()
        {
            string longName = new string('A', 1000);
            string author = "Автор";
            decimal price = 1000m;

            var customer = new Customer(longName, author, price);

            Assert.That(customer.DesiredName, Is.EqualTo(longName));
        }

        [Test]
        public void Constructor_SpecificBook_WithVeryLongAuthor_WorksCorrectly()
        {
            string name = "Книга";
            string longAuthor = new string('A', 1000);
            decimal price = 1000m;

            var customer = new Customer(name, longAuthor, price);

            Assert.That(customer.DesiredAuthor, Is.EqualTo(longAuthor));
        }

        [Test]
        public void Constructor_ByGenre_WithVeryLongGenre_WorksCorrectly()
        {
            string longGenre = new string('A', 1000);
            decimal price = 1000m;

            var customer = new Customer(longGenre, price);

            Assert.That(customer.DesiredGenre, Is.EqualTo(longGenre));
        }

        [Test]
        public void Constructor_SpecificBook_WithMaxDecimalPrice_WorksCorrectly()
        {
            decimal maxPrice = decimal.MaxValue;

            var customer = new Customer("Книга", "Автор", maxPrice);

            Assert.That(customer.MaxPrice, Is.EqualTo(maxPrice));
        }
    }
}