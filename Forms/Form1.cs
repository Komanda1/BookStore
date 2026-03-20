using System;
using System.Linq;
using System.Windows.Forms;
using Bookstore;
using Microsoft.VisualBasic;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private BookStore store;
        private Customer customer;
        private BookShelf currentShelf;
        private Book selectedBook;
        private Customer selectedCustomer;
        private GameController gameController;

        private int DeliveryTicks = 0;
        private int lastDiliveryQueueCount = 0;

        private int CustTicks = 0;
        private int lastCustQueueCount = 0;

        private readonly System.Collections.Generic.Dictionary<string, Book> booksMap = new();
        private readonly System.Collections.Generic.Dictionary<string, Customer> customersCollection = new();

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Form1(DifficultyLevel difficulty)
        {
            InitializeComponent();
            //Удаляем вкладку с доставкой
            tabControl1.TabPages.Remove(tabPage1);

            gameController = new GameController(difficulty);

            gameController.State = GameState.Playing;

            store = gameController.Store;
            lblBalance.Text = $"{store.Balance}₽";
            txtStatus.Text = "Магазин готов";
            LoadGenres();
            if (!string.IsNullOrEmpty(gameController.Difficulty)) label8.Text = $"Режим: {gameController.Difficulty}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lastDiliveryQueueCount = store.DeliveryQueue.Count;

            if (DeliveryTicks == gameController.deliveryInterval)
            {
                gameController.DeliveryTimer_Tick();
                DeliveryTicks = 0;
            }


            if (store.DeliveryQueue.Count > 0 && !tabControl1.TabPages.Contains(tabPage1))
            {
                tabControl1.TabPages.Insert(2, tabPage1);
            }
            else if (store.DeliveryQueue.Count == 0 && tabControl1.TabPages.Contains(tabPage1))
            {
                tabControl1.TabPages.Remove(tabPage1);
            }

            if (lastDiliveryQueueCount != store.DeliveryQueue.Count)
            {
                UpdateDeliveryQueue();
                MessageBox.Show("Поступила новая книга!", "Новая книга");
            }
            DeliveryTicks += 1;


            lastCustQueueCount = store.CustomerQueue.Count;

            if (CustTicks == gameController.customerInterval)
            {
                gameController.CustomerTimer_Tick();
                CustTicks = 0;
            }

            if (lastCustQueueCount != store.CustomerQueue.Count)
            {
                UpdateCustomerQueue();
                MessageBox.Show("Пришёл новый клиент!", "Новый клиент");
            }
            CustTicks += 1;
        }

        private void LoadGenres()
        {
            lstGenres.Items.Clear();
            foreach (var genre in store.Shelves.Select(s => s.Genre).Distinct())
                lstGenres.Items.Add(genre);
        }

        private void lstGenres_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstGenres.SelectedItem == null) return;
            string genre = lstGenres.SelectedItem.ToString();
            currentShelf = store.Shelves.FirstOrDefault(s => s.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
            lstBook.Items.Clear();
            booksMap.Clear();
            if (currentShelf != null)
            {
                foreach (var book in currentShelf.Books)
                {
                    string key = $"ID: {book.Id} | {book.Name}";
                    lstBook.Items.Add(key);
                    booksMap[key] = book;
                }
                txtShelfName.Text = $"Выбран шкаф: {genre}";
            }
        }

        private void lstBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBook.SelectedItem == null) return;
            string key = lstBook.SelectedItem.ToString();
            if (booksMap.TryGetValue(key, out Book book))
            {
                selectedBook = book;
                txtStoreCode.Text = book.Id.ToString();
                txtStoreName.Text = book.Name;
                txtStoreAuthor.Text = book.Author;
                txtStorePage.Text = book.PageNumber.ToString();
                txtStorePrice.Text = book.BasePrice.ToString();
            }
        }

        private void btnGenerateRandom_Click_1(object sender, EventArgs e)
        {
            Book b = new Book();
            txtBookID.Text = b.Id.ToString();
            txtBookName.Text = b.Name;
            txtAuthor.Text = b.Author;
            txtGenre.Text = b.Genre;
            txtPrice.Text = b.BasePrice.ToString();
            txtPageCount.Text = b.PageNumber.ToString();
            txtStatus.Text = "Книга сгенерирована";
        }

        private void btnAddBook_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPageCount.Text, out int pages) ||
                !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Введите корректные числовые значения");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBookName.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Заполните название, автора и жанр");
                return;
            }
            Book newBook = new Book(txtBookName.Text, txtAuthor.Text, txtGenre.Text, pages, price);
            // Найти или создать полку
            var shelf = store.Shelves.FirstOrDefault(s => s.Genre.Equals(newBook.Genre, StringComparison.OrdinalIgnoreCase));
            if (shelf == null)
            {
                if (store.Shelves.Any(s => s.Count == 0))
                {
                    shelf = store.Shelves.First(s => s.Count == 0);
                    shelf.ChangeGenre(newBook.Genre);
                }
                else if (store.Shelves.Count < store.MaxShelves)
                {
                    shelf = new BookShelf(genre: newBook.Genre);
                    store.Shelves.Add(shelf);
                }
            }
            if (shelf == null || !shelf.HasSpace)
            {
                txtStatus.Text = "Нет места для этой книги";
                return;
            }
            shelf.AddBook(newBook);
            txtStatus.Text = $"Книга \"{newBook.Name}\" добавлена";
            LoadGenres();
            txtBookID.Clear(); txtBookName.Clear(); txtAuthor.Clear(); txtPrice.Clear(); txtPageCount.Clear(); txtGenre.Clear();
        }

        private void btnFindBook_Click(object sender, EventArgs e)
        {
            string text = txtSearchBook.Text.Trim();
            if (string.IsNullOrEmpty(text)) return;
            foreach (var shelf in store.Shelves)
            {
                var found = shelf.FindById(text.All(char.IsDigit) ? int.Parse(text) : -1)
                            ?? shelf.FindByName(text);
                if (found != null)
                {
                    selectedBook = found;
                    currentShelf = shelf;
                    lstGenres.SelectedItem = shelf.Genre;
                    txtStoreCode.Text = found.Id.ToString();
                    txtStoreName.Text = found.Name;
                    txtStoreAuthor.Text = found.Author;
                    txtStorePage.Text = found.PageNumber.ToString();
                    txtStorePrice.Text = found.BasePrice.ToString();
                    txtStatus.Text = "Книга найдена";
                    return;
                }
            }
            txtStatus.Text = "Книга не найдена";
        }

        private void btnSellBook_Click(object sender, EventArgs e)
        {
            if (selectedBook == null)
            {
                txtStatus.Text = "Сначала выберите книгу";
                return;
            }
            store.SellBook(selectedBook, out string msg);
            lblBalance.Text = $"{store.Balance}₽";
            txtStatus.Text = msg;
            if (currentShelf != null)
                lstBook.Items.Remove(lstBook.SelectedItem);
            ClearBookInfo();
        }

        private void btnClearShelf_Click(object sender, EventArgs e)
        {
            if (currentShelf == null) return;
            foreach (var book in currentShelf.Books.ToList())
            {
                store.SellBook(book, out _);
            }
            lblBalance.Text = $"{store.Balance}₽";
            txtStatus.Text = $"Шкаф \"{currentShelf.Genre}\" очищен";
            lstBook.Items.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearBookInfo()
        {
            txtStoreCode.Clear(); txtStoreName.Clear(); txtStoreAuthor.Clear();
            txtStorePage.Clear(); txtStorePrice.Clear();
            selectedBook = null;
        }

        private void UpdateDeliveryQueue()
        {
            if (store.DeliveryQueue.Count == 0) return;

            Book lastDeliveryBook = store.DeliveryQueue.Last();

            if (lastDeliveryBook == null) return;

            txtDelQueue.Text = store.DeliveryQueue.Count.ToString();

            txtDelBookName.Text = lastDeliveryBook.Name;
            txtDelBookAuthor.Text = lastDeliveryBook.Author;
            txtDelBookGenre.Text = lastDeliveryBook.Genre;
            txtDelBookPageCount.Text = lastDeliveryBook.PageNumber.ToString();
            txtDelBookPrice.Text = lastDeliveryBook.BasePrice.ToString();
        }

        private void UpdateCustomerQueue()
        {
            if (store.CustomerQueue.Count == 0) return;

            Customer lastCustomer = store.CustomerQueue.Last();

            if (lastCustomer == null) return;

            txtDelQueue.Text = store.CustomerQueue.Count.ToString();

            textBox9.Text = lastCustomer.DesiredName;
            textBox10.Text = lastCustomer.DesiredAuthor;
            textBox11.Text = lastCustomer.DesiredGenre;
            textBox12.Text = lastCustomer.MaxPrice.ToString();

            UpdateCustomerList();
        }

        private void UpdateCustomerList()
        {
            listClient.Items.Clear();
            foreach (var cust in store.CustomerQueue)
            {
                string key = $"Пожелания клиента: {cust.DesiredName} | {cust.DesiredAuthor} | {cust.DesiredGenre} | {cust.MaxPrice}";
                listClient.Items.Add(key);
                customersCollection[key] = cust;
            }
        }

        private void listClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listClient.SelectedItem == null) return;

            string key = listClient.SelectedItem.ToString();
            if (customersCollection.TryGetValue(key, out Customer cust))
            {
                selectedCustomer = cust;
                textBox9.Text = cust.DesiredName;
                textBox10.Text = cust.DesiredAuthor;
                textBox11.Text = cust.DesiredGenre;
                textBox12.Text = cust.MaxPrice.ToString();
            }
        }

        private void btnСonfirmSelect_Click(object sender, EventArgs e)
        {
            Book lastDeliveryBook = store.DeliveryQueue.Last();

            if (lastDeliveryBook == null) return;

            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                MessageBox.Show("Выберите способ доставки!", "Выберите способ доставки!");
                return;
            }

            if (radioButton1.Checked == true)
            {
                if (lastDeliveryBook.IsPlagiat == true || lastDeliveryBook.IsError == true)
                    store.Balance = store.Balance - 15;

                // Найти или создать полку
                var shelf = store.Shelves.FirstOrDefault(s => s.Genre.Equals(lastDeliveryBook.Genre, StringComparison.OrdinalIgnoreCase));
                if (shelf == null)
                {
                    if (store.Shelves.Any(s => s.Count == 0))
                    {
                        shelf = store.Shelves.First(s => s.Count == 0);
                        shelf.ChangeGenre(lastDeliveryBook.Genre);
                    }
                    else if (store.Shelves.Count < store.MaxShelves)
                    {
                        shelf = new BookShelf(genre: lastDeliveryBook.Genre);
                        store.Shelves.Add(shelf);
                    }
                }
                if (shelf == null || !shelf.HasSpace)
                {
                    MessageBox.Show("Нет места для этой книги.", "Нет места для этой книги.");
                    return;
                }
                shelf.AddBook(lastDeliveryBook);
                MessageBox.Show($"Книга \"{lastDeliveryBook.Name}\" добавлена.", $"Книга \"{lastDeliveryBook.Name}\" добавлена.");
                LoadGenres();

                store.DeliveryQueue.Remove(lastDeliveryBook);
            }
            else if (radioButton2.Checked == true)
            {
                if (lastDeliveryBook.IsPlagiat == true)
                    store.Balance = store.Balance + 10;
                else if (lastDeliveryBook.IsError == true)
                    store.Balance = store.Balance - 10;

                store.DeliveryQueue.Remove(lastDeliveryBook);
                MessageBox.Show($"Книга \"{lastDeliveryBook.Name}\" отклонена.", $"Книга \"{lastDeliveryBook.Name}\" отклонена.");

            }
            else if (radioButton3.Checked == true)
            {
                if (lastDeliveryBook.IsError == true)
                    store.Balance = store.Balance + 10;
                else if (lastDeliveryBook.IsPlagiat == true)
                    store.Balance = store.Balance - 10;

                store.DeliveryQueue.Remove(lastDeliveryBook);
                MessageBox.Show($"Книга \"{lastDeliveryBook.Name}\" отклонена.", $"Книга \"{lastDeliveryBook.Name}\" отклонена.");
            }

            UpdateDeliveryQueue();
        }
    }
}
