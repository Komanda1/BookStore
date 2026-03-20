namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabNewBook = new TabPage();
            groupBox2 = new GroupBox();
            txtStatus = new Label();
            btnAddBook = new Button();
            btnGenerateRandom = new Button();
            groupBox1 = new GroupBox();
            txtBookID = new TextBox();
            txtGenre = new TextBox();
            label6 = new Label();
            txtPageCount = new TextBox();
            label5 = new Label();
            txtPrice = new TextBox();
            label4 = new Label();
            txtAuthor = new TextBox();
            label3 = new Label();
            txtBookName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tabStore = new TabPage();
            panel3 = new Panel();
            txtStoreCode = new TextBox();
            txtStorePage = new TextBox();
            txtStorePrice = new TextBox();
            txtStoreAuthor = new TextBox();
            txtStoreName = new TextBox();
            btnClose = new Button();
            btnSellBook = new Button();
            lblStoreCode = new Label();
            lblStorePage = new Label();
            lblStorePrice = new Label();
            lblStoreAuthor = new Label();
            lblStoreName = new Label();
            lstBook = new ListBox();
            txtShelfName = new Label();
            panel2 = new Panel();
            btnClearShelf = new Button();
            lstGenres = new ListBox();
            label9 = new Label();
            panel1 = new Panel();
            btnFindBook = new Button();
            txtSearchBook = new TextBox();
            tabPage1 = new TabPage();
            txtDelQueue = new TextBox();
            label18 = new Label();
            groupBox4 = new GroupBox();
            btnСonfirmSelect = new Button();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            groupBox3 = new GroupBox();
            txtDelBookPageCount = new TextBox();
            label15 = new Label();
            txtDelBookPrice = new TextBox();
            label14 = new Label();
            txtDelBookGenre = new TextBox();
            label13 = new Label();
            txtDelBookAuthor = new TextBox();
            label12 = new Label();
            txtDelBookName = new TextBox();
            label11 = new Label();
            label10 = new Label();
            tabPage2 = new TabPage();
            txtClientCount = new TextBox();
            label25 = new Label();
            groupBox7 = new GroupBox();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            label24 = new Label();
            label23 = new Label();
            groupBox6 = new GroupBox();
            button3 = new Button();
            button2 = new Button();
            groupBox5 = new GroupBox();
            textBox12 = new TextBox();
            textBox11 = new TextBox();
            textBox10 = new TextBox();
            textBox9 = new TextBox();
            label22 = new Label();
            label21 = new Label();
            label19 = new Label();
            label20 = new Label();
            comboBox1 = new ComboBox();
            label17 = new Label();
            listClient = new ListBox();
            label16 = new Label();
            lblBalance = new Label();
            label7 = new Label();
            label8 = new Label();
            lblday = new Label();
            lbltime = new Label();
            txtday = new TextBox();
            txttime = new TextBox();
            label26 = new Label();
            label27 = new Label();
            tabControl1.SuspendLayout();
            tabNewBook.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabStore.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabNewBook);
            tabControl1.Controls.Add(tabStore);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(45, 130);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(640, 582);
            tabControl1.TabIndex = 0;
            // 
            // tabNewBook
            // 
            tabNewBook.BackColor = Color.FromArgb(224, 224, 224);
            tabNewBook.Controls.Add(groupBox2);
            tabNewBook.Controls.Add(groupBox1);
            tabNewBook.Location = new Point(4, 24);
            tabNewBook.Margin = new Padding(3, 2, 3, 2);
            tabNewBook.Name = "tabNewBook";
            tabNewBook.Padding = new Padding(3, 2, 3, 2);
            tabNewBook.Size = new Size(632, 554);
            tabNewBook.TabIndex = 0;
            tabNewBook.Text = "Заказать книгу";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(txtStatus);
            groupBox2.Controls.Add(btnAddBook);
            groupBox2.Controls.Add(btnGenerateRandom);
            groupBox2.Location = new Point(33, 331);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(559, 124);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Управление";
            // 
            // txtStatus
            // 
            txtStatus.BackColor = Color.FromArgb(224, 224, 224);
            txtStatus.Location = new Point(10, 81);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(495, 28);
            txtStatus.TabIndex = 2;
            txtStatus.Text = "Строка состояния";
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(305, 28);
            btnAddBook.Margin = new Padding(3, 2, 3, 2);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(200, 28);
            btnAddBook.TabIndex = 1;
            btnAddBook.Text = "Добавить книгу";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click_1;
            // 
            // btnGenerateRandom
            // 
            btnGenerateRandom.Location = new Point(10, 28);
            btnGenerateRandom.Margin = new Padding(3, 2, 3, 2);
            btnGenerateRandom.Name = "btnGenerateRandom";
            btnGenerateRandom.Size = new Size(200, 28);
            btnGenerateRandom.TabIndex = 0;
            btnGenerateRandom.Text = "Случайная генерация";
            btnGenerateRandom.UseVisualStyleBackColor = true;
            btnGenerateRandom.Click += btnGenerateRandom_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(txtBookID);
            groupBox1.Controls.Add(txtGenre);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtPageCount);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtAuthor);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtBookName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(34, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(558, 307);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Данные книги";
            // 
            // txtBookID
            // 
            txtBookID.BackColor = Color.FromArgb(224, 224, 224);
            txtBookID.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtBookID.Location = new Point(256, 37);
            txtBookID.Margin = new Padding(3, 2, 3, 2);
            txtBookID.Name = "txtBookID";
            txtBookID.Size = new Size(250, 23);
            txtBookID.TabIndex = 13;
            // 
            // txtGenre
            // 
            txtGenre.BackColor = Color.FromArgb(224, 224, 224);
            txtGenre.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtGenre.Location = new Point(256, 266);
            txtGenre.Margin = new Padding(3, 2, 3, 2);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(250, 23);
            txtGenre.TabIndex = 12;
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(224, 224, 224);
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(10, 256);
            label6.Name = "label6";
            label6.Size = new Size(205, 36);
            label6.TabIndex = 11;
            label6.Text = "Жанр";
            // 
            // txtPageCount
            // 
            txtPageCount.BackColor = Color.FromArgb(224, 224, 224);
            txtPageCount.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtPageCount.Location = new Point(256, 220);
            txtPageCount.Margin = new Padding(3, 2, 3, 2);
            txtPageCount.Name = "txtPageCount";
            txtPageCount.Size = new Size(250, 23);
            txtPageCount.TabIndex = 9;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(224, 224, 224);
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(10, 211);
            label5.Name = "label5";
            label5.Size = new Size(205, 36);
            label5.TabIndex = 8;
            label5.Text = "Кол-во страниц";
            // 
            // txtPrice
            // 
            txtPrice.BackColor = Color.FromArgb(224, 224, 224);
            txtPrice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtPrice.Location = new Point(256, 173);
            txtPrice.Margin = new Padding(3, 2, 3, 2);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(250, 23);
            txtPrice.TabIndex = 7;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(224, 224, 224);
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(10, 164);
            label4.Name = "label4";
            label4.Size = new Size(205, 36);
            label4.TabIndex = 6;
            label4.Text = "Цена";
            // 
            // txtAuthor
            // 
            txtAuthor.BackColor = Color.FromArgb(224, 224, 224);
            txtAuthor.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtAuthor.Location = new Point(256, 127);
            txtAuthor.Margin = new Padding(3, 2, 3, 2);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(250, 23);
            txtAuthor.TabIndex = 5;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(224, 224, 224);
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(10, 118);
            label3.Name = "label3";
            label3.Size = new Size(205, 36);
            label3.TabIndex = 4;
            label3.Text = "Автор";
            // 
            // txtBookName
            // 
            txtBookName.BackColor = Color.FromArgb(224, 224, 224);
            txtBookName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtBookName.Location = new Point(256, 82);
            txtBookName.Margin = new Padding(3, 2, 3, 2);
            txtBookName.Name = "txtBookName";
            txtBookName.Size = new Size(250, 23);
            txtBookName.TabIndex = 3;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(224, 224, 224);
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(10, 74);
            label2.Name = "label2";
            label2.Size = new Size(205, 36);
            label2.TabIndex = 2;
            label2.Text = "Название";
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(224, 224, 224);
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(10, 28);
            label1.Name = "label1";
            label1.Size = new Size(205, 36);
            label1.TabIndex = 0;
            label1.Text = "Код Книги";
            // 
            // tabStore
            // 
            tabStore.BackColor = Color.FromArgb(224, 224, 224);
            tabStore.Controls.Add(panel3);
            tabStore.Controls.Add(panel2);
            tabStore.Controls.Add(panel1);
            tabStore.Location = new Point(4, 24);
            tabStore.Margin = new Padding(3, 2, 3, 2);
            tabStore.Name = "tabStore";
            tabStore.Padding = new Padding(3, 2, 3, 2);
            tabStore.Size = new Size(632, 554);
            tabStore.TabIndex = 1;
            tabStore.Text = "Магазин";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(txtStoreCode);
            panel3.Controls.Add(txtStorePage);
            panel3.Controls.Add(txtStorePrice);
            panel3.Controls.Add(txtStoreAuthor);
            panel3.Controls.Add(txtStoreName);
            panel3.Controls.Add(btnClose);
            panel3.Controls.Add(btnSellBook);
            panel3.Controls.Add(lblStoreCode);
            panel3.Controls.Add(lblStorePage);
            panel3.Controls.Add(lblStorePrice);
            panel3.Controls.Add(lblStoreAuthor);
            panel3.Controls.Add(lblStoreName);
            panel3.Controls.Add(lstBook);
            panel3.Controls.Add(txtShelfName);
            panel3.Location = new Point(239, 60);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(349, 365);
            panel3.TabIndex = 2;
            // 
            // txtStoreCode
            // 
            txtStoreCode.Location = new Point(186, 291);
            txtStoreCode.Margin = new Padding(3, 2, 3, 2);
            txtStoreCode.Name = "txtStoreCode";
            txtStoreCode.Size = new Size(151, 23);
            txtStoreCode.TabIndex = 13;
            // 
            // txtStorePage
            // 
            txtStorePage.Location = new Point(186, 266);
            txtStorePage.Margin = new Padding(3, 2, 3, 2);
            txtStorePage.Name = "txtStorePage";
            txtStorePage.Size = new Size(151, 23);
            txtStorePage.TabIndex = 12;
            // 
            // txtStorePrice
            // 
            txtStorePrice.Location = new Point(186, 240);
            txtStorePrice.Margin = new Padding(3, 2, 3, 2);
            txtStorePrice.Name = "txtStorePrice";
            txtStorePrice.Size = new Size(151, 23);
            txtStorePrice.TabIndex = 11;
            // 
            // txtStoreAuthor
            // 
            txtStoreAuthor.Location = new Point(186, 215);
            txtStoreAuthor.Margin = new Padding(3, 2, 3, 2);
            txtStoreAuthor.Name = "txtStoreAuthor";
            txtStoreAuthor.Size = new Size(151, 23);
            txtStoreAuthor.TabIndex = 10;
            // 
            // txtStoreName
            // 
            txtStoreName.Location = new Point(186, 189);
            txtStoreName.Margin = new Padding(3, 2, 3, 2);
            txtStoreName.Name = "txtStoreName";
            txtStoreName.Size = new Size(151, 23);
            txtStoreName.TabIndex = 9;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(201, 326);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(128, 28);
            btnClose.TabIndex = 8;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSellBook
            // 
            btnSellBook.Location = new Point(18, 326);
            btnSellBook.Margin = new Padding(3, 2, 3, 2);
            btnSellBook.Name = "btnSellBook";
            btnSellBook.Size = new Size(128, 28);
            btnSellBook.TabIndex = 7;
            btnSellBook.Text = "Продать книгу";
            btnSellBook.UseVisualStyleBackColor = true;
            btnSellBook.Click += btnSellBook_Click;
            // 
            // lblStoreCode
            // 
            lblStoreCode.BackColor = Color.FromArgb(224, 224, 224);
            lblStoreCode.Location = new Point(18, 291);
            lblStoreCode.Name = "lblStoreCode";
            lblStoreCode.Size = new Size(147, 24);
            lblStoreCode.TabIndex = 6;
            lblStoreCode.Text = "Код Книги";
            // 
            // lblStorePage
            // 
            lblStorePage.BackColor = Color.FromArgb(224, 224, 224);
            lblStorePage.Location = new Point(18, 266);
            lblStorePage.Name = "lblStorePage";
            lblStorePage.Size = new Size(147, 24);
            lblStorePage.TabIndex = 5;
            lblStorePage.Text = "Кол-во страниц";
            // 
            // lblStorePrice
            // 
            lblStorePrice.BackColor = Color.FromArgb(224, 224, 224);
            lblStorePrice.Location = new Point(18, 240);
            lblStorePrice.Name = "lblStorePrice";
            lblStorePrice.Size = new Size(147, 24);
            lblStorePrice.TabIndex = 4;
            lblStorePrice.Text = "Цена";
            // 
            // lblStoreAuthor
            // 
            lblStoreAuthor.BackColor = Color.FromArgb(224, 224, 224);
            lblStoreAuthor.Location = new Point(18, 214);
            lblStoreAuthor.Name = "lblStoreAuthor";
            lblStoreAuthor.Size = new Size(147, 24);
            lblStoreAuthor.TabIndex = 3;
            lblStoreAuthor.Text = "Автор";
            // 
            // lblStoreName
            // 
            lblStoreName.BackColor = Color.FromArgb(224, 224, 224);
            lblStoreName.Location = new Point(18, 189);
            lblStoreName.Name = "lblStoreName";
            lblStoreName.Size = new Size(147, 24);
            lblStoreName.TabIndex = 2;
            lblStoreName.Text = "Название";
            // 
            // lstBook
            // 
            lstBook.FormattingEnabled = true;
            lstBook.HorizontalScrollbar = true;
            lstBook.ItemHeight = 15;
            lstBook.Items.AddRange(new object[] { "Список книг текущего жанра:" });
            lstBook.Location = new Point(18, 44);
            lstBook.Margin = new Padding(3, 2, 3, 2);
            lstBook.Name = "lstBook";
            lstBook.Size = new Size(320, 139);
            lstBook.TabIndex = 1;
            lstBook.SelectedIndexChanged += lstBook_SelectedIndexChanged;
            // 
            // txtShelfName
            // 
            txtShelfName.BackColor = Color.FromArgb(224, 224, 224);
            txtShelfName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            txtShelfName.Location = new Point(18, 8);
            txtShelfName.Name = "txtShelfName";
            txtShelfName.Size = new Size(319, 32);
            txtShelfName.TabIndex = 0;
            txtShelfName.Text = "Книги в шкафу";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnClearShelf);
            panel2.Controls.Add(lstGenres);
            panel2.Controls.Add(label9);
            panel2.Location = new Point(46, 58);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(181, 367);
            panel2.TabIndex = 1;
            // 
            // btnClearShelf
            // 
            btnClearShelf.Location = new Point(9, 313);
            btnClearShelf.Margin = new Padding(3, 2, 3, 2);
            btnClearShelf.Name = "btnClearShelf";
            btnClearShelf.Size = new Size(164, 34);
            btnClearShelf.TabIndex = 2;
            btnClearShelf.Text = "Очистить шкаф";
            btnClearShelf.UseVisualStyleBackColor = true;
            btnClearShelf.Click += btnClearShelf_Click;
            // 
            // lstGenres
            // 
            lstGenres.BackColor = Color.FromArgb(224, 224, 224);
            lstGenres.FormattingEnabled = true;
            lstGenres.ItemHeight = 15;
            lstGenres.Items.AddRange(new object[] { "Список жанров (шкафов)" });
            lstGenres.Location = new Point(10, 50);
            lstGenres.Margin = new Padding(3, 2, 3, 2);
            lstGenres.Name = "lstGenres";
            lstGenres.Size = new Size(162, 244);
            lstGenres.TabIndex = 1;
            lstGenres.SelectedIndexChanged += lstGenres_SelectedIndexChanged_1;
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(224, 224, 224);
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label9.Location = new Point(16, 9);
            label9.Name = "label9";
            label9.Size = new Size(150, 28);
            label9.TabIndex = 0;
            label9.Text = "Список жанров";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnFindBook);
            panel1.Controls.Add(txtSearchBook);
            panel1.Location = new Point(46, 7);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(542, 47);
            panel1.TabIndex = 0;
            // 
            // btnFindBook
            // 
            btnFindBook.Location = new Point(418, 10);
            btnFindBook.Margin = new Padding(3, 2, 3, 2);
            btnFindBook.Name = "btnFindBook";
            btnFindBook.Size = new Size(103, 28);
            btnFindBook.TabIndex = 3;
            btnFindBook.Text = "Найти";
            btnFindBook.UseVisualStyleBackColor = true;
            btnFindBook.Click += btnFindBook_Click;
            // 
            // txtSearchBook
            // 
            txtSearchBook.AccessibleDescription = "";
            txtSearchBook.AccessibleName = "";
            txtSearchBook.Location = new Point(10, 14);
            txtSearchBook.Margin = new Padding(3, 2, 3, 2);
            txtSearchBook.Name = "txtSearchBook";
            txtSearchBook.PlaceholderText = "Название или код книги";
            txtSearchBook.Size = new Size(235, 23);
            txtSearchBook.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.CausesValidation = false;
            tabPage1.Controls.Add(txtDelQueue);
            tabPage1.Controls.Add(label18);
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(label10);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(632, 554);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Поставки";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtDelQueue
            // 
            txtDelQueue.BackColor = Color.Silver;
            txtDelQueue.Location = new Point(184, 68);
            txtDelQueue.Margin = new Padding(3, 2, 3, 2);
            txtDelQueue.Name = "txtDelQueue";
            txtDelQueue.Size = new Size(90, 23);
            txtDelQueue.TabIndex = 7;
            // 
            // label18
            // 
            label18.BackColor = Color.Silver;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label18.Location = new Point(40, 61);
            label18.Name = "label18";
            label18.Size = new Size(111, 33);
            label18.TabIndex = 6;
            label18.Text = "В очереди:";
            label18.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnСonfirmSelect);
            groupBox4.Controls.Add(radioButton3);
            groupBox4.Controls.Add(radioButton2);
            groupBox4.Controls.Add(radioButton1);
            groupBox4.Location = new Point(40, 315);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(536, 113);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Ваши действия";
            // 
            // btnСonfirmSelect
            // 
            btnСonfirmSelect.Location = new Point(158, 65);
            btnСonfirmSelect.Margin = new Padding(3, 2, 3, 2);
            btnСonfirmSelect.Name = "btnСonfirmSelect";
            btnСonfirmSelect.Size = new Size(187, 33);
            btnСonfirmSelect.TabIndex = 3;
            btnСonfirmSelect.Text = "Подтвердить выбор";
            btnСonfirmSelect.UseVisualStyleBackColor = true;
            btnСonfirmSelect.Click += btnСonfirmSelect_Click;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.BackColor = Color.Silver;
            radioButton3.Location = new Point(363, 30);
            radioButton3.Margin = new Padding(3, 2, 3, 2);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(141, 19);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "Отклонить (Ошибка)";
            radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.Silver;
            radioButton2.Location = new Point(162, 30);
            radioButton2.Margin = new Padding(3, 2, 3, 2);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(140, 19);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Отклонить (Плагиат)";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.Silver;
            radioButton1.Location = new Point(14, 30);
            radioButton1.Margin = new Padding(3, 2, 3, 2);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(72, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Принять";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtDelBookPageCount);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(txtDelBookPrice);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(txtDelBookGenre);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(txtDelBookAuthor);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(txtDelBookName);
            groupBox3.Controls.Add(label11);
            groupBox3.Location = new Point(40, 104);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(540, 196);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Данные";
            // 
            // txtDelBookPageCount
            // 
            txtDelBookPageCount.Location = new Point(204, 158);
            txtDelBookPageCount.Margin = new Padding(3, 2, 3, 2);
            txtDelBookPageCount.Name = "txtDelBookPageCount";
            txtDelBookPageCount.ReadOnly = true;
            txtDelBookPageCount.Size = new Size(153, 23);
            txtDelBookPageCount.TabIndex = 9;
            // 
            // label15
            // 
            label15.BackColor = Color.Silver;
            label15.Location = new Point(14, 156);
            label15.Name = "label15";
            label15.Size = new Size(139, 28);
            label15.TabIndex = 8;
            label15.Text = "Страницы";
            // 
            // txtDelBookPrice
            // 
            txtDelBookPrice.Location = new Point(204, 125);
            txtDelBookPrice.Margin = new Padding(3, 2, 3, 2);
            txtDelBookPrice.Name = "txtDelBookPrice";
            txtDelBookPrice.ReadOnly = true;
            txtDelBookPrice.Size = new Size(153, 23);
            txtDelBookPrice.TabIndex = 7;
            // 
            // label14
            // 
            label14.BackColor = Color.Silver;
            label14.Location = new Point(14, 123);
            label14.Name = "label14";
            label14.Size = new Size(139, 25);
            label14.TabIndex = 6;
            label14.Text = "Цена";
            // 
            // txtDelBookGenre
            // 
            txtDelBookGenre.Location = new Point(204, 92);
            txtDelBookGenre.Margin = new Padding(3, 2, 3, 2);
            txtDelBookGenre.Name = "txtDelBookGenre";
            txtDelBookGenre.ReadOnly = true;
            txtDelBookGenre.Size = new Size(153, 23);
            txtDelBookGenre.TabIndex = 5;
            // 
            // label13
            // 
            label13.BackColor = Color.Silver;
            label13.Location = new Point(14, 90);
            label13.Name = "label13";
            label13.Size = new Size(139, 25);
            label13.TabIndex = 4;
            label13.Text = "Жанр";
            // 
            // txtDelBookAuthor
            // 
            txtDelBookAuthor.Location = new Point(204, 59);
            txtDelBookAuthor.Margin = new Padding(3, 2, 3, 2);
            txtDelBookAuthor.Name = "txtDelBookAuthor";
            txtDelBookAuthor.ReadOnly = true;
            txtDelBookAuthor.Size = new Size(153, 23);
            txtDelBookAuthor.TabIndex = 3;
            // 
            // label12
            // 
            label12.BackColor = Color.Silver;
            label12.Location = new Point(14, 57);
            label12.Name = "label12";
            label12.Size = new Size(139, 25);
            label12.TabIndex = 2;
            label12.Text = "Автор";
            // 
            // txtDelBookName
            // 
            txtDelBookName.Location = new Point(204, 26);
            txtDelBookName.Margin = new Padding(3, 2, 3, 2);
            txtDelBookName.Name = "txtDelBookName";
            txtDelBookName.ReadOnly = true;
            txtDelBookName.Size = new Size(153, 23);
            txtDelBookName.TabIndex = 1;
            // 
            // label11
            // 
            label11.BackColor = Color.Silver;
            label11.Location = new Point(14, 24);
            label11.Name = "label11";
            label11.Size = new Size(139, 25);
            label11.TabIndex = 0;
            label11.Text = "Название";
            // 
            // label10
            // 
            label10.BackColor = Color.Silver;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label10.Location = new Point(41, 14);
            label10.Name = "label10";
            label10.Size = new Size(538, 36);
            label10.TabIndex = 3;
            label10.Text = "Поступила книга";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txtClientCount);
            tabPage2.Controls.Add(label25);
            tabPage2.Controls.Add(groupBox7);
            tabPage2.Controls.Add(groupBox6);
            tabPage2.Controls.Add(groupBox5);
            tabPage2.Controls.Add(listClient);
            tabPage2.Controls.Add(label16);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(632, 554);
            tabPage2.TabIndex = 3;
            tabPage2.Text = "Покупатели";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtClientCount
            // 
            txtClientCount.BackColor = Color.Silver;
            txtClientCount.Location = new Point(192, 16);
            txtClientCount.Margin = new Padding(3, 2, 3, 2);
            txtClientCount.Name = "txtClientCount";
            txtClientCount.Size = new Size(90, 23);
            txtClientCount.TabIndex = 13;
            // 
            // label25
            // 
            label25.BackColor = Color.Silver;
            label25.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label25.Location = new Point(49, 13);
            label25.Name = "label25";
            label25.Size = new Size(111, 21);
            label25.TabIndex = 12;
            label25.Text = "В очереди:";
            label25.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(textBox8);
            groupBox7.Controls.Add(textBox7);
            groupBox7.Controls.Add(label24);
            groupBox7.Controls.Add(label23);
            groupBox7.Location = new Point(49, 484);
            groupBox7.Margin = new Padding(3, 2, 3, 2);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(3, 2, 3, 2);
            groupBox7.Size = new Size(541, 74);
            groupBox7.TabIndex = 11;
            groupBox7.TabStop = false;
            groupBox7.Text = "Статистика";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(246, 44);
            textBox8.Margin = new Padding(3, 2, 3, 2);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(61, 23);
            textBox8.TabIndex = 3;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(246, 18);
            textBox7.Margin = new Padding(3, 2, 3, 2);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(61, 23);
            textBox7.TabIndex = 2;
            // 
            // label24
            // 
            label24.BackColor = Color.Silver;
            label24.Location = new Point(12, 45);
            label24.Name = "label24";
            label24.Size = new Size(201, 20);
            label24.TabIndex = 1;
            label24.Text = "Довольных клиентов:";
            // 
            // label23
            // 
            label23.BackColor = Color.Silver;
            label23.Location = new Point(12, 17);
            label23.Name = "label23";
            label23.Size = new Size(201, 21);
            label23.TabIndex = 0;
            label23.Text = "Недовольных клиентов:";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(button3);
            groupBox6.Controls.Add(button2);
            groupBox6.Location = new Point(48, 427);
            groupBox6.Margin = new Padding(3, 2, 3, 2);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(3, 2, 3, 2);
            groupBox6.Size = new Size(540, 53);
            groupBox6.TabIndex = 10;
            groupBox6.TabStop = false;
            groupBox6.Text = "Цена";
            // 
            // button3
            // 
            button3.Location = new Point(336, 14);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(154, 26);
            button3.TabIndex = 2;
            button3.Text = "Отказать";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(167, 14);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(154, 26);
            button2.TabIndex = 1;
            button2.Text = "Продать";
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.Gainsboro;
            groupBox5.Controls.Add(textBox12);
            groupBox5.Controls.Add(textBox11);
            groupBox5.Controls.Add(textBox10);
            groupBox5.Controls.Add(textBox9);
            groupBox5.Controls.Add(label22);
            groupBox5.Controls.Add(label21);
            groupBox5.Controls.Add(label19);
            groupBox5.Controls.Add(label20);
            groupBox5.Controls.Add(comboBox1);
            groupBox5.Controls.Add(label17);
            groupBox5.Location = new Point(47, 221);
            groupBox5.Margin = new Padding(3, 2, 3, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 2, 3, 2);
            groupBox5.Size = new Size(536, 197);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Выбранный покупатель";
            // 
            // textBox12
            // 
            textBox12.Location = new Point(235, 156);
            textBox12.Margin = new Padding(3, 2, 3, 2);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(176, 23);
            textBox12.TabIndex = 10;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(238, 124);
            textBox11.Margin = new Padding(3, 2, 3, 2);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(176, 23);
            textBox11.TabIndex = 9;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(240, 88);
            textBox10.Margin = new Padding(3, 2, 3, 2);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(176, 23);
            textBox10.TabIndex = 8;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(241, 56);
            textBox9.Margin = new Padding(3, 2, 3, 2);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(176, 23);
            textBox9.TabIndex = 7;
            // 
            // label22
            // 
            label22.BackColor = Color.Silver;
            label22.Location = new Point(15, 158);
            label22.Name = "label22";
            label22.Size = new Size(141, 23);
            label22.TabIndex = 6;
            label22.Text = "Макс цена";
            // 
            // label21
            // 
            label21.BackColor = Color.Silver;
            label21.Location = new Point(15, 122);
            label21.Name = "label21";
            label21.Size = new Size(141, 23);
            label21.TabIndex = 5;
            label21.Text = "Жанр";
            // 
            // label19
            // 
            label19.BackColor = Color.Silver;
            label19.Location = new Point(15, 88);
            label19.Name = "label19";
            label19.Size = new Size(141, 23);
            label19.TabIndex = 4;
            label19.Text = "Автор";
            // 
            // label20
            // 
            label20.BackColor = Color.Silver;
            label20.Location = new Point(15, 57);
            label20.Name = "label20";
            label20.Size = new Size(141, 23);
            label20.TabIndex = 3;
            label20.Text = "Название";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(238, 25);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(177, 23);
            comboBox1.TabIndex = 1;
            // 
            // label17
            // 
            label17.BackColor = Color.Silver;
            label17.Location = new Point(15, 26);
            label17.Name = "label17";
            label17.Size = new Size(141, 23);
            label17.TabIndex = 0;
            label17.Text = "Тип запроса";
            // 
            // listClient
            // 
            listClient.FormattingEnabled = true;
            listClient.ItemHeight = 15;
            listClient.Location = new Point(48, 86);
            listClient.Margin = new Padding(3, 2, 3, 2);
            listClient.Name = "listClient";
            listClient.Size = new Size(531, 124);
            listClient.TabIndex = 8;
            listClient.SelectedIndexChanged += listClient_SelectedIndexChanged;
            // 
            // label16
            // 
            label16.BackColor = Color.Silver;
            label16.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label16.Location = new Point(48, 49);
            label16.Name = "label16";
            label16.Size = new Size(531, 27);
            label16.TabIndex = 7;
            label16.Text = "Очередь";
            // 
            // lblBalance
            // 
            lblBalance.BackColor = Color.FromArgb(224, 224, 224);
            lblBalance.Location = new Point(577, 48);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(105, 32);
            lblBalance.TabIndex = 1;
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(224, 224, 224);
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.Location = new Point(324, 48);
            label7.Name = "label7";
            label7.Size = new Size(242, 32);
            label7.TabIndex = 0;
            label7.Text = "Баланс магазина";
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(224, 224, 224);
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label8.Location = new Point(51, 4);
            label8.Name = "label8";
            label8.Size = new Size(631, 32);
            label8.TabIndex = 2;
            // 
            // lblday
            // 
            lblday.BackColor = Color.Silver;
            lblday.Location = new Point(51, 48);
            lblday.Name = "lblday";
            lblday.Size = new Size(46, 16);
            lblday.TabIndex = 3;
            lblday.Text = "День:";
            lblday.Visible = false;
            // 
            // lbltime
            // 
            lbltime.BackColor = Color.Silver;
            lbltime.Location = new Point(120, 48);
            lbltime.Name = "lbltime";
            lbltime.Size = new Size(55, 16);
            lbltime.TabIndex = 4;
            lbltime.Text = "Время:";
            // 
            // txtday
            // 
            txtday.Location = new Point(51, 68);
            txtday.Margin = new Padding(3, 2, 3, 2);
            txtday.Name = "txtday";
            txtday.Size = new Size(47, 23);
            txtday.TabIndex = 5;
            txtday.Visible = false;
            // 
            // txttime
            // 
            txttime.Location = new Point(120, 68);
            txttime.Margin = new Padding(3, 2, 3, 2);
            txttime.Name = "txttime";
            txttime.Size = new Size(56, 23);
            txttime.TabIndex = 6;
            // 
            // label26
            // 
            label26.BackColor = Color.FromArgb(224, 224, 224);
            label26.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label26.Location = new Point(324, 91);
            label26.Name = "label26";
            label26.Size = new Size(242, 32);
            label26.TabIndex = 7;
            label26.Text = "Кол-во недовольных клиентов";
            // 
            // label27
            // 
            label27.BackColor = Color.FromArgb(224, 224, 224);
            label27.Location = new Point(577, 91);
            label27.Name = "label27";
            label27.Size = new Size(105, 32);
            label27.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(739, 745);
            Controls.Add(label27);
            Controls.Add(label26);
            Controls.Add(txttime);
            Controls.Add(txtday);
            Controls.Add(lbltime);
            Controls.Add(lblday);
            Controls.Add(label8);
            Controls.Add(tabControl1);
            Controls.Add(label7);
            Controls.Add(lblBalance);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabNewBook.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabStore.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabNewBook;
        private GroupBox groupBox1;
        private TabPage tabStore;
        private GroupBox groupBox2;
        private TextBox txtPageCount;
        private Label label5;
        private TextBox txtPrice;
        private Label label4;
        private TextBox txtAuthor;
        private Label label3;
        private TextBox txtBookName;
        private Label label2;
        private Label label1;
        private Label txtStatus;
        private Button btnAddBook;
        private Button btnGenerateRandom;
        private Panel panel1;
        private Label lblBalance;
        private Label label7;
        private Panel panel3;
        private Label txtShelfName;
        private Panel panel2;
        private Button btnClearShelf;
        private ListBox lstGenres;
        private Label label9;
        private Button btnFindBook;
        private TextBox txtSearchBook;
        private Label lblStoreCode;
        private Label lblStorePage;
        private Label lblStorePrice;
        private Label lblStoreAuthor;
        private Label lblStoreName;
        private ListBox lstBook;
        private Button btnClose;
        private Button btnSellBook;
        private TextBox textBox5;
        private TextBox txtStorePage;
        private TextBox txtStorePrice;
        private TextBox txtStoreAuthor;
        private TextBox txtStoreName;
        private TextBox txtStoreCode;
        private TextBox txtGenre;
        private Label label6;
        private TextBox txtBookID;
        private Label label8;
        private TabPage tabPage1;
        private GroupBox groupBox4;
        private Button btnСonfirmSelect;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox3;
        private TextBox txtDelBookPageCount;
        private Label label15;
        private TextBox txtDelBookPrice;
        private Label label14;
        private TextBox txtDelBookGenre;
        private Label label13;
        private TextBox txtDelBookAuthor;
        private Label label12;
        private TextBox txtDelBookName;
        private Label label11;
        private Label label10;
        private TabPage tabPage2;
        private GroupBox groupBox7;
        private TextBox textBox8;
        private TextBox textBox7;
        private Label label24;
        private Label label23;
        private GroupBox groupBox6;
        private Button button3;
        private Button button2;
        private GroupBox groupBox5;
        private TextBox textBox12;
        private TextBox textBox11;
        private TextBox textBox10;
        private TextBox textBox9;
        private Label label22;
        private Label label21;
        private Label label19;
        private Label label20;
        private ComboBox comboBox1;
        private Label label17;
        private ListBox listClient;
        private Label label16;
        private Label lblday;
        private Label lbltime;
        private TextBox txtday;
        private TextBox txttime;
        private TextBox txtDelQueue;
        private Label label18;
        private TextBox txtClientCount;
        private Label label25;
        private Label label26;
        private Label label27;
    }
}
