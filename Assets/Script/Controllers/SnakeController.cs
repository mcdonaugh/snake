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

        private void Awake()
        {
            _snakeTailArray = new GameObject[315];
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

        private void GrowTail()
        {
            for (int i = 0; i < _snakeTailArray.Length; i++)
            {
                if (_snakeTailArray[i] == null)
                {
                    GameObject newSnakeTail = Instantiate(_snakeTail, transform.position, Quaternion.identity, transform.parent);
                    _snakeTailArray[i] = newSnakeTail;
                    break;
                }
                else
                {
                    _snakeTailArray[i].SetActive(true);
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

        public void DespawnTail()
        {
            foreach (var item in _snakeTailArray)
            {
                if(item != null)
                {
                    item.SetActive(false);
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
        
        public IEnumerator GameTick()
        {
            while(true)
            {
                MoveHead();      
                MoveTail();
                yield return new WaitForSeconds(_gameTickTime);
            }
        }
        
    }    
}