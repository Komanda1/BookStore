namespace Forms
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            groupBox1 = new GroupBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.BackgroundImage = (Image)resources.GetObject("groupBox1.BackgroundImage");
            groupBox1.Location = new Point(42, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(403, 224);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Thistle;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(39, 307);
            label1.Name = "label1";
            label1.Size = new Size(405, 72);
            label1.TabIndex = 1;
            label1.Text = "Клуб Романтики";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.Thistle;
            button1.Location = new Point(38, 407);
            button1.Name = "button1";
            button1.Size = new Size(110, 38);
            button1.TabIndex = 2;
            button1.Text = "Легкий";
            button1.UseVisualStyleBackColor = false;
            button1.Click += DifficultyButton_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Thistle;
            button2.Location = new Point(187, 407);
            button2.Name = "button2";
            button2.Size = new Size(110, 38);
            button2.TabIndex = 3;
            button2.Text = "Средний";
            button2.UseVisualStyleBackColor = false;
            button2.Click += DifficultyButton_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Thistle;
            button3.Location = new Point(334, 407);
            button3.Name = "button3";
            button3.Size = new Size(110, 38);
            button3.TabIndex = 4;
            button3.Text = "Сложный";
            button3.UseVisualStyleBackColor = false;
            button3.Click += DifficultyButton_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Thistle;
            button4.Location = new Point(187, 477);
            button4.Name = "button4";
            button4.Size = new Size(110, 38);
            button4.TabIndex = 5;
            button4.Text = "Об игре";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Thistle;
            label2.Location = new Point(303, 647);
            label2.Name = "label2";
            label2.Size = new Size(157, 49);
            label2.TabIndex = 6;
            label2.Text = "Команда 1";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(470, 706);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label2;
    }
}