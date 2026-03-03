using Bookstore;
using System.Xml.Linq;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private BookStore store;
        private Book currentBook;
        private Book selectedBook;
        private BookCase currentShelf;


        public Form1()
        {
            InitializeComponent();
            InitializeStore();
            SetupForm();
        }
        private void InitializeStore()
        {
            store = new BookStore(5); //допустим, 5 шкафов максимум
            lblBalance.Text = $"{store.Balance:C}";

        }

        private void SetupForm()
        {
            SetupDataBook();
            SetupDataGenre();
            LoadGenres();
            SetupReadOnlyFields();
            ClearBookFields();
            UpdateBalance();
            UpdateStatus("Магазин готов к работе. Добавьте книги.");
        }
        private void SetupDataBook()
        {
            lstBook.SelectionMode = SelectionMode.One;
            lstBook.Sorted = false;
            lstBook.HorizontalScrollbar = true;

        }
        private void SetupDataGenre()
        {
            lstBook.SelectionMode = SelectionMode.One;
            lstBook.Sorted = false;
            lstBook.HorizontalScrollbar = true;

        }
        private Dictionary<string, Book> booksMap = new Dictionary<string, Book>();
        private void DisplayBooks(BookCase shelf)
        {
            lstBook.Items.Clear();
            booksMap.Clear();
            var books = shelf.GetBooksInOrder();

            foreach (var book in books)
            {
                string bookInfo = $"ID:   {book.Id,-3} | {book.Name,-25}";
                lstBook.Items.Add(bookInfo);
                booksMap[bookInfo] = book;
            }
        }

        private void LoadGenres()
        {
            lstGenres.Items.Clear();
            var genres = store.GetAvailableGenres();
            foreach (var genre in genres)
            {
                lstGenres.Items.Add(genre);
            }
        }
        private void SetupReadOnlyFields()
        {
            txtBookID.ReadOnly = true;
            txtStoreName.ReadOnly = true;
            txtStoreAuthor.ReadOnly = true;
            txtStorePrice.ReadOnly = true;
            txtStorePage.ReadOnly = true;
            txtStoreCode.ReadOnly = true;
        }

        private void UpdateBalance()
        {
            lblBalance.Text = $"{store.Balance:C}";
        }

        private void UpdateStatus(string message)
        {
            txtStatus.Text = message;
        }
        private void ClearBookInfo()
        {
            txtStoreName.Clear();
            txtStoreCode.Clear();
            txtStoreAuthor.Clear();
            txtStorePrice.Clear();
            txtStorePage.Clear();
            currentBook = null;
        }
        private void ClearBookFields()
        {
            txtBookID.Clear();
            txtBookName.Clear();
            txtAuthor.Clear();
            txtPrice.Clear();
            txtPageCount.Clear();
            txtGenre.Clear();
            currentBook = null;
        }

        //--------------------------------НОВАЯ КНИГА-----------------------------------------------------------------------------------


        private void btnGenerateRandom_Click_1(object sender, EventArgs e)
        {
            {
                try
                {
                    string genre = string.IsNullOrWhiteSpace(txtGenre.Text) ? null : txtGenre.Text;

                    currentBook = new Book(
                        name: null,
                        author: null,
                        genre: genre,
                        pageNumber: null,
                        price: null
                    );
                    txtBookID.Text = currentBook.Id.ToString();
                    txtBookName.Text = currentBook.Name;
                    txtAuthor.Text = currentBook.Author;
                    txtGenre.Text = currentBook.Genre;
                    txtPrice.Text = currentBook.Price.ToString();
                    txtPageCount.Text = currentBook.PageNumber.ToString();

                    UpdateStatus($"Сгенерирована книга: \"{currentBook.Name}\" ({currentBook.Genre})");
                }
                catch (Exception)
                {

                }
            }
        }
        private void btnAddBook_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Введите корректную цену");
                    return;
                }
                if (!int.TryParse(txtPageCount.Text, out int page))
                {
                    MessageBox.Show("Введите корректное количество страниц");
                    return;
                }
                if (currentBook == null)
                {
                    currentBook = new Book(
                        name: txtBookName.Text.Trim(),
                        author: txtAuthor.Text.Trim(),
                        genre: txtGenre.Text.Trim(),
                        pageNumber: page,
                        price: price
                    );
                }
                store.AddBookToStore(currentBook);
                UpdateStatus($"Книга \"{currentBook.Name}\" добавлена. Жанр: {currentBook.Genre}");
                LoadGenres();
                ClearBookFields();
            }
            catch (Exception)
            {
            }
        }
        //---------------------------------------------------МАГАЗИН--------------------------------------------------------------------------


        private void lstGenres_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstGenres.SelectedItem == null)
                return;

            string selectedGenre = lstGenres.SelectedItem.ToString();
            currentShelf = store.FindCaseByGenre(selectedGenre);

            if (currentShelf != null)
            {
                DisplayBooks(currentShelf);
                txtShelfName.Text = $"Выбран шкаф: {selectedGenre}";
            }
        }
        private void DisplayBookInfo(Book book)
        {
            txtStoreCode.Text = book.Id.ToString();
            txtStoreName.Text = book.Name;
            txtStoreAuthor.Text = book.Author;
            txtStorePrice.Text = book.Price.ToString("C");
            txtStorePage.Text = book.PageNumber.ToString();
        }

        private void lstBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBook.SelectedItem == null)
                return;

            string selectedText = lstBook.SelectedItem.ToString();
            if (booksMap.TryGetValue(selectedText, out Book book))
            {
                selectedBook = book;
                DisplayBookInfo(selectedBook);
            }
        }

        private void btnFindBook_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchBook.Text.Trim();

            Book foundBook = null;
            if (int.TryParse(searchText, out int id))
            {
                foundBook = store.FindBookById(id);
            }
            if (foundBook == null)
            {
                foundBook = store.FindBookByName(searchText);
            }

            if (foundBook != null)
            {
                selectedBook = foundBook;
                DisplayBookInfo(selectedBook);
                foreach (var shelf in store.Cases)
                {
                    if (shelf.Books.Contains(foundBook))
                    {
                        currentShelf = shelf;
                        lstGenres.SelectedItem = shelf.Genre;
                        DisplayBooks(shelf);
                        break;
                    }
                }

                UpdateStatus($"Книга найдена: \"{foundBook.Name}\"");
            }
            else
            {
                UpdateStatus("Книга не найдена");
            }
        }

        private void btnSellBook_Click(object sender, EventArgs e)
        {
            try
            {
                store.SellBook(selectedBook);
                UpdateBalance();

                if (currentShelf != null)
                {
                    DisplayBooks(currentShelf);
                    UpdateStatus($"Шкаф \"{currentShelf.Genre}\": {currentShelf.OccupiedCount}/{currentShelf.Capacity} книг");
                }
                ClearBookInfo();
            }
            catch (Exception)
            {

            }
        }

        private void btnClearShelf_Click(object sender, EventArgs e)
        {
            try
            {
                decimal totalIncome = 0;
                int booksSold = 0;
                var booksToSell = currentShelf.Books.ToList();
                foreach (var book in booksToSell)
                {
                    store.SellBook(book);
                    totalIncome += book.Price;
                    booksSold++;
                }

                UpdateBalance();
                DisplayBooks(currentShelf);
                ClearBookInfo();
                UpdateStatus($"Шкаф \"{currentShelf.Genre}\" очищен. Готов к новому жанру.");
                lstBook.ClearSelected();

            }
            catch (Exception)
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
