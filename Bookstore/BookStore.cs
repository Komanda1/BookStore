using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    public class BookStore
    {
        private readonly List<BookCase> cases = new();
        public IReadOnlyList<BookCase> Cases => cases;

        public int MaxCases { get; }
        public decimal Balance { get; private set; }

        public BookStore(int maxCases)
        {
            if (maxCases <= 0)
                throw new ArgumentException("Максимальное количество шкафов должно быть > 0.");

            MaxCases = maxCases;
        }

        public BookCase? FindCaseByGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
                throw new ArgumentException("Жанр не может быть пустым.");

            return cases.FirstOrDefault(c => string.Equals(c.Genre, genre, StringComparison.OrdinalIgnoreCase));
        }

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
