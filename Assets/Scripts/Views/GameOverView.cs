using UnityEngine;
using TMPro;

namespace Snake.Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerScoreText;
        [SerializeField] private TMP_Text _highScoreText;
        public void UpdateScore(int score)
        {
            _playerScoreText.text = score.ToString();
        }

        public void UpdateHighScore(int highScore)
        {
            _highScoreText.text = highScore.ToString();
        }
    }
}