namespace Bookstore
{
    /// <summary>
    /// Тип запроса покупателя
    /// </summary>
    public enum CustomerRequestType
    {
        SpecificBook,  // Конкретная книга
        Genre          // Любой жанр
    }

    /// <summary>
    /// Класс покупателя
    /// </summary>
    public class Customer
    {
        public CustomerRequestType RequestType { get; }
        public string DesiredName { get; }
        public string DesiredAuthor { get; }
        public string DesiredGenre { get; }
        public decimal MaxPrice { get; }

        /// <summary>
        /// Конструктор покупателя с конкретным запросом
        /// </summary>
        /// <param name="name"> название книги </param>
        /// <param name="author"> автор </param>
        /// <param name="maxPrice"> максимальная цена </param>
        public Customer(string name, string author, decimal maxPrice)
        {
            RequestType = CustomerRequestType.SpecificBook;
            DesiredName = name;
            DesiredAuthor = author;
            DesiredGenre = null;
            MaxPrice = maxPrice;
        }

        /// <summary>
        /// Конструктор покупателя с запросом по жанру
        /// </summary>
        /// <param name="genre"> жанр </param>
        /// <param name="maxPrice"> максимальная цена </param>
        public Customer(string genre, decimal maxPrice)
        {
            RequestType = CustomerRequestType.Genre;
            DesiredName = null;
            DesiredAuthor = null;
            DesiredGenre = genre;
            MaxPrice = maxPrice;
        }

        /// <summary>
        /// Случайная генерация покупателя
        /// </summary>
        /// <returns> запрос </returns>
        public static Customer GenerateRandom()
        {
            var rnd = new Random();

            if (rnd.Next(2) == 0)
            {
                var nameAuthor = GetRandomNameAuthor();
                return new Customer(nameAuthor.name, nameAuthor.author, rnd.Next(200, 2000));
            }
            else
            {
                return new Customer(("Genres.txt"), rnd.Next(200, 2000));
            }
        }

        /// <summary>
        /// Упрощенная версия получения пары название-автор для чтения
        /// </summary>
        /// <returns> метод из класса Book </returns>
        private static (string name, string author) GetRandomNameAuthor()
        {
            return Book.GetRandomNameAuthorPair();
        }

        /// <summary>
        /// Вывод запроса
        /// </summary>
        /// <returns> текст запроса </returns>
        public override string ToString()
        {
            if (RequestType == CustomerRequestType.SpecificBook)
                return $"Хочет: \"{DesiredName}\" ({DesiredAuthor}), до {MaxPrice}₽";
            else
                return $"Хочет: жанр \"{DesiredGenre}\", до {MaxPrice}₽";
        }
    }
}