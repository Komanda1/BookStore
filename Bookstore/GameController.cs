
namespace Bookstore
{
    /// <summary>
    /// Режим сложности игры
    /// </summary>
    public enum DifficultyLevel
    {
        Easy,    // Лёгкий: больше времени, меньше штрафов
        Normal,  // Нормальный: стандартные настройки
        Hard     // Сложный: мало времени, строгие ограничения
    }

    /// <summary>
    /// Состояние игры
    /// </summary>
    public enum GameState
    {
        NotStarted,
        Playing,
        Won,
        Lost
    }

    /// <summary>
    /// Контроллер игры
    /// </summary>
    public class GameController
    {
        private BookStore store;

        private DifficultyLevel difficulty;
        private int gameDurationMinutes;
        private DateTime gameStartTime;

        private int deliveryInterval;      // секунды между поставками
        private int customerInterval;      // секунды между покупателями
        private int maxQueueSize;          // максимальный размер очереди
        private int maxUnsatisfied;        // максимальное кол-во недовольных клиентов

        public GameState State { get; set; }
        public BookStore Store => store;
        public event EventHandler<Book> BookDelivered;
        public event EventHandler<Customer> CustomerArrived;
        public event EventHandler<(bool Won, string Reason)> GameOver;
        public event EventHandler<int> TimeUpdated;

        /// <summary>
        /// Кнструктор контроллера
        /// </summary>
        /// <param name="difficulty"> сложность игры </param>
        /// <param name="maxShelves"> максимальное кол-во шкафов </param>
        /// <param name="startBalance"> начальный баланс </param>
        public GameController(DifficultyLevel difficulty, int maxShelves = 3, decimal startBalance = 1000)
        {
            this.difficulty = difficulty;
            store = new BookStore(maxShelves, startBalance);
            State = GameState.NotStarted;

            ConfigureDifficulty();
        }

        /// <summary>
        /// Настройка сложности
        /// </summary>
        private void ConfigureDifficulty()
        {
            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    deliveryInterval = 30000;
                    customerInterval = 45000;
                    maxQueueSize = 5;
                    maxUnsatisfied = 5;
                    gameDurationMinutes = 10;
                    break;

                case DifficultyLevel.Normal:
                    deliveryInterval = 20000;
                    customerInterval = 30000;
                    maxQueueSize = 4;
                    maxUnsatisfied = 3;
                    gameDurationMinutes = 8;
                    break;

                case DifficultyLevel.Hard:
                    deliveryInterval = 15000;
                    customerInterval = 20000;
                    maxQueueSize = 3;
                    maxUnsatisfied = 2;
                    gameDurationMinutes = 5;
                    break;
            }
        }


        /// <summary>
        /// Событие, когда приходит книга
        /// </summary>
        private void DeliveryTimer_Tick()
        {
            if (State != GameState.Playing)
                return;

            store.AddRandomDelivery();
            var book = store.DeliveryQueue[store.DeliveryQueue.Count - 1];
            if (BookDelivered != null)
            {
                BookDelivered.Invoke(this, book);
            }
        }
        
        /// <summary>
        /// Событие, когда приходит клиент
        /// </summary>
        private void CustomerTimer_Tick()
        {
            if (State != GameState.Playing)
                return;

            store.AddCustomer();
            var customer = store.CustomerQueue[store.CustomerQueue.Count - 1];
            if (CustomerArrived != null)
            {
                CustomerArrived.Invoke(this, customer);
            }
            CheckGameOver();
        }
        
        /// <summary>
        /// Обновление времени
        /// </summary>
        private void GameTimer_Tick()
        {
            if (State != GameState.Playing)
                return;

            var elapsed = DateTime.Now - gameStartTime;
            var remaining = gameDurationMinutes * 60 - (int)elapsed.TotalSeconds;

            if (remaining <= 0)
            {
                EndGame(true, "Поздравляем! Вы успешно завершили рабочий день!");
                return;
            }

            if (TimeUpdated != null)
            {
                TimeUpdated.Invoke(this, remaining);
            }
            CheckGameOver();
        }

        /// <summary>
        /// Проверка условий окончания игры
        /// </summary>
        private void CheckGameOver()
        {
            var (isGameOver, reason) = store.CheckGameOver(maxQueueSize, maxUnsatisfied);

            if (isGameOver)
            {
                EndGame(false, reason);
            }
        }

        /// <summary>
        /// Завершение игры
        /// </summary>
        /// <param name="won"> флаг выигрыша </param>
        /// <param name="reason"> причина </param>
        private void EndGame(bool won, string reason)
        {
            State = won ? GameState.Won : GameState.Lost;
            
            if (GameOver != null)
            {
                GameOver.Invoke(this, (won, reason));
            }
        }

        /// <summary>
        /// Получение настроек сложности
        /// </summary>
        /// <returns> информация </returns>
        public string GetDifficultyInfo()
        {
            return $"Режим: {difficulty}\n" +
                   $"Поставки: каждые {deliveryInterval / 1000} сек\n" +
                   $"Покупатели: каждые {customerInterval / 1000} сек\n" +
                   $"Макс. очередь: {maxQueueSize}\n" +
                   $"Макс. недовольных: {maxUnsatisfied}\n" +
                   $"Длительность: {gameDurationMinutes} мин";
        }
    }
}