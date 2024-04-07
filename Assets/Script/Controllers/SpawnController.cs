using Snake.Interactables;
using Unity.VisualScripting;
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

            if(_newFood == null)
            {
                _newFood = Instantiate(_foodController, transform.position, Quaternion.identity);   
            }
            else
            {
                _newFood.gameObject.SetActive(true);  
            }  
        }

        public void DespawnFood()
        {
            _newFood.gameObject.SetActive(false);
        }

        public void SpawnSnake()
        {   
            
            transform.position = _originPosition;

            if (_snakeHead == null)
            {
                _snakeHead = Instantiate(_snakeController, _originPosition, Quaternion.identity); 
            }
            else
            {
                _snakeHead.gameObject.SetActive(true);
            }

            _snakeHead._snakeIsMoving = true;
        }

        public void DespawnSnake()
        {
            _snakeHead.gameObject.SetActive(false);
            _snakeHead._snakeIsMoving = false;
            _snakeHead.gameObject.transform.position = _originPosition;
            _snakeHead.DespawnTail();
        }
    }
}