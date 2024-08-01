using TMPro;
using UnityEngine;

namespace TwentyOne.Managers
{
    public class GameOverContainerController : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private GameObject _gameOverContainerController;
        [SerializeField] private GameObject _playerScoreContainerController;
        [SerializeField] private GameObject _botScoreContainerController;
        [SerializeField] private TextMeshProUGUI _playerScoreText;
        [SerializeField] private TextMeshProUGUI _botScoreText;
        [SerializeField] private TextMeshProUGUI _winnerText;

        private void Start()
        {
            _gameOverContainerController.SetActive(false);
            _playerScoreContainerController.SetActive(false);
            _botScoreContainerController.SetActive(false);
        }

        public void ActivateWinnerContainer(string name, int score)
        {
            _gameOverContainerController.SetActive(true);
            if(score > 0)
                _winnerText.text = "Winner: " + name;
            else
                _winnerText.text = name;
        }

        public void ActivatePlayersScoreContainers()
        {
            var playerInfo = _uiManager.Player.GetGameOverInformation();
            var botInfo = _uiManager.Bot.GetGameOverInformation();

            UpdatePlayerScore(playerInfo.Name, playerInfo.Score);
            
            _botScoreText.text = botInfo.Name + ": " + botInfo.Score;
            _botScoreContainerController.SetActive(true);
        }

        public void ActivateBotStateStatus()
        {
            _botScoreContainerController.SetActive(true);
            _botScoreText.text = "PASS";
        }

        public void UpdatePlayerScore(string name, int score)
        {
            _playerScoreText.text = name + ": " + score;
            _playerScoreContainerController.SetActive(true);
        }
    }
}