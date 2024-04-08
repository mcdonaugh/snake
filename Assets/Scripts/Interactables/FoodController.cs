using System;
using UnityEngine;

namespace Snake.Interactables
{
    public class FoodController : MonoBehaviour, IInteractable
    {
        public event Action OnFoodInteracted;

        private void OnEnable()
        {
            RandomizePosition();
        }

        public void Interact()
        {
            RandomizePosition();
            OnFoodInteracted?.Invoke();
        }

        public void RandomizePosition()
        {
            transform.position = new Vector2(UnityEngine.Random.Range(-9,9),UnityEngine.Random.Range(-7,7)); 
        }
    }  
}