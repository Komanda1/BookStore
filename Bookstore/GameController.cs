namespace Bookstore
{
    /// <summary>
    /// Режим сложности игры
    /// </summary>
    public enum DifficultyLevel
    {
        Easy,    // Лёгкий: больше времени, меньше штрафов
        Normal,  // Нормальный: стандартные настройки
        Hard     // Сложный: мало времени, строгие 
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

        private BookStore _store;
        private DifficultyLevel _difficulty;
        private int _gameDurationMinutes;
        private DateTime _gameStartTime;

        public String Difficulty;
        public int deliveryInterval { get; private set; }      // секунды между поставками
        public int customerInterval { get; private set; }      // секунды между покупателями
        public int maxQueueSize { get; private set; }         // максимальный размер очереди
        public int maxUnsatisfied { get; private set; }         // максимальное кол-во недовольных клиентов

        public GameState State { get; set; }
        public BookStore Store => _store;
        public event EventHandler<Book> BookDelivered;
        public event EventHandler<Customer> CustomerArrived;
        public event EventHandler<(bool Won, string Reason)> GameOver;
        public event EventHandler<int> TimeUpdated;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="difficulty">Сложность игры</param>
        /// <param name="maxShelves">Максимальное кол-во шкафов</param>
        /// <param name="startBalance">Начальный баланс</param>
        public GameController(DifficultyLevel difficulty, int maxShelves = 3, decimal startBalance = 1000)
        {
            this._difficulty = difficulty;
            _store = new BookStore(maxShelves, startBalance);
            State = GameState.NotStarted;

            ConfigureDifficulty();
        }

        /// <summary>
        /// Настройка сложности
        /// </summary>
        private void ConfigureDifficulty()
        {
            switch (_difficulty)
            {
                case DifficultyLevel.Easy:
                    Difficulty = "Лёгкая";
                    deliveryInterval = 300;
                    customerInterval = 450;
                    maxQueueSize = 5;
                    maxUnsatisfied = 5;
                    _gameDurationMinutes = 10;
                    break;

                case DifficultyLevel.Normal:
                    Difficulty = "Средняя";
                    deliveryInterval = 200;
                    customerInterval = 300;
                    maxQueueSize = 4;
                    maxUnsatisfied = 3;
                    _gameDurationMinutes = 8;
                    break;

                case DifficultyLevel.Hard:
                    Difficulty = "Сложная";
                    deliveryInterval = 150;
                    customerInterval = 200;
                    maxQueueSize = 3;
                    maxUnsatisfied = 2;
                    _gameDurationMinutes = 5;
                    break;
            }
        }

        /// <summary>
        /// Событие, когда приходит книга
        /// </summary>
        public void DeliveryTimer_Tick()
        {
            if (State != GameState.Playing)
                return;

            _store.AddRandomDelivery();
            var book = _store.DeliveryQueue[_store.DeliveryQueue.Count - 1];
            if (BookDelivered != null)
            {
                BookDelivered.Invoke(this, book);
            }
        }

        /// <summary>
        /// Событие, когда приходит клиент
        /// </summary>
        public void CustomerTimer_Tick()
        {
            if (State != GameState.Playing)
                return;

            _store.AddCustomer();
            var customer = _store.CustomerQueue[_store.CustomerQueue.Count - 1];
            if (CustomerArrived != null)
            {
                CustomerArrived.Invoke(this, customer);
            }
            CheckGameOver();
        }

        /// <summary>
        /// Обновление времени
        /// </summary>
        public void GameTimer_Tick()
        {
            if (State != GameState.Playing)
                return;

            var elapsed = DateTime.Now - _gameStartTime;
            var remaining = _gameDurationMinutes * 60 - (int)elapsed.TotalSeconds;

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
            var (isGameOver, reason) = _store.CheckGameOver(maxQueueSize, maxUnsatisfied);

            if (isGameOver)
            {
                EndGame(false, reason);
            }
        }

        /// <summary>
        /// Завершение игры
        /// </summary>
        /// <param name="won">Флаг выигрыш </param>
        /// <param name="reason">Причина</param>
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
        /// <returns>Информация</returns>
        public string GetDifficultyInfo()
        {
            return $"Режим: {_difficulty}\n" +
                   $"Поставки: каждые {deliveryInterval / 10} сек\n" +
                   $"Покупатели: каждые {customerInterval / 10} сек\n" +
                   $"Макс. очередь: {maxQueueSize}\n" +
                   $"Макс. недовольных: {maxUnsatisfied}\n" +
                   $"Длительность: {_gameDurationMinutes} мин";
        }

        /*
        /// <summary>
        /// Возвращает колллекцию книг в текущем шкафе
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> GetBooksInOrder()
        {
            if (currentDisplayShelf == null)
                return Enumerable.Empty<Book>();
            return currentDisplayShelf.Books.OrderBy(book => book.Id).ToList();
        }

        /// <summary>
        /// Метод для установки текущего шкафа
        /// </summary>
        /// <param name="shelf"></param>
        public void SetCurrentShelf(BookShelf shelf)
        {
            currentDisplayShelf = shelf;
        }*/
    }
}