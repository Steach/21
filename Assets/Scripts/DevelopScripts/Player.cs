using UnityEngine;
using UnityEngine.UI;

namespace TwentyOne.Develop
{
    public class Player : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _passButton;
        [SerializeField] private Button _getCardButton;
        [Space]
        [Header("GameSettings")]
        [SerializeField] private Dealer _dealer;
        [SerializeField] private Vector3 _position;
        [Space]
        [Header("Bot Settings (optional)")]
        [SerializeField] private BotAI _botAI;
        [SerializeField] private bool _isBotControlled;

        public bool DealerWait = true;
        public Vector3 Position { get { return _position; } set { _position = value; } }

        private bool _pass = false;
        private int _score = 0;

        private void Start()
        {
            if(_passButton != null)
                _passButton.onClick.AddListener(PassAction);
            if (_getCardButton != null)
                _getCardButton.onClick.AddListener(GetCardAction);
        }

        private void Update()
        {
            if(DealerWait && _pass)
            {
                _dealer.ChangeCounter(1);
                DealerWait = false;
            }
                

            if (_isBotControlled && _botAI != null && DealerWait)
            {
                _botAI.PassOrGet(_score);
            }
        }

        public void PassAction()
        {
            if (DealerWait)
            {
                Debug.Log("Passed");
                _pass = true;
                DealerWait = false;
                _dealer.ChangeCounter(1);
            }
        }

        public void GetCardAction()
        {
            if (DealerWait && !_pass)
            {
                _score += _dealer.GetCard(gameObject, _position, _isBotControlled);
                DealerWait = false;
                _dealer.ChangeCounter(1);
                Debug.Log($"{gameObject.name}: {_score}");
            }

            if (_pass)
                PassAction();
        }
    }
}