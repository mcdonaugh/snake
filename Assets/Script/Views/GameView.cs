using UnityEngine;
using TMPro;

namespace Snake.Views
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerScoreText;
        public void UpdateScore(int score)
        {
            _playerScoreText.text = score.ToString();
        }
    }
}