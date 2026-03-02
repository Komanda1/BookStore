using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    public class BookCase
    {
        public string Genre { get; private set; }
        public int Capacity { get; }

        private readonly List<Book> books = new();

        public IReadOnlyList<Book> Books => books;

        public BookCase(string genre, int capacity)
        {
            if (string.IsNullOrWhiteSpace(genre))
                throw new ArgumentException("Жанр шкафа не может быть пустым.");

            if (capacity <= 0)
                throw new ArgumentException("Вместимость должна быть > 0.");

            Genre = genre;
            Capacity = capacity;
        }

        public bool HasSpace => books.Count < Capacity;

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (!HasSpace)
                throw new InvalidOperationException("В шкафу нет места.");

            if (!string.Equals(book.Genre, Genre, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Жанр книги не совпадает с жанром шкафа.");

            if (book.IsSold)
                throw new InvalidOperationException("Нельзя добавить проданную книгу.");

            books.Add(book);
        }

        public Book FindById(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public Book FindByName(string name)
        {
            return books.FirstOrDefault(b => string.Equals(b.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Book> GetBooksInOrder()
        {
            return books; 
        }
        public bool RemoveBook(Book book)
        {
            return books.Remove(book);
        }
        public void ReassignGenre(string newGenre)
        {
            if (books.Count > 0)
                throw new InvalidOperationException("Нельзя сменить жанр, пока в шкафу есть книги.");

            if (string.IsNullOrWhiteSpace(newGenre))
                throw new ArgumentException("Жанр не может быть пустым.");

            Genre = newGenre;
        }
    }
}
