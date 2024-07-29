using System.Collections;
using TwentyOne.Data.Card;
using UnityEngine;

namespace TwentyOne.Develop
{
    public class Dealer : MonoBehaviour
    {
        [SerializeField] private Deck _deck;
        [SerializeField] private Player[] _players;
        [SerializeField] private int _counter = 0;
        [SerializeField] private Vector3 _positionOffset;

        //private float _timer = 0.5f;

        private void Awake()
        {
            _deck.Init();

            foreach (var player in _players)
                player.DealerWait = true;
        }

        private void Update()
        {
            if (_counter == _players.Length)
            {
                ToldAboutWaiting();
                //StartCoroutine(Timer());
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
    }
}