using UnityEngine;

namespace TwentyOne.Data.Card
{
    [CreateAssetMenu(fileName = "Card", menuName = "TwentyOne/Card", order = 1)]
    public class Card : ScriptableObject
    {
        [SerializeField] private GameObject _basicPrefab;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _weight;
        private CardInformation _cardInformation;

        public CardInformation Init(Vector3 position, bool isBot)
        {
            var rotation = Quaternion.identity;

            if (isBot)
            {
                rotation = new Quaternion(rotation.x, rotation.y + 180, rotation.z, rotation.w);
            }

            _cardInformation.Card = Instantiate(_basicPrefab, position, rotation);
            _cardInformation.Weight = _weight;

            _cardInformation.Card.GetComponent<SpriteRenderer>().sprite = _sprite;

            return _cardInformation;
        }

        [System.Serializable]
        public struct CardInformation
        {
            public GameObject Card;
            public int Weight;
        }
    }
}