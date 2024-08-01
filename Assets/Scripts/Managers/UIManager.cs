using TwentyOne.Develop;
using UnityEngine;

namespace TwentyOne.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Dealer _dealer;
        [SerializeField] private ButtonController _buttonController;
        [SerializeField] private GameOverContainerController _gameOverContainerController;
        [SerializeField] private Player _player;
        [SerializeField] private Player _bot;
        public Player Player { get { return _player; } }
        public Player Bot { get { return _bot; } }

        private void Start()
        {
            _dealer.DealerGameOverEvent += _buttonController.SetActiveInactiveButtons;
            _dealer.DealerGameOverEvent += _gameOverContainerController.ActivatePlayersScoreContainers;
            _dealer.DealerWinnerEvent += _gameOverContainerController.ActivateWinnerContainer;
            _bot.PassEvent += _gameOverContainerController.ActivateBotStateStatus;
            _player.UpdatePlayerScoreEvent += _gameOverContainerController.UpdatePlayerScore;
        }
    }
}