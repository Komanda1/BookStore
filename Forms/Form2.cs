using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form2 : Form
    {
        public string SelectedDifficulty { get; private set; } = "";
        public Form2()
        {
            InitializeComponent();
            SetupUI();
        }
        private void SetupUI()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(95, 66, 107);
        }
        private void DifficultyButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string difficulty = "";

            // Определяем сложность по имени кнопки
            if (clickedButton.Name == "button1")
                difficulty = "Лёгкий";
            else if (clickedButton.Name == "button2")
                difficulty = "Нормальный";
            else if (clickedButton.Name == "button3")
                difficulty = "Сложный";

            // Диалог подтверждения
            DialogResult result = MessageBox.Show(
                $"Вы уверены, что хотите начать игру в режиме \"{difficulty}\"?",
                "Подтверждение выбора",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.SelectedDifficulty = difficulty; // Свойство формы для передачи данных
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Добро пожаловать в Клуб Романтики\n\n" +
                "Все совпадения случайны\n" +
                "Хорошей игры",
                "Об игре",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        
    }
}
