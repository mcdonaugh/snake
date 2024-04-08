using Snake.Interactables;
using Snake.Views;
using UnityEngine;

namespace Snake.Controllers
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] private StartView _startView;
        [SerializeField] private GameView _gameView;
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private ScoreController _scoreController;
        private SnakeController _snakeController;
        private FoodController _foodController;
        private bool _gameIsActive;

        private void Awake()
        {
            _startView.gameObject.SetActive(true);
            _gameView.gameObject.SetActive(false);
            _gameOverView.gameObject.SetActive(false);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeGameState();
            }
        }

        private void StartGame()
        {
            _snakeController.OnTailIsCollided += OnTailIsCollidedActionHandler;
            _gameIsActive = true;
            _startView.gameObject.SetActive(false);
            _gameView.gameObject.SetActive(true);
            _gameOverView.gameObject.SetActive(false);
            _snakeController.gameObject.SetActive(true);
            _foodController.gameObject.SetActive(true);
        }

        public void EndGame()
        {
            _gameIsActive = false;
            _startView.gameObject.SetActive(false);
            _gameView.gameObject.SetActive(false);
            _gameOverView.gameObject.SetActive(true);
            _snakeController.gameObject.SetActive(false);
            _snakeController.DespawnTail();
            _foodController.gameObject.SetActive(false);
            _scoreController.CacheHighScore();
        }

        private void RestartGame()
        {
            _startView.gameObject.SetActive(true);
            _gameView.gameObject.SetActive(false);
            _gameOverView.gameObject.SetActive(false);
            _scoreController.ResetScore();
            _snakeController.ResetSnakePosition();
        }

        public void SetFoodController(FoodController foodController)
        {
            _foodController = foodController;
        }
        public void SetSnakeController(SnakeController snakeController)
        {
            _snakeController = snakeController;
        }

        private void OnTailIsCollidedActionHandler()
        {
            EndGame();
        }

        private void ChangeGameState()
        {
            if (!_gameIsActive && _gameOverView.gameObject.activeInHierarchy == true)
            {
                RestartGame();
            }
            else if (_gameIsActive)
            {
                EndGame();
            }
            else
            {
                StartGame();
            }
        } 
    }  
}