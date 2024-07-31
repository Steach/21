using TwentyOne.Develop;
using UnityEngine;

namespace TwentyOne.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Dealer _dealer;
        [SerializeField] private ButtonController _buttonController;
        [SerializeField] private GameOverContainerController _gameOverContainerController;

        private void Start()
        {
            _dealer.DealerGameOverEvent += _buttonController.SetActiveInactiveButtons;
            _dealer.DealerWinnerEvent += _gameOverContainerController.ActivateWinnerContainer;
        }
    }
}