using System.Collections;
using UnityEngine;

namespace Snake.Controllers
{
    public class SnakeController : MonoBehaviour
    {
        [SerializeField] private float _gameTickTime;
        [SerializeField] private GameObject _snakeTail;
        private GameObject[] _snakeTailArray;
        private Vector2 _previousHeadPosition;
        private Vector2 _originPosition = Vector2.zero;

        private void Awake()
        {
            _snakeTailArray = new GameObject[315];
        }

        private void Start()
        {
            StartCoroutine(GameTick());
        }

        private void Update()
        {
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
        }
        
        public void SpawnSnake()
        {    
            Instantiate(gameObject, _originPosition, Quaternion.identity);
        }

        private void GrowTail()
        {
            GameObject newSnakeTail = Instantiate(_snakeTail, transform.position, Quaternion.identity, transform.parent);

            for (int i = 0; i < _snakeTailArray.Length; i++)
            {
                if (_snakeTailArray[i] == null)
                {
                    _snakeTailArray[i] = newSnakeTail;
                    Debug.Log(_snakeTailArray[i]);
                    break;
                }
            }
        }

        private void MoveTail()
        {
            for (int i = _snakeTailArray.Length - 1; i >= 0; i--)
            {
                if (_snakeTailArray[i] != null && i == 0)
                {
                    _snakeTailArray[i].transform.position = _previousHeadPosition;
                }

                if (_snakeTailArray[i] != null && i > 0)
                {
                    Vector2 ParentPosition = _snakeTailArray[i-1].transform.position;
                    _snakeTailArray[i].transform.position = ParentPosition;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Food")
            {
                GrowTail();
            }
        }
        
        private void MoveHead()
        {
            _previousHeadPosition = transform.position;      
            transform.position += transform.right;
        }

        private void ChangeDirection(int direction)
        {
            transform.eulerAngles += new Vector3(0,0,direction);
        }
        
        private IEnumerator GameTick()
        {
            while(true)
            {
                MoveHead();
                Debug.Log(transform.position);
                Debug.Log(_previousHeadPosition);
                
                MoveTail();
                yield return new WaitForSeconds(_gameTickTime);
            }
        }

        // public void ResetSnake()
        // {
        //     gameObject.SetActive(false);
        // }
        
    }    
}