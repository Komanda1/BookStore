using Bookstore;

namespace TestUnit
{
    [TestFixture]
    public class GameControllerTests
    {
        private const int DefaultMaxShelves = 3;
        private const decimal DefaultBalance = 1000m;

        [Test]
        public void Constructor_EasyDifficulty_SetsCorrectParameters()
        {
            var game = new GameController(DifficultyLevel.Easy, DefaultMaxShelves, DefaultBalance);

            Assert.Multiple(() =>
            {
                Assert.That(game.State, Is.EqualTo(GameState.NotStarted));
                Assert.That(game.Store, Is.Not.Null);
                Assert.That(game.deliveryInterval, Is.EqualTo(30));
                Assert.That(game.customerInterval, Is.EqualTo(45));
                Assert.That(game.maxQueueSize, Is.EqualTo(5));
                Assert.That(game.maxUnsatisfied, Is.EqualTo(5));
                Assert.That(game.Difficulty, Is.EqualTo("Лёгкий"));
            });
        }

        [Test]
        public void Constructor_NormalDifficulty_SetsCorrectParameters()
        {
            var game = new GameController(DifficultyLevel.Normal, DefaultMaxShelves, DefaultBalance);

            Assert.Multiple(() =>
            {
                Assert.That(game.deliveryInterval, Is.EqualTo(20));
                Assert.That(game.customerInterval, Is.EqualTo(30));
                Assert.That(game.maxQueueSize, Is.EqualTo(4));
                Assert.That(game.maxUnsatisfied, Is.EqualTo(3));
                Assert.That(game.Difficulty, Is.EqualTo("Средний"));
            });
        }

        [Test]
        public void Constructor_HardDifficulty_SetsCorrectParameters()
        {
            var game = new GameController(DifficultyLevel.Hard, DefaultMaxShelves, DefaultBalance);

            Assert.Multiple(() =>
            {
                Assert.That(game.deliveryInterval, Is.EqualTo(15));
                Assert.That(game.customerInterval, Is.EqualTo(20));
                Assert.That(game.maxQueueSize, Is.EqualTo(3));
                Assert.That(game.maxUnsatisfied, Is.EqualTo(2));
                Assert.That(game.Difficulty, Is.EqualTo("Сложный"));
            });
        }

        [Test]
        public void Constructor_WithCustomShelves_SetsStoreCorrectly()
        {
            int maxShelves = 5;
            decimal balance = 2000m;

            var game = new GameController(DifficultyLevel.Normal, maxShelves, balance);

            Assert.Multiple(() =>
            {
                Assert.That(game.Store.MaxShelves, Is.EqualTo(maxShelves));
                Assert.That(game.Store.Balance, Is.EqualTo(balance));
            });
        }

        [Test]
        public void Constructor_DefaultParameters_SetsDefaultValues()
        {
            var game = new GameController(DifficultyLevel.Normal);

            Assert.Multiple(() =>
            {
                Assert.That(game.Store.MaxShelves, Is.EqualTo(3));
                Assert.That(game.Store.Balance, Is.EqualTo(1000m));
            });
        }

        [Test]
        public void StartGame_SetsStateToPlaying()
        {
            var game = new GameController(DifficultyLevel.Normal);

            game.StartGame();

            Assert.That(game.State, Is.EqualTo(GameState.Playing));
        }

        [Test]
        public void GetDifficultyInfo_Easy_ReturnsCorrectInfo()
        {
            // ARRANGE
            var game = new GameController(DifficultyLevel.Easy);

            // ACT
            string info = game.GetDifficultyInfo();

            // ASSERT
            Assert.Multiple(() =>
            {
                Assert.That(info, Does.Contain("Easy"));          
                Assert.That(info, Does.Contain("3 сек"));          
                Assert.That(info, Does.Contain("4 сек"));          
                Assert.That(info, Does.Contain("5"));              
                Assert.That(info, Does.Contain("5"));              
                Assert.That(info, Does.Contain("10 мин"));         
            });
        }

        [Test]
        public void GetDifficultyInfo_Normal_ReturnsCorrectInfo()
        {
            var game = new GameController(DifficultyLevel.Normal);

            string info = game.GetDifficultyInfo();

            Assert.Multiple(() =>
            {
                Assert.That(info, Does.Contain("Normal"));         
                Assert.That(info, Does.Contain("2 сек"));          
                Assert.That(info, Does.Contain("3 сек"));          
                Assert.That(info, Does.Contain("4"));              
                Assert.That(info, Does.Contain("3"));              
                Assert.That(info, Does.Contain("8 мин"));          
            });
        }

        [Test]
        public void GetDifficultyInfo_Hard_ReturnsCorrectInfo()
        {
            var game = new GameController(DifficultyLevel.Hard);

            string info = game.GetDifficultyInfo();

            Assert.Multiple(() =>
            {
                Assert.That(info, Does.Contain("Hard"));           
                Assert.That(info, Does.Contain("1 сек"));          
                Assert.That(info, Does.Contain("2 сек"));          
                Assert.That(info, Does.Contain("3"));              
                Assert.That(info, Does.Contain("2"));              
                Assert.That(info, Does.Contain("5 мин"));          
            });
        }

        [Test]
        public void Tick_WhenGameNotStarted_DoesNothing()
        {
            var game = new GameController(DifficultyLevel.Normal);
            game.State = GameState.NotStarted;
            int initialDeliveryCount = game.Store.DeliveryQueue.Count;

            game.Tick();

            Assert.That(game.Store.DeliveryQueue.Count, Is.EqualTo(initialDeliveryCount));
        }

        [Test]
        public void Tick_WhenGamePlaying_ProcessesEvents()
        {
            var game = new GameController(DifficultyLevel.Normal);
            game.StartGame();

            game.Tick();

            Assert.That(game.State, Is.EqualTo(GameState.Playing));
        }

        [Test]
        public void Store_ReturnsBookStoreInstance()
        {
            var game = new GameController(DifficultyLevel.Normal);

            Assert.That(game.Store, Is.Not.Null);
            Assert.That(game.Store, Is.InstanceOf<BookStore>());
        }

        [Test]
        public void StartGame_InitializesEvents()
        {
            var game = new GameController(DifficultyLevel.Normal);
            game.StartGame();

            Assert.That(game.State, Is.EqualTo(GameState.Playing));
        }

        [Test]
        public void DifficultyLevels_HaveDifferentValues()
        {
            var easy = new GameController(DifficultyLevel.Easy);
            var normal = new GameController(DifficultyLevel.Normal);
            var hard = new GameController(DifficultyLevel.Hard);

            Assert.Multiple(() =>
            {
                Assert.That(easy.deliveryInterval, Is.GreaterThan(normal.deliveryInterval));
                Assert.That(easy.customerInterval, Is.GreaterThan(normal.customerInterval));
                Assert.That(easy.maxQueueSize, Is.GreaterThan(normal.maxQueueSize));
                Assert.That(easy.maxUnsatisfied, Is.GreaterThan(normal.maxUnsatisfied));

                Assert.That(hard.deliveryInterval, Is.LessThan(normal.deliveryInterval));
                Assert.That(hard.customerInterval, Is.LessThan(normal.customerInterval));
                Assert.That(hard.maxQueueSize, Is.LessThan(normal.maxQueueSize));
                Assert.That(hard.maxUnsatisfied, Is.LessThan(normal.maxUnsatisfied));
            });
        }

        [Test]
        public void State_CanBeChangedDirectly()
        {
            var game = new GameController(DifficultyLevel.Normal);

            game.State = GameState.Won;

            Assert.That(game.State, Is.EqualTo(GameState.Won));
        }

        [Test]
        public void Constructor_WithMaxShelvesZero_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new GameController(DifficultyLevel.Normal, 0, 1000m));
        }

        [Test]
        public void Constructor_WithNegativeBalance_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new GameController(DifficultyLevel.Normal, 3, -100m));
        }

        [Test]
        public void Constructor_WithMaxShelvesLarge_Works()
        {
            var game = new GameController(DifficultyLevel.Normal, 100, 1000m);

            Assert.That(game.Store.MaxShelves, Is.EqualTo(100));
        }

        [Test]
        public void Constructor_WithLargeBalance_Works()
        {
            var game = new GameController(DifficultyLevel.Normal, 3, 1_000_000m);

            Assert.That(game.Store.Balance, Is.EqualTo(1_000_000m));
        }
    }
}