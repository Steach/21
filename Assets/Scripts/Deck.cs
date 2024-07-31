using System.Collections.Generic;
using UnityEngine;

namespace TwentyOne.Data.Card
{
    [CreateAssetMenu(fileName = "Deck", menuName = "TwentyOne/Deck", order = 0)]
    public class Deck : ScriptableObject
    {
        [SerializeField] private int _decksCount;
        [SerializeField] private DeckData[] _deckData;
        [SerializeField] private List<Card> _cards = new List<Card>();

        public void Init()
        {
            for (int i = 0; i < _deckData.Length; i++)
                _deckData[i].count = _decksCount;


            foreach (var data in _deckData)
            {
                var cardsCount = data.count;
                for (int i = 0; i < cardsCount; i++)
                {
                    _cards.Add(data.card);
                }
            }   
        }

        public Card.CardInformation GetCard(Vector3 position, bool isBot)
        {
            var index = Random.Range(0, _cards.Count - 1);

            if (_cards.Count > 0)
            {
                _cards.RemoveAt(index);
                return _cards[index].Init(position, isBot);
            }
            else
            {
                Debug.Log("Deck is Empty.");
                return default;
            }
            
        }

        public void ClearDesk()
        {
            _cards.Clear();
        }

        [System.Serializable]
        public struct DeckData
        {
            public int count;
            public Card card;
        }
    }
}