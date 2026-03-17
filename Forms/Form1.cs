using Bookstore;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private string gameDifficulty;
        private BookStore store;
        private Book? currentBook;
        private Book selectedBook;
        private BookCase currentShelf;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            InitializeStore();
            SetupForm();
        }
        /// <summary>
        /// Инициализация магазина: создание экземпляра и отображение баланса
        /// </summary>
        private void InitializeStore()
        {
            store = new BookStore(5); //допустим, 5 шкафов максимум
            lblBalance.Text = $"{store.Balance:C}";

        }
        

        /// <summary>
        /// Комплексная настройка формы перед началом работы
        /// </summary>
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
        /// <summary>
        /// Настройка параметров ListBox для отображения книг
        /// </summary>
        private void SetupDataBook()
        {
            lstBook.SelectionMode = SelectionMode.One;
            lstBook.Sorted = false;
            lstBook.HorizontalScrollbar = true;

        }
        /// <summary>
        /// Настройка параметров ListBox для отображения жанров
        /// </summary>
        private void SetupDataGenre()
        {
            lstBook.SelectionMode = SelectionMode.One;
            lstBook.Sorted = false;
            lstBook.HorizontalScrollbar = true;

        }
        private Dictionary<string, Book> booksMap = new Dictionary<string, Book>();
        /// <summary>
        /// Отображает книги из указанного шкафа в ListBox
        /// Заполняет booksMap для быстрого доступа к объектам Book
        /// </summary>
        /// <param name="shelf">Шкаф с книгами для отображения</param>
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

        /// <summary>
        /// Загружает список доступных жанров в ListBox
        /// Вызывается при добавлении новой книги или изменении ассортимента
        /// </summary>
        private void LoadGenres()
        {
            lstGenres.Items.Clear();
            var genres = store.GetAvailableGenres();
            foreach (var genre in genres)
            {
                lstGenres.Items.Add(genre);
            }
        }
        /// <summary>
        /// Настраивает поля формы в режим "только чтение"
        /// Используется для отображения информации о выбранной книге
        /// </summary>
        private void SetupReadOnlyFields()
        {
            txtBookID.ReadOnly = true;
            txtStoreName.ReadOnly = true;
            txtStoreAuthor.ReadOnly = true;
            txtStorePrice.ReadOnly = true;
            txtStorePage.ReadOnly = true;
            txtStoreCode.ReadOnly = true;
        }

        /// <summary>
        /// Обновляет отображение текущего баланса магазина
        /// Форматирует значение как валюта (C)
        /// </summary>
        private void UpdateBalance()
        {
            lblBalance.Text = $"{store.Balance:C}";
        }

        /// <summary>
        /// Обновляет текст в поле статуса для информирования пользователя
        /// </summary>
        /// <param name="message">Сообщение для отображения</param>
        private void UpdateStatus(string message)
        {
            txtStatus.Text = message;
        }
        /// <summary>
        /// Очищает поля отображения информации о книге (режим просмотра)
        /// </summary>
        private void ClearBookInfo()
        {
            txtStoreName.Clear();
            txtStoreCode.Clear();
            txtStoreAuthor.Clear();
            txtStorePrice.Clear();
            txtStorePage.Clear();
            currentBook = null;
        }
        /// <summary>
        /// Очищает поля ввода для создания новой книги
        /// </summary>
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


        /// <summary>
        /// Обработчик кнопки "Сгенерировать случайную книгу"
        /// Создаёт книгу с автоматическим заполнением полей (кроме жанра)
        /// </summary>
        private void btnGenerateRandom_Click_1(object sender, EventArgs e)
        {
            try
            {
                string? genre = string.IsNullOrWhiteSpace(txtGenre.Text) ? null : txtGenre.Text;

                currentBook = new Book(
                    name: null,
                    author: null,
                    genre: genre,
                    pageNumber: null,
                    price: null
                );

                txtBookID.Text = (store.GetLastBookId() + 1).ToString();
                txtBookName.Text = currentBook.Name;
                txtAuthor.Text = currentBook.Author;
                txtGenre.Text = currentBook.Genre;
                txtPrice.Text = currentBook.Price.ToString();
                txtPageCount.Text = currentBook.PageNumber.ToString();

                UpdateStatus($"Сгенерирована книга: \"{currentBook.Name}\" ({currentBook.Genre})");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Неверные данные при создании книги",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                UpdateStatus("Ошибка: одно из значений книги оказалось null.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Нельзя создать книгу",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                UpdateStatus("Не удалось создать книгу. Проверьте файлы с данными и жанр.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Необработанная ошибка при генерации книги",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                UpdateStatus("Произошла непредвиденная ошибка при генерации книги.");
            }
        }


        /// <summary>
        /// Обработчик кнопки "Добавить книгу в магазин"
        /// </summary>
        private void btnAddBook_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Введите корректную цену", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtPageCount.Text, out int page))
                {
                    MessageBox.Show("Введите корректное количество страниц", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBookName.Text) ||
                    string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                    string.IsNullOrWhiteSpace(txtGenre.Text))
                {
                    MessageBox.Show("Заполните название, автора и жанр.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка при добавлении книги",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                UpdateStatus("Не удалось добавить книгу в магазин.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Некорректные данные",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                UpdateStatus("Проверьте введённые данные книги.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Необработанная ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                UpdateStatus("Произошла непредвиденная ошибка при добавлении книги.");
            }
        }
        //---------------------------------------------------МАГАЗИН--------------------------------------------------------------------------


        /// <summary>
        /// Обработчик выбора жанра в списке
        /// Загружает книги соответствующего жанра в ListBox
        /// </summary>
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
        /// <summary>
        /// Заполняет поля отображения данными из объекта Book
        /// </summary>
        /// <param name="book">Книга для отображения</param>
        private void DisplayBookInfo(Book book)
        {
            txtStoreCode.Text = book.Id.ToString();
            txtStoreName.Text = book.Name;
            txtStoreAuthor.Text = book.Author;
            txtStorePrice.Text = book.Price.ToString("C");
            txtStorePage.Text = book.PageNumber.ToString();
        }

        /// <summary>
        /// Обработчик выбора книги в списке
        /// Отображает детальную информацию о выбранной книге
        /// </summary>
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

        /// <summary>
        /// Обработчик кнопки "Найти книгу"
        /// Поиск по ID (число) или по названию (строка)
        /// </summary>
        private void btnFindBook_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBook.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    UpdateStatus("Введите ID или название книги для поиска.");
                    return;
                }

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
                    UpdateStatus("Книга не найдена.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка при поиске книги",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                UpdateStatus("Произошла ошибка при поиске книги.");
            }
        }


        /// <summary>
        /// Обработчик кнопки "Продать книгу"
        /// Продаёт выбранную книгу, обновляет баланс и интерфейс
        /// </summary>
        private void btnSellBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBook == null)
                {
                    UpdateStatus("Сначала выберите книгу для продажи.");
                    return;
                }

                store.SellBook(selectedBook);
                UpdateBalance();

                if (currentShelf != null)
                {
                    DisplayBooks(currentShelf);
                    UpdateStatus($"Книга продана. Шкаф \"{currentShelf.Genre}\": {currentShelf.Books.Count}/{currentShelf.Capacity} книг");
                }
                else
                {
                    UpdateStatus("Книга продана.");
                }

                ClearBookInfo();
                selectedBook = null;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Нельзя продать книгу",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                UpdateStatus("Не удалось продать книгу.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка при продаже книги",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                UpdateStatus("Произошла ошибка при продаже книги.");
            }
        }

        /// <summary>
        /// Обработчик кнопки "Очистить шкаф"
        /// Продаёт все книги в текущем шкафе, освобождая место для нового жанра
        /// </summary>
        private void btnClearShelf_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentShelf == null)
                {
                    UpdateStatus("Сначала выберите шкаф (жанр) для очистки.");
                    return;
                }

                if (!currentShelf.Books.Any())
                {
                    UpdateStatus($"Шкаф \"{currentShelf.Genre}\" уже пуст.");
                    return;
                }

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
                lstBook.ClearSelected();
                UpdateStatus($"Шкаф \"{currentShelf.Genre}\" очищен. Продано {booksSold} книг на сумму {totalIncome:C}.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка при очистке шкафа",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                UpdateStatus("Не удалось очистить шкаф.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Необработанная ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                UpdateStatus("Произошла ошибка при очистке шкафа.");
            }
        }
        public Form1(string difficulty) : this() // Вызываем старый конструктор через : this()
        {
            this.gameDifficulty = difficulty;

            // Здесь можно сразу настроить игру под сложность
            StartGameWithDifficulty(difficulty);
        }

        private void StartGameWithDifficulty(string difficulty)
        {
            label8.Text = ($"Игра началась в режиме: {difficulty}");

            // Вызовите вашу функцию настройки таймеров и лимитов здесь
            // Например: SetDifficultyParameters(difficulty);
            // И запустите таймеры: timerBooks.Start(); timerCustomers.Start();

            UpdateStatus($"Режим игры: {difficulty}. Удачи!");
        }


        /// <summary>
        /// Обработчик кнопки "Закрыть"
        /// Корректно закрывает форму приложения
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
