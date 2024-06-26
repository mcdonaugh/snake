using System;
using Snake.Interactables;
using UnityEngine;

namespace Snake.Controllers
{
    public class SnakeController : MonoBehaviour
    {
        public event Action OnTailIsCollided;
        [SerializeField] private float _gameTickTime;
        [SerializeField] private GameObject _snakeTail;
        [SerializeField] private int _xBounds = 9;
        [SerializeField] private int _yBounds = 7;
        private FoodController _foodController;
        private GameObject[] _snakeTailArray;
        private Vector2 _previousHeadPosition;
        private Vector2 _originPosition = new Vector2(0,0);
        private int _tailLength;
        private float _currentTime;
        private bool _canGrowTail;
        private IInteractable _interactable = null;

        private void Awake()
        {
            _snakeTailArray = new GameObject[315];
        }

        private void Start()
        {
            _foodController.OnFoodInteracted += OnFoodInteractedHandler;
        }

        private void Update()
        {
            Vector3 roundedPosition = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y),Mathf.RoundToInt(transform.position.z));
            transform.position = roundedPosition;

            if (_currentTime > _gameTickTime)
            {
                MoveHead(); 
                if (_canGrowTail)
                {
                    GrowTail();
                }     
                MoveTail();
                _currentTime = 0;
            }
            _currentTime += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.A))
            {
                int snakeDirection = 90;
                ChangeDirection(snakeDirection);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                int snakeDirection = -90;
                ChangeDirection(snakeDirection);
            }

            BoundsCheck();
        }
        
        private void OnFoodInteractedHandler()
        {
            _canGrowTail= true;
        }

        public void SetFoodController(FoodController foodController)
        {
            _foodController = foodController;
        }

        private void GrowTail()
        {
            for (int i = _tailLength; i < _snakeTailArray.Length; i++)
            {
                if (_snakeTailArray[i] == null)
                {
                    GameObject newSnakeTail = Instantiate(_snakeTail, transform.position, Quaternion.identity, transform.parent);
                    _snakeTailArray[i] = newSnakeTail;
                    _tailLength++;
                    break;
                }
                else
                {
                    _snakeTailArray[_tailLength].SetActive(true);
                    _tailLength++;
                    break; 
                } 
            }
            _canGrowTail = false;
        }
        private void MoveHead()
        {
            _previousHeadPosition = transform.position;
            transform.position += transform.right;
        }

        private void MoveTail()
        {
            for (int i = _snakeTailArray.Length - 1; i >= 0; i--)
            {
                if (_snakeTailArray[i] != null)
                {
                    if (i == 0)
                    {
                        _snakeTailArray[i].transform.position = _previousHeadPosition;
                    }
                    else
                    {
                        Vector2 ParentPosition = _snakeTailArray[i-1].transform.position;
                        _snakeTailArray[i].transform.position = ParentPosition; 
                    }
                }    
            }
        }

        public void DespawnTail()
        {
            foreach (var item in _snakeTailArray)
            {
                if(item != null)
                {
                    item.SetActive(false);
                }    
            }
            _tailLength = 0;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _interactable = other.GetComponent<IInteractable>();
            
            if (_interactable != null)
            {
                _interactable.Interact(); 
            }

            if (other.CompareTag("Tail"))
            {
                OnTailIsCollided?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _interactable = null;
        }
        
        public void ResetSnakePosition()
        {
            transform.position = _originPosition;
        }

        private void BoundsCheck()
        {
            if(transform.position.x == _xBounds + 1)
            {   
                transform.position = new Vector3(-_xBounds, transform.position.y, 0);
            }
            else if (transform.position.x == -_xBounds - 1)
            {
                transform.position = new Vector3(_xBounds, transform.position.y, 0);
            }
            else if(transform.position.y == _yBounds + 1)
            {
                transform.position = new Vector3(transform.position.x, -_yBounds, 0);
            }
            else if(transform.position.y == -_yBounds - 1)
            {
                transform.position = new Vector3(transform.position.x, _yBounds, 0);
            }
        }

        private void ChangeDirection(int direction)
        {
            transform.eulerAngles += new Vector3(0, 0, direction);
        }
        
    }    
}