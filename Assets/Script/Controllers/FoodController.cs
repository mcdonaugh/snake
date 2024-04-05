using UnityEngine;

namespace Snake.Controllers
{
    public class FoodController : MonoBehaviour
    {

        public void SpawnFood()
        {
            if(!gameObject.activeInHierarchy)
            {
                RandomizePosition();
                Instantiate(gameObject, transform.position, Quaternion.identity);   
            }
            else{
                RandomizePosition();
                gameObject.SetActive(true);
            }
        }
        
        private void RandomizePosition()
        {
            transform.position = new Vector2(Random.Range(-10,10),Random.Range(-7,7));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            RandomizePosition();
        }
        
        public void DespawnFood()
        {
            if(!gameObject.activeInHierarchy)
            {
                gameObject.SetActive(true);
            }
        }

        

    }  
}