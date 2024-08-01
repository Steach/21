using System.Collections.Generic;
using TwentyOne.Data.Card;
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
        [SerializeField] private List<Card.CardInformation> _cards = new List<Card.CardInformation>();
        [Space]
        [Header("Bot Settings (optional)")]
        [SerializeField] private BotAI _botAI;
        [SerializeField] private bool _isBotControlled;

        public bool DealerWait = true;
        public Vector3 Position { get { return _position; } set { _position = value; } }
        public System.Action<GameOverInformation> GameOverEvent;
        public System.Action<string, int> UpdatePlayerScoreEvent;
        public System.Action PassEvent;

        private GameOverInformation _gameOverInformation;

        private bool _pass = false;
        private int _score = 0;

        public bool Pass { get { return _pass; } }

        private void Start()
        {
            if(_passButton != null)
                _passButton.onClick.AddListener(PassAction);
            if (_getCardButton != null)
                _getCardButton.onClick.AddListener(GetCardAction);
        }

        private void Update()
        {
            if (_score >= 21 && !_pass)
                GameOver();


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
                _dealer.ChangeCounter(1);
                DealerWait = false;
            }

            if (!_pass)
            {
                Debug.Log($"{gameObject.name}: Passed");
                _pass = true;
                DealerWait = false;
                GameOver();
                if (_isBotControlled)
                    PassEvent?.Invoke();
            }
        }

        public void GetCardAction()
        {
            if (DealerWait && !_pass)
            {
                _cards.Add(_dealer.GetCard(gameObject, _position, _isBotControlled));
                _score += _cards[_cards.Count - 1].Weight;
                DealerWait = false;
                _dealer.ChangeCounter(1);
                if(!_isBotControlled)
                {
                    UpdatePlayerScoreEvent?.Invoke(gameObject.name, _score);
                    Debug.Log($"{gameObject.name}: {_score}");
                }
            }

            if (_pass)
                PassAction();
        }

        public void RotateCards()
        {
            if (_isBotControlled)
            {
                foreach (var card in _cards)
                {
                    var transformComponent = card.Card.GetComponent<Transform>();
                    transformComponent.Rotate(0, 180, 0);
                }
            }
        }

        public GameOverInformation GetGameOverInformation() 
        { 
            return _gameOverInformation;
        }

        private void GameOver()
        {
            _pass = true;
            _gameOverInformation.Name = gameObject.name;
            _gameOverInformation.Score = _score;
            GameOverEvent?.Invoke(_gameOverInformation);
        }

        [System.Serializable]
        public struct GameOverInformation
        {
            public string Name;
            public int Score;
        }
    }
}