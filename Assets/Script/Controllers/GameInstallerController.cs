using Snake.Interactables;
using UnityEngine;

namespace Snake.Controllers
{
    public class GameInstallerController : MonoBehaviour
    {
        [SerializeField] private FoodController _foodController;
        [SerializeField] private SnakeController _snakeController;
        [SerializeField] private GameStateController _gameStateController;
        [SerializeField] private ScoreController _scoreController;

        private void Awake()
        {
            FoodController foodController = Instantiate(_foodController, transform.position, Quaternion.identity);
            SnakeController snakeController = Instantiate(_snakeController, transform.position, Quaternion.identity);

            snakeController.SetFoodController(foodController);
            _gameStateController.SetFoodController(foodController);
            _scoreController.SetFoodController(foodController);
            _gameStateController.SetSnakeController(snakeController);

            foodController.gameObject.SetActive(false); 
            snakeController.gameObject.SetActive(false); 
        }
    }    
}