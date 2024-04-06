using Snake.Views;
using UnityEngine;

namespace Snake.Controllers
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] private StartView _startView;
        [SerializeField] private GameView _gameView;
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private SpawnController _spawnController;
        private bool _gameIsActive;
        private int Score;


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
            _gameIsActive = true;
            _startView.gameObject.SetActive(false);
            _gameView.gameObject.SetActive(true);
            _gameOverView.gameObject.SetActive(false);
            _spawnController.SpawnFood();
            _spawnController.SpawnSnake();
            Debug.Log("Game Started");
        }

        private void EndGame()
        {
            _gameIsActive = false;
            _startView.gameObject.SetActive(false);
            _gameView.gameObject.SetActive(false);
            _gameOverView.gameObject.SetActive(true);
            _spawnController.DespawnFood();  
            _spawnController.DespawnSnake();
            Debug.Log("Game Ended");
        }

        private void RestartGame()
        {
            _startView.gameObject.SetActive(true);
            _gameView.gameObject.SetActive(false);
            _gameOverView.gameObject.SetActive(false);
            Debug.Log("Restarted");
        }

        private void OnDisable()
        {
        Debug.Log("Object was disabled here");
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