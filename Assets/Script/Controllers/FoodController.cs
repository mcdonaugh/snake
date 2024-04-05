using UnityEngine;

namespace Snake.Controllers
{
    public class FoodController : MonoBehaviour
    {
        private void Start()
        {
            RandomizePosition();
        }

        private void RandomizePosition()
        {
            transform.position = new Vector2(Random.Range(-10,10),Random.Range(-7,7));
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            RandomizePosition();
        }
    }  
}