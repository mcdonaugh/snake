using Snake.Views;
using UnityEngine;
using UnityEngine.XR;

namespace Snake.Controllers
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] private StartView _startView;
        [SerializeField] private GameView _gameView;
        [SerializeField] private GameOverView _gameOverView;
        private bool _isGameStarted;

        private void Awake()
        {
            _startView.gameObject.SetActive(true);
            _gameView.gameObject.SetActive(false);
            _gameOverView.gameObject.SetActive(false);
            Debug.Log(_isGameStarted);
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
            if(!_isGameStarted)
            {
                _isGameStarted = true;
                _startView.gameObject.SetActive(false);
                _gameView.gameObject.SetActive(true);
                _gameOverView.gameObject.SetActive(false);

            }
            Debug.Log("Game Started");
        }

        private void EndGame()
        {
            if (_isGameStarted)
            {
                _isGameStarted = false;
                _startView.gameObject.SetActive(false);
                _gameView.gameObject.SetActive(false);
                _gameOverView.gameObject.SetActive(true);
            }
            Debug.Log("Game Ended");
        }

        private void RestartGame()
        {
            _startView.gameObject.SetActive(true);
            _gameView.gameObject.SetActive(false);
            _gameOverView.gameObject.SetActive(false);
            Debug.Log("Restarted");
        }

        private void ChangeGameState()
        {
            if (_startView.gameObject.activeInHierarchy == true)
            {
                StartGame();
            }
            else if (_gameView.gameObject.activeInHierarchy == true)
            {
                EndGame();
            }
            else if (_gameOverView.gameObject.activeInHierarchy == true)
            {
                RestartGame();
            }
        } 
    }  
}