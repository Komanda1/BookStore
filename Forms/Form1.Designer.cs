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
            groupBox4 = new GroupBox();
            button1 = new Button();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            groupBox3 = new GroupBox();
            textBox6 = new TextBox();
            label15 = new Label();
            textBox4 = new TextBox();
            label14 = new Label();
            textBox3 = new TextBox();
            label13 = new Label();
            textBox2 = new TextBox();
            label12 = new Label();
            textBox1 = new TextBox();
            label11 = new Label();
            label10 = new Label();
            tabPage2 = new TabPage();
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
            listBox1 = new ListBox();
            label16 = new Label();
            lblBalance = new Label();
            label7 = new Label();
            label8 = new Label();
            lblday = new Label();
            lbltime = new Label();
            txtday = new TextBox();
            txttime = new TextBox();
            label18 = new Label();
            textBox13 = new TextBox();
            textBox14 = new TextBox();
            label25 = new Label();
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
            tabControl1.Location = new Point(51, 174);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(732, 776);
            tabControl1.TabIndex = 0;
            // 
            // tabNewBook
            // 
            tabNewBook.BackColor = Color.FromArgb(224, 224, 224);
            tabNewBook.Controls.Add(groupBox2);
            tabNewBook.Controls.Add(groupBox1);
            tabNewBook.Location = new Point(4, 29);
            tabNewBook.Name = "tabNewBook";
            tabNewBook.Padding = new Padding(3);
            tabNewBook.Size = new Size(724, 743);
            tabNewBook.TabIndex = 0;
            tabNewBook.Text = "Заказать книгу";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(txtStatus);
            groupBox2.Controls.Add(btnAddBook);
            groupBox2.Controls.Add(btnGenerateRandom);
            groupBox2.Location = new Point(38, 441);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(639, 166);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Управление";
            // 
            // txtStatus
            // 
            txtStatus.BackColor = Color.FromArgb(224, 224, 224);
            txtStatus.Location = new Point(12, 108);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(566, 37);
            txtStatus.TabIndex = 2;
            txtStatus.Text = "Строка состояния";
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(349, 38);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(229, 37);
            btnAddBook.TabIndex = 1;
            btnAddBook.Text = "Добавить книгу";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click_1;
            // 
            // btnGenerateRandom
            // 
            btnGenerateRandom.Location = new Point(12, 38);
            btnGenerateRandom.Name = "btnGenerateRandom";
            btnGenerateRandom.Size = new Size(229, 37);
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
            groupBox1.Location = new Point(39, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(638, 409);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Данные книги";
            // 
            // txtBookID
            // 
            txtBookID.BackColor = Color.FromArgb(224, 224, 224);
            txtBookID.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtBookID.Location = new Point(292, 49);
            txtBookID.Name = "txtBookID";
            txtBookID.Size = new Size(285, 27);
            txtBookID.TabIndex = 13;
            // 
            // txtGenre
            // 
            txtGenre.BackColor = Color.FromArgb(224, 224, 224);
            txtGenre.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtGenre.Location = new Point(292, 354);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(285, 27);
            txtGenre.TabIndex = 12;
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(224, 224, 224);
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(11, 342);
            label6.Name = "label6";
            label6.Size = new Size(234, 48);
            label6.TabIndex = 11;
            label6.Text = "Жанр";
            // 
            // txtPageCount
            // 
            txtPageCount.BackColor = Color.FromArgb(224, 224, 224);
            txtPageCount.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtPageCount.Location = new Point(292, 293);
            txtPageCount.Name = "txtPageCount";
            txtPageCount.Size = new Size(285, 27);
            txtPageCount.TabIndex = 9;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(224, 224, 224);
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(11, 281);
            label5.Name = "label5";
            label5.Size = new Size(234, 48);
            label5.TabIndex = 8;
            label5.Text = "Кол-во страниц";
            // 
            // txtPrice
            // 
            txtPrice.BackColor = Color.FromArgb(224, 224, 224);
            txtPrice.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtPrice.Location = new Point(292, 231);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(285, 27);
            txtPrice.TabIndex = 7;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(224, 224, 224);
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(11, 219);
            label4.Name = "label4";
            label4.Size = new Size(234, 48);
            label4.TabIndex = 6;
            label4.Text = "Цена";
            // 
            // txtAuthor
            // 
            txtAuthor.BackColor = Color.FromArgb(224, 224, 224);
            txtAuthor.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtAuthor.Location = new Point(292, 169);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(285, 27);
            txtAuthor.TabIndex = 5;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(224, 224, 224);
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(11, 157);
            label3.Name = "label3";
            label3.Size = new Size(234, 48);
            label3.TabIndex = 4;
            label3.Text = "Автор";
            // 
            // txtBookName
            // 
            txtBookName.BackColor = Color.FromArgb(224, 224, 224);
            txtBookName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            txtBookName.Location = new Point(292, 110);
            txtBookName.Name = "txtBookName";
            txtBookName.Size = new Size(285, 27);
            txtBookName.TabIndex = 3;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(224, 224, 224);
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(11, 98);
            label2.Name = "label2";
            label2.Size = new Size(234, 48);
            label2.TabIndex = 2;
            label2.Text = "Название";
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(224, 224, 224);
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(11, 38);
            label1.Name = "label1";
            label1.Size = new Size(234, 48);
            label1.TabIndex = 0;
            label1.Text = "Код Книги";
            // 
            // tabStore
            // 
            tabStore.BackColor = Color.FromArgb(224, 224, 224);
            tabStore.Controls.Add(panel3);
            tabStore.Controls.Add(panel2);
            tabStore.Controls.Add(panel1);
            tabStore.Location = new Point(4, 29);
            tabStore.Name = "tabStore";
            tabStore.Padding = new Padding(3);
            tabStore.Size = new Size(724, 743);
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
            panel3.Location = new Point(273, 80);
            panel3.Name = "panel3";
            panel3.Size = new Size(399, 487);
            panel3.TabIndex = 2;
            // 
            // txtStoreCode
            // 
            txtStoreCode.Location = new Point(213, 388);
            txtStoreCode.Name = "txtStoreCode";
            txtStoreCode.Size = new Size(172, 27);
            txtStoreCode.TabIndex = 13;
            // 
            // txtStorePage
            // 
            txtStorePage.Location = new Point(213, 354);
            txtStorePage.Name = "txtStorePage";
            txtStorePage.Size = new Size(172, 27);
            txtStorePage.TabIndex = 12;
            // 
            // txtStorePrice
            // 
            txtStorePrice.Location = new Point(213, 320);
            txtStorePrice.Name = "txtStorePrice";
            txtStorePrice.Size = new Size(172, 27);
            txtStorePrice.TabIndex = 11;
            // 
            // txtStoreAuthor
            // 
            txtStoreAuthor.Location = new Point(213, 287);
            txtStoreAuthor.Name = "txtStoreAuthor";
            txtStoreAuthor.Size = new Size(172, 27);
            txtStoreAuthor.TabIndex = 10;
            // 
            // txtStoreName
            // 
            txtStoreName.Location = new Point(213, 252);
            txtStoreName.Name = "txtStoreName";
            txtStoreName.Size = new Size(172, 27);
            txtStoreName.TabIndex = 9;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(230, 435);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(146, 38);
            btnClose.TabIndex = 8;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSellBook
            // 
            btnSellBook.Location = new Point(20, 435);
            btnSellBook.Name = "btnSellBook";
            btnSellBook.Size = new Size(146, 38);
            btnSellBook.TabIndex = 7;
            btnSellBook.Text = "Продать книгу";
            btnSellBook.UseVisualStyleBackColor = true;
            btnSellBook.Click += btnSellBook_Click;
            // 
            // lblStoreCode
            // 
            lblStoreCode.BackColor = Color.FromArgb(224, 224, 224);
            lblStoreCode.Location = new Point(20, 388);
            lblStoreCode.Name = "lblStoreCode";
            lblStoreCode.Size = new Size(168, 32);
            lblStoreCode.TabIndex = 6;
            lblStoreCode.Text = "Код Книги";
            // 
            // lblStorePage
            // 
            lblStorePage.BackColor = Color.FromArgb(224, 224, 224);
            lblStorePage.Location = new Point(20, 354);
            lblStorePage.Name = "lblStorePage";
            lblStorePage.Size = new Size(168, 32);
            lblStorePage.TabIndex = 5;
            lblStorePage.Text = "Кол-во страниц";
            // 
            // lblStorePrice
            // 
            lblStorePrice.BackColor = Color.FromArgb(224, 224, 224);
            lblStorePrice.Location = new Point(20, 320);
            lblStorePrice.Name = "lblStorePrice";
            lblStorePrice.Size = new Size(168, 32);
            lblStorePrice.TabIndex = 4;
            lblStorePrice.Text = "Цена";
            // 
            // lblStoreAuthor
            // 
            lblStoreAuthor.BackColor = Color.FromArgb(224, 224, 224);
            lblStoreAuthor.Location = new Point(20, 286);
            lblStoreAuthor.Name = "lblStoreAuthor";
            lblStoreAuthor.Size = new Size(168, 32);
            lblStoreAuthor.TabIndex = 3;
            lblStoreAuthor.Text = "Автор";
            // 
            // lblStoreName
            // 
            lblStoreName.BackColor = Color.FromArgb(224, 224, 224);
            lblStoreName.Location = new Point(20, 252);
            lblStoreName.Name = "lblStoreName";
            lblStoreName.Size = new Size(168, 32);
            lblStoreName.TabIndex = 2;
            lblStoreName.Text = "Название";
            // 
            // lstBook
            // 
            lstBook.FormattingEnabled = true;
            lstBook.HorizontalScrollbar = true;
            lstBook.Items.AddRange(new object[] { "Список книг текущего жанра:" });
            lstBook.Location = new Point(20, 59);
            lstBook.Name = "lstBook";
            lstBook.Size = new Size(365, 184);
            lstBook.TabIndex = 1;
            lstBook.SelectedIndexChanged += lstBook_SelectedIndexChanged;
            // 
            // txtShelfName
            // 
            txtShelfName.BackColor = Color.FromArgb(224, 224, 224);
            txtShelfName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            txtShelfName.Location = new Point(20, 10);
            txtShelfName.Name = "txtShelfName";
            txtShelfName.Size = new Size(365, 42);
            txtShelfName.TabIndex = 0;
            txtShelfName.Text = "Книги в шкафу";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnClearShelf);
            panel2.Controls.Add(lstGenres);
            panel2.Controls.Add(label9);
            panel2.Location = new Point(53, 78);
            panel2.Name = "panel2";
            panel2.Size = new Size(207, 489);
            panel2.TabIndex = 1;
            // 
            // btnClearShelf
            // 
            btnClearShelf.Location = new Point(10, 417);
            btnClearShelf.Name = "btnClearShelf";
            btnClearShelf.Size = new Size(187, 46);
            btnClearShelf.TabIndex = 2;
            btnClearShelf.Text = "Очистить шкаф";
            btnClearShelf.UseVisualStyleBackColor = true;
            btnClearShelf.Click += btnClearShelf_Click;
            // 
            // lstGenres
            // 
            lstGenres.BackColor = Color.FromArgb(224, 224, 224);
            lstGenres.FormattingEnabled = true;
            lstGenres.Items.AddRange(new object[] { "Список жанров (шкафов)" });
            lstGenres.Location = new Point(12, 66);
            lstGenres.Name = "lstGenres";
            lstGenres.Size = new Size(184, 324);
            lstGenres.TabIndex = 1;
            lstGenres.SelectedIndexChanged += lstGenres_SelectedIndexChanged_1;
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(224, 224, 224);
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label9.Location = new Point(18, 12);
            label9.Name = "label9";
            label9.Size = new Size(171, 37);
            label9.TabIndex = 0;
            label9.Text = "Список жанров";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnFindBook);
            panel1.Controls.Add(txtSearchBook);
            panel1.Location = new Point(53, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(619, 63);
            panel1.TabIndex = 0;
            // 
            // btnFindBook
            // 
            btnFindBook.Location = new Point(478, 14);
            btnFindBook.Name = "btnFindBook";
            btnFindBook.Size = new Size(118, 37);
            btnFindBook.TabIndex = 3;
            btnFindBook.Text = "Найти";
            btnFindBook.UseVisualStyleBackColor = true;
            btnFindBook.Click += btnFindBook_Click;
            // 
            // txtSearchBook
            // 
            txtSearchBook.Location = new Point(12, 19);
            txtSearchBook.Name = "txtSearchBook";
            txtSearchBook.Size = new Size(268, 27);
            txtSearchBook.TabIndex = 2;
            txtSearchBook.Text = "Название или код книги";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(textBox13);
            tabPage1.Controls.Add(label18);
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(label10);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(724, 743);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Поставки";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button1);
            groupBox4.Controls.Add(radioButton3);
            groupBox4.Controls.Add(radioButton2);
            groupBox4.Controls.Add(radioButton1);
            groupBox4.Location = new Point(46, 420);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(613, 151);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Ваши действия";
            // 
            // button1
            // 
            button1.Location = new Point(180, 87);
            button1.Name = "button1";
            button1.Size = new Size(214, 44);
            button1.TabIndex = 3;
            button1.Text = "Подтвердить выбор";
            button1.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.BackColor = Color.Silver;
            radioButton3.Location = new Point(415, 40);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(173, 24);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "Отклонить (Ошибка)";
            radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.Silver;
            radioButton2.Location = new Point(185, 40);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(173, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Отклонить (Плагиат)";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.Silver;
            radioButton1.Location = new Point(16, 40);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(90, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Принять";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox6);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(textBox4);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(textBox3);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(textBox2);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(label11);
            groupBox3.Location = new Point(46, 139);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(617, 262);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Данные";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(233, 211);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(174, 27);
            textBox6.TabIndex = 9;
            // 
            // label15
            // 
            label15.BackColor = Color.Silver;
            label15.Location = new Point(16, 208);
            label15.Name = "label15";
            label15.Size = new Size(159, 38);
            label15.TabIndex = 8;
            label15.Text = "Страницы";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(233, 167);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(174, 27);
            textBox4.TabIndex = 7;
            // 
            // label14
            // 
            label14.BackColor = Color.Silver;
            label14.Location = new Point(16, 164);
            label14.Name = "label14";
            label14.Size = new Size(159, 33);
            label14.TabIndex = 6;
            label14.Text = "Цена";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(233, 123);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(174, 27);
            textBox3.TabIndex = 5;
            // 
            // label13
            // 
            label13.BackColor = Color.Silver;
            label13.Location = new Point(16, 120);
            label13.Name = "label13";
            label13.Size = new Size(159, 33);
            label13.TabIndex = 4;
            label13.Text = "Жанр";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(233, 79);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(174, 27);
            textBox2.TabIndex = 3;
            // 
            // label12
            // 
            label12.BackColor = Color.Silver;
            label12.Location = new Point(16, 76);
            label12.Name = "label12";
            label12.Size = new Size(159, 33);
            label12.TabIndex = 2;
            label12.Text = "Автор";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(233, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 27);
            textBox1.TabIndex = 1;
            // 
            // label11
            // 
            label11.BackColor = Color.Silver;
            label11.Location = new Point(16, 32);
            label11.Name = "label11";
            label11.Size = new Size(159, 33);
            label11.TabIndex = 0;
            label11.Text = "Название";
            // 
            // label10
            // 
            label10.BackColor = Color.Silver;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label10.Location = new Point(47, 18);
            label10.Name = "label10";
            label10.Size = new Size(615, 48);
            label10.TabIndex = 3;
            label10.Text = "Поступила книга";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox14);
            tabPage2.Controls.Add(label25);
            tabPage2.Controls.Add(groupBox7);
            tabPage2.Controls.Add(groupBox6);
            tabPage2.Controls.Add(groupBox5);
            tabPage2.Controls.Add(listBox1);
            tabPage2.Controls.Add(label16);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(724, 743);
            tabPage2.TabIndex = 3;
            tabPage2.Text = "Покупатели";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(textBox8);
            groupBox7.Controls.Add(textBox7);
            groupBox7.Controls.Add(label24);
            groupBox7.Controls.Add(label23);
            groupBox7.Location = new Point(56, 646);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(618, 99);
            groupBox7.TabIndex = 11;
            groupBox7.TabStop = false;
            groupBox7.Text = "Статистика";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(281, 59);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(69, 27);
            textBox8.TabIndex = 3;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(281, 24);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(69, 27);
            textBox7.TabIndex = 2;
            // 
            // label24
            // 
            label24.BackColor = Color.Silver;
            label24.Location = new Point(14, 60);
            label24.Name = "label24";
            label24.Size = new Size(230, 26);
            label24.TabIndex = 1;
            label24.Text = "Довольных клиентов:";
            // 
            // label23
            // 
            label23.BackColor = Color.Silver;
            label23.Location = new Point(14, 23);
            label23.Name = "label23";
            label23.Size = new Size(230, 28);
            label23.TabIndex = 0;
            label23.Text = "Недовольных клиентов:";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(button3);
            groupBox6.Controls.Add(button2);
            groupBox6.Location = new Point(55, 569);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(617, 71);
            groupBox6.TabIndex = 10;
            groupBox6.TabStop = false;
            groupBox6.Text = "Цена";
            // 
            // button3
            // 
            button3.Location = new Point(384, 18);
            button3.Name = "button3";
            button3.Size = new Size(176, 35);
            button3.TabIndex = 2;
            button3.Text = "Отказать";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(191, 18);
            button2.Name = "button2";
            button2.Size = new Size(176, 35);
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
            groupBox5.Location = new Point(54, 295);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(612, 263);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Выбранный покупатель";
            // 
            // textBox12
            // 
            textBox12.Location = new Point(269, 208);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(200, 27);
            textBox12.TabIndex = 10;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(272, 165);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(200, 27);
            textBox11.TabIndex = 9;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(274, 118);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(200, 27);
            textBox10.TabIndex = 8;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(275, 74);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(200, 27);
            textBox9.TabIndex = 7;
            // 
            // label22
            // 
            label22.BackColor = Color.Silver;
            label22.Location = new Point(17, 210);
            label22.Name = "label22";
            label22.Size = new Size(161, 31);
            label22.TabIndex = 6;
            label22.Text = "Макс цена";
            // 
            // label21
            // 
            label21.BackColor = Color.Silver;
            label21.Location = new Point(17, 163);
            label21.Name = "label21";
            label21.Size = new Size(161, 31);
            label21.TabIndex = 5;
            label21.Text = "Жанр";
            // 
            // label19
            // 
            label19.BackColor = Color.Silver;
            label19.Location = new Point(17, 118);
            label19.Name = "label19";
            label19.Size = new Size(161, 31);
            label19.TabIndex = 4;
            label19.Text = "Автор";
            // 
            // label20
            // 
            label20.BackColor = Color.Silver;
            label20.Location = new Point(17, 76);
            label20.Name = "label20";
            label20.Size = new Size(161, 31);
            label20.TabIndex = 3;
            label20.Text = "Название";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(272, 33);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(202, 28);
            comboBox1.TabIndex = 1;
            // 
            // label17
            // 
            label17.BackColor = Color.Silver;
            label17.Location = new Point(17, 34);
            label17.Name = "label17";
            label17.Size = new Size(161, 31);
            label17.TabIndex = 0;
            label17.Text = "Тип запроса";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(55, 115);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(606, 164);
            listBox1.TabIndex = 8;
            // 
            // label16
            // 
            label16.BackColor = Color.Silver;
            label16.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label16.Location = new Point(55, 65);
            label16.Name = "label16";
            label16.Size = new Size(607, 36);
            label16.TabIndex = 7;
            label16.Text = "Очередь";
            // 
            // lblBalance
            // 
            lblBalance.BackColor = Color.FromArgb(224, 224, 224);
            lblBalance.Location = new Point(659, 64);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(120, 42);
            lblBalance.TabIndex = 1;
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(224, 224, 224);
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.Location = new Point(370, 64);
            label7.Name = "label7";
            label7.Size = new Size(277, 43);
            label7.TabIndex = 0;
            label7.Text = "Баланс магазина";
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(224, 224, 224);
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label8.Location = new Point(58, 5);
            label8.Name = "label8";
            label8.Size = new Size(721, 43);
            label8.TabIndex = 2;
            // 
            // lblday
            // 
            lblday.BackColor = Color.Silver;
            lblday.Location = new Point(58, 64);
            lblday.Name = "lblday";
            lblday.Size = new Size(52, 22);
            lblday.TabIndex = 3;
            lblday.Text = "День:";
            // 
            // lbltime
            // 
            lbltime.BackColor = Color.Silver;
            lbltime.Location = new Point(137, 64);
            lbltime.Name = "lbltime";
            lbltime.Size = new Size(63, 22);
            lbltime.TabIndex = 4;
            lbltime.Text = "Время:";
            // 
            // txtday
            // 
            txtday.Location = new Point(58, 91);
            txtday.Name = "txtday";
            txtday.Size = new Size(53, 27);
            txtday.TabIndex = 5;
            // 
            // txttime
            // 
            txttime.Location = new Point(137, 91);
            txttime.Name = "txttime";
            txttime.Size = new Size(63, 27);
            txttime.TabIndex = 6;
            // 
            // label18
            // 
            label18.BackColor = Color.Silver;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label18.Location = new Point(46, 81);
            label18.Name = "label18";
            label18.Size = new Size(127, 44);
            label18.TabIndex = 6;
            label18.Text = "В очереди:";
            label18.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox13
            // 
            textBox13.BackColor = Color.Silver;
            textBox13.Location = new Point(210, 90);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(102, 27);
            textBox13.TabIndex = 7;
            // 
            // textBox14
            // 
            textBox14.BackColor = Color.Silver;
            textBox14.Location = new Point(220, 21);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(102, 27);
            textBox14.TabIndex = 13;
            // 
            // label25
            // 
            label25.BackColor = Color.Silver;
            label25.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label25.Location = new Point(56, 17);
            label25.Name = "label25";
            label25.Size = new Size(127, 28);
            label25.TabIndex = 12;
            label25.Text = "В очереди:";
            label25.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            label26.BackColor = Color.FromArgb(224, 224, 224);
            label26.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label26.Location = new Point(370, 121);
            label26.Name = "label26";
            label26.Size = new Size(277, 43);
            label26.TabIndex = 7;
            label26.Text = "Кол-во недовольных клиентов";
            // 
            // label27
            // 
            label27.BackColor = Color.FromArgb(224, 224, 224);
            label27.Location = new Point(659, 121);
            label27.Name = "label27";
            label27.Size = new Size(120, 42);
            label27.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(845, 960);
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
        private Button button1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox3;
        private TextBox textBox6;
        private Label label15;
        private TextBox textBox4;
        private Label label14;
        private TextBox textBox3;
        private Label label13;
        private TextBox textBox2;
        private Label label12;
        private TextBox textBox1;
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
        private ListBox listBox1;
        private Label label16;
        private Label lblday;
        private Label lbltime;
        private TextBox txtday;
        private TextBox txttime;
        private TextBox textBox13;
        private Label label18;
        private TextBox textBox14;
        private Label label25;
        private Label label26;
        private Label label27;
    }
}
