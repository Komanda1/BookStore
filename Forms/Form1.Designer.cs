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
            lblBalance = new Label();
            label7 = new Label();
            tabControl1.SuspendLayout();
            tabNewBook.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabStore.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabNewBook);
            tabControl1.Controls.Add(tabStore);
            tabControl1.Location = new Point(2, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(670, 694);
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
            tabNewBook.Size = new Size(662, 661);
            tabNewBook.TabIndex = 0;
            tabNewBook.Text = "Новая книга";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(txtStatus);
            groupBox2.Controls.Add(btnAddBook);
            groupBox2.Controls.Add(btnGenerateRandom);
            groupBox2.Location = new Point(10, 441);
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
            groupBox1.Location = new Point(11, 12);
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
            tabStore.Size = new Size(662, 661);
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
            panel3.Location = new Point(243, 168);
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
            panel2.Location = new Point(23, 166);
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
            panel1.Controls.Add(lblBalance);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(23, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(619, 137);
            panel1.TabIndex = 0;
            // 
            // btnFindBook
            // 
            btnFindBook.Location = new Point(478, 78);
            btnFindBook.Name = "btnFindBook";
            btnFindBook.Size = new Size(118, 37);
            btnFindBook.TabIndex = 3;
            btnFindBook.Text = "Найти";
            btnFindBook.UseVisualStyleBackColor = true;
            btnFindBook.Click += btnFindBook_Click;
            // 
            // txtSearchBook
            // 
            txtSearchBook.Location = new Point(12, 83);
            txtSearchBook.Name = "txtSearchBook";
            txtSearchBook.Size = new Size(268, 27);
            txtSearchBook.TabIndex = 2;
            txtSearchBook.Text = "Название или код книги";
            // 
            // lblBalance
            // 
            lblBalance.BackColor = Color.FromArgb(224, 224, 224);
            lblBalance.Location = new Point(478, 15);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(120, 42);
            lblBalance.TabIndex = 1;
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(224, 224, 224);
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.Location = new Point(12, 14);
            label7.Name = "label7";
            label7.Size = new Size(268, 43);
            label7.TabIndex = 0;
            label7.Text = "Баланс магазина";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 698);
            Controls.Add(tabControl1);
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
            ResumeLayout(false);
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
    }
}
