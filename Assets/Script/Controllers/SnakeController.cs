using System.Collections;
using UnityEngine;

namespace Snake.Controllers
{
    public class SnakeController : MonoBehaviour
    {
        [SerializeField] private float _gameTickTime;

        private void Start()
        {
            transform.position = Vector2.zero;
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

        private void MoveFoward()
        {
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
                MoveFoward();
                yield return new WaitForSeconds(_gameTickTime);
            }
        }
        
    }    
}