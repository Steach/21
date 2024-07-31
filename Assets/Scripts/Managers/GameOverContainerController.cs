using TMPro;
using UnityEngine;

namespace TwentyOne.Managers
{
    public class GameOverContainerController : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverContainerController;
        [SerializeField] private TextMeshProUGUI _winnerText;

        private void Start()
        {
            _gameOverContainerController.SetActive(false);
        }

        public void ActivateWinnerContainer(string name, int score)
        {
            _gameOverContainerController.SetActive(true);
            if(score > 0)
                _winnerText.text = "Winner: " + name + " " + score;
            else
                _winnerText.text = name;
        }
    }
}