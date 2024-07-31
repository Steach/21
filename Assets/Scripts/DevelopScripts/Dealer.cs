using System.Collections;
using System.Collections.Generic;
using TwentyOne.Data.Card;
using UnityEngine;
using static TwentyOne.Develop.Player;

namespace TwentyOne.Develop
{
    public class Dealer : MonoBehaviour
    {
        [SerializeField] private Deck _deck;
        [SerializeField] private Player[] _players;
        [SerializeField] private int _counter = 0;
        [SerializeField] private Vector3 _positionOffset;
        private List<Player.GameOverInformation> _gameOverInformation = new List<Player.GameOverInformation>();
        private int _maxScore = 0;
        private string _winnerName;
        private bool _gameOver = false;

        public System.Action GameOver;
        //private float _timer = 0.5f;

        private void Awake()
        {
            _deck.Init();

            foreach (var player in _players)
            {
                player.DealerWait = true;
                player.GameOverEvent += AddPlayerGameResult;
            }  
        }

        private void Update()
        {
            if (_counter == _players.Length)
            {
                ToldAboutWaiting();
                //StartCoroutine(Timer());
            }

            if (_gameOverInformation.Count == _players.Length && !_gameOver)
            {

                for (int i = 0; i < _gameOverInformation.Count; i++)
                {
                    if (_gameOverInformation[i].Score > _maxScore && _gameOverInformation[i].Score <= 21)
                    {
                        _maxScore = _gameOverInformation[i].Score;
                        _winnerName = _gameOverInformation[i].Name;
                    }
                }

                _gameOver = true;
                GameOver?.Invoke();
                Debug.Log($"{_winnerName} is winner: {_maxScore}");

            }
        }

        public int GetCard(GameObject player, Vector3 position, bool isBot)
        {
            var score = _deck.GetCard(position, isBot);
            ChangeCurrentPositionAtPlayerCards(position, _positionOffset, player.GetComponent<Player>());
            return score;
        }

        public void ChangeCounter(int counter)
        {
            _counter += counter;
        }

        private void ChangeCurrentPositionAtPlayerCards(Vector3 current, Vector3 offset, Player player)
        {
            player.Position = new Vector3(current.x + offset.x, current.y + offset.y, current.z + offset.z);
        }

        private void ToldAboutWaiting()
        {
            foreach (var player in _players)
                player.DealerWait = true;

            _counter = 0;
        }

        //private IEnumerator Timer()
        //{
        //    yield return new WaitForSeconds(_timer);
        //    ToldAboutWaiting();
        //}

        private void OnDestroy()
        {
            _deck.ClearDesk();
        }

        private void AddPlayerGameResult(Player.GameOverInformation gameOverInformation)
        {
            if(_gameOverInformation.Count < _players.Length)
                _gameOverInformation.Add(gameOverInformation);
        }
    }
}