using System.Collections;
using Snake.Interactables;
using Snake.Views;
using UnityEngine;

namespace Snake.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private GameView _gameView;
        [SerializeField] private GameOverView _gameOverView;
        private FoodController _foodController;
        private int _playerScore = 0;
        private int _playerHighScore = 0;

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            _foodController.OnFoodInteracted += OnFoodInteractedHandler;
        }

        public void SetFoodController(FoodController foodController)
        {
            _foodController = foodController;
        }
        
        private void OnFoodInteractedHandler()
        {
            _playerScore++;
            _gameView.UpdateScore(_playerScore);
        }

        public void CacheHighScore()
        {
            _gameOverView.UpdateScore(_playerScore);

            if (_playerScore > _playerHighScore)
            {
                _playerHighScore = _playerScore;
                _gameOverView.UpdateHighScore(_playerHighScore);
            }
        }

        public void ResetScore()
        {
            _playerScore = 0;
        }
    }    
}