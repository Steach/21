using UnityEngine;
using UnityEngine.UI;

namespace TwentyOne.Managers
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _getCardButton;
        [SerializeField] private Button _passButton;

        private void Awake()
        {
            _restartButton.gameObject.SetActive(false);
            _passButton.gameObject.SetActive(true);
            _getCardButton.gameObject.SetActive(true);
        }

        public void SetActiveInactiveButtons()
        {
            _restartButton.gameObject.SetActive(true);
            _passButton.gameObject.SetActive(false);
            _getCardButton.gameObject.SetActive(false);
        }
    }
}