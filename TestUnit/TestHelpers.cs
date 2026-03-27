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
}