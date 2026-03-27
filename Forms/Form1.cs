using Bookstore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

        private int lastDiliveryQueueCount = 0;

        private int CustTicks = 0;
        private int lastCustQueueCount = 0;

        private bool blinkState = false;
        private int blinkCounter = 0;

        private bool blinkDelivery = false;
        private bool blinkCustomers = false;

        public Book bookForSellCust;

        private readonly System.Collections.Generic.Dictionary<string, Book> booksMap = new();
        private readonly System.Collections.Generic.Dictionary<string, Customer> customersCollection = new();
        private readonly System.Collections.Generic.Dictionary<string, Book> allBooks = new();

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Form1(DifficultyLevel difficulty)
        {
            InitializeComponent();
            //Удаляем вкладку с доставкой
            tabControl1.TabPages.Remove(tabPage1);

            gameController = new GameController(difficulty);

            store = gameController.Store;

            gameController.BookDelivered += GameController_BookDelivered;
            gameController.CustomerArrived += GameController_CustomerArrived;
            gameController.TimeUpdated += (s, e) => GameController_TimeUpdated(s, e);
            gameController.GameOver += GameController_GameOver;

            gameController.StartGame();

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

            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.DrawItem += TabControl1_DrawItem;
        }

        /// <summary>
        /// Отрисовка вкладок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tab = tabControl1.TabPages[e.Index];
            var bounds = e.Bounds;

            Color backColor = SystemColors.Control;
            Color textColor = Color.Black;

            // Поставки
            if (tab == tabPage1 && blinkDelivery)
            {
                if (blinkState)
                {
                    backColor = Color.Gray;
                    textColor = Color.White;
                }
            }

            // Клиенты
            if (tab == tabPage2 && blinkCustomers)
            {
                if (blinkState)
                {
                    backColor = Color.Gray;
                    textColor = Color.White;
                }
            }

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, bounds);
            }

            TextRenderer.DrawText(
                e.Graphics,
                tab.Text,
                e.Font,
                bounds,
                textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        /// <summary>
        /// Обновление очереди доставки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameController_BookDelivered(object sender, Book e)
        {
            //if (InvokeRequired)
            //{
            //    Invoke(new Action(() => UpdateDeliveryQueue()));
            //    return;
            //}

            UpdateDeliveryQueue();
            //MessageBox.Show("Поступила новая книга!", "Новая книга");
        }

        /// <summary>
        /// Обновление очереди клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameController_CustomerArrived(object sender, Customer e)
        {
            //if (InvokeRequired)
            //{
            //    Invoke(new Action(() => UpdateCustomerQueue()));
            //    return;
            //}

            UpdateCustomerQueue();
            //MessageBox.Show("Пришёл новый клиент!", "Новый клиент");
        }

        private void GameController_TimeUpdated(object sender, TimeUpdatedEventArgs e)
        {
            //if (InvokeRequired)
            //{
            //    Invoke(new Action(() =>
            //    {
            //        txttime.Text = e.GameTime.ToString(@"hh\:mm");
            //    }));
            //    return;
            //} 

            txttime.Text = e.GameTime.ToString(@"hh\:mm");
        }

        private void GameController_GameOver(object sender, (bool Won, string Reason) e)
        {
            ShowGameEndMessage(e.Won, e.Reason);
        }

        private void ShowGameEndMessage(bool isWin, string reason)
        {
            string statistics = store.GetStatistics(); // получаем статистику из магазина

            string fullMessage = $"{reason}\n\n{statistics}";


            string title = isWin ? "Победа!" : "Игра окончена — Вы проиграли!";


            DialogResult result = MessageBox.Show
            (
                fullMessage,
                title,
                MessageBoxButtons.OK,
                isWin ? MessageBoxIcon.Information : MessageBoxIcon.Error
            );

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }


        /// <summary>
        /// Таймер отрисовки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            gameController.Tick();

            lastDiliveryQueueCount = store.DeliveryQueue.Count;

            if (store.DeliveryQueue.Count > 0 && !tabControl1.TabPages.Contains(tabPage1))
            {
                tabControl1.TabPages.Insert(2, tabPage1);
            }
            else if (store.DeliveryQueue.Count == 0 && tabControl1.TabPages.Contains(tabPage1))
            {
                tabControl1.TabPages.Remove(tabPage1);
            }


            // Переключение каждые 500мс
            blinkCounter++;
            if (blinkCounter >= 5)
            {
                blinkState = !blinkState;
                blinkCounter = 0;
            }

            // Мигание
            blinkDelivery = store.DeliveryQueue.Count > 0;
            blinkCustomers = store.CustomerQueue.Count > 0;

            // Перерисовать вкладки
            if (blinkDelivery)
            {
                tabControl1.Invalidate(tabControl1.GetTabRect(tabControl1.TabPages.IndexOf(tabPage1)));
            }

            if (blinkCustomers)
            {
                tabControl1.Invalidate(tabControl1.GetTabRect(tabControl1.TabPages.IndexOf(tabPage2)));
            }
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
            //txtBookID.Text = b.Id.ToString();
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

            bool success = store.OrderBook(
                txtBookName.Text,
                txtAuthor.Text,
                txtGenre.Text,
                pages,
                price,
                out string message);

            if (success)
            {
                lblBalance.Text = $"{store.Balance}₽"; 
                UpdateDeliveryQueue();
                UpdateBooksList();
                LoadGenres();
            }
            else
            {
                MessageBox.Show(message); // показываем сообщение об ошибке
            }

            /*store.AddBookToShelf(newBook.Genre, newBook, out string msg);
            txtStatus.Text = msg;
            LoadGenres();*/
            txtBookID.Clear(); txtBookName.Clear(); txtAuthor.Clear(); txtPrice.Clear(); txtPageCount.Clear(); txtGenre.Clear();
            UpdateBooksList();
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
            UpdateBooksList();
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
            UpdateBooksList();
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

            UpdateCustomerList();

            textBox9.Text = lastCustomer.DesiredName;
            textBox10.Text = lastCustomer.DesiredAuthor;
            textBox11.Text = lastCustomer.DesiredGenre;
            textBox12.Text = lastCustomer.MaxPrice.ToString();
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
            txtClientCount.Text = store.CustomerQueue.Count.ToString();
        }

        private void UpdateBooksList()
        {
            comboBox1.Items.Clear();
            foreach (var s in store.Shelves)
            {
                foreach (var b in s.Books)
                {
                    string key = $"{b.Id} | {b.Name}";
                    comboBox1.Items.Add(key);
                    allBooks[key] = b;
                }
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
                MessageBox.Show("Выберите принять или отклонить книгу!", "Выберите действие!");
                return;
            }

            if (radioButton1.Checked == true)
            {
                if (lastDeliveryBook.IsPlagiat == true || lastDeliveryBook.IsError == true)
                    store.Balance = store.Balance - 15;

                store.AcceptDelivery(lastDeliveryBook, lastDeliveryBook.IsPlagiat, lastDeliveryBook.IsError, out decimal fine, out string msg);

                MessageBox.Show(msg, msg);
                LoadGenres();
            }
            else if (radioButton2.Checked == true)
            {
                store.RejectDelivery(lastDeliveryBook, lastDeliveryBook.IsPlagiat, lastDeliveryBook.IsError, out decimal reward, out string msg);
                MessageBox.Show(msg, msg);
            }
            else if (radioButton3.Checked == true)
            {
                store.RejectDelivery(lastDeliveryBook, lastDeliveryBook.IsPlagiat, lastDeliveryBook.IsError, out decimal reward, out string msg);
                MessageBox.Show(msg, msg);
            }
            lblBalance.Text = $"{store.Balance}₽";
            UpdateDeliveryQueue();
            UpdateBooksList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            string selectbook = comboBox1.SelectedItem.ToString();
            selectbook = selectbook.Split(' ')[0];
            int id = int.Parse(selectbook);
            bookForSellCust = store.FindBookById(id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Выберите покупателя!");
                return;
            }
            if (bookForSellCust != null)
            {
                bookForSellCust.IsSold = store.SellToCustomer(selectedCustomer, bookForSellCust, selectedCustomer.MaxPrice, out string msg);
                MessageBox.Show(msg, msg);
                selectedCustomer = null;
                bookForSellCust = null;
                lblBalance.Text = $"{store.Balance}₽";
                UpdateBooksList();
                UpdateCustomerList();
            }
            else
            {
                MessageBox.Show("Выберите книгу для продажи!", "Выберите книгу!");
            }
            comboBox1.Text = null;
            textBox7.Text = store.UnsatisfiedCustomers.ToString();
            label27.Text = store.UnsatisfiedCustomers.ToString();
            textBox8.Text = store.SatisfiedCustomers.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Выберите покупателя!");
                return;
            }
            store.NotSellToCustomer(selectedCustomer, out string msg);
            MessageBox.Show(msg, msg);
            selectedCustomer = null;
            comboBox1.Text = null;
            UpdateCustomerList();
            textBox7.Text = store.UnsatisfiedCustomers.ToString();
            label27.Text = store.UnsatisfiedCustomers.ToString();
            textBox8.Text = store.SatisfiedCustomers.ToString();
        }
    }
}
