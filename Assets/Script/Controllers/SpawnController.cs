using UnityEngine;

namespace Snake.Controllers
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private SnakeController _snakeController;
        [SerializeField] private FoodController _foodController;
        private Vector2 _originPosition = Vector2.zero;
        private FoodController _newFood;
        private SnakeController _snakeHead;

        public void SpawnFood()
        {
            Debug.Log("Food Spawned");
            _newFood = Instantiate(_foodController, transform.position, Quaternion.identity);
        }

        public void DespawnFood()
        {
            _newFood.gameObject.SetActive(false);
            Debug.Log("Food Despawned");
        }

        public void SpawnSnake()
        {   
            transform.position = _originPosition; 
            _snakeHead = Instantiate(_snakeController, _originPosition, Quaternion.identity);
        }

        public void DespawnSnake()
        {

            Debug.Log("Despawn Snake");
            _snakeHead.gameObject.SetActive(false);
            
        }
    }
}