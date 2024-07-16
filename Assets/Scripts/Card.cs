using UnityEngine;

namespace TwentyOne.Data.Card
{
    [CreateAssetMenu(fileName = "Card", menuName = "TwentyOne/Card", order = 1)]
    public class Card : ScriptableObject
    {
        [SerializeField] private GameObject _basicPrefab;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _weight;

        public int Init(Vector3 position, bool isBot)
        {
            var rotation = Quaternion.identity;

            if (isBot)
            {
                rotation = new Quaternion(rotation.x, rotation.y + 180, rotation.z, rotation.w);
            }

            var IntantiatedCard = Instantiate(_basicPrefab, position, rotation);

            IntantiatedCard.GetComponent<SpriteRenderer>().sprite = _sprite;

            return _weight;
        }
    }
}