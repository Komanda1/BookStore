using Bookstore;
using Forms;

namespace Lab3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            using (var titleForm = new Form2())
            {
                // 2. Показываем её как диалоговое окно (программа ждет здесь)
                DialogResult result = titleForm.ShowDialog();

                // 3. Если пользователь нажал "Да" в подтверждении (DialogResult.OK)
                if (result == DialogResult.OK)
                {
                    // Получаем выбранный режим
                    DifficultyLevel difficulty = titleForm.SelectedDifficulty;

                    // 4. Создаем главную форму и передаем ей режим сложности
                    // Для этого в Form1 нужно будет добавить специальный конструктор (см. Шаг 2)
                    var mainForm = new Form1(difficulty);

                    // Запускаем главную форму
                    Application.Run(mainForm);
                }
                else
                {
                    // Если пользователь нажал "Нет" или закрыл окно крестиком - выходим из программы
                    return;
                }
            }
        }
    }
}