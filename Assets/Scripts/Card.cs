using UnityEngine;

namespace TwentyOne.Data.Card
{
    [CreateAssetMenu(fileName = "Card", menuName = "TwentyOne/Card", order = 0)]
    public class Card : ScriptableObject
    {
        [SerializeField] private GameObject _basicPrefab;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _weight;

        public int Init()
        {
            var position = new Vector3 (0, 0, 0);
            var IntantiatedCard = Instantiate(_basicPrefab, position, Quaternion.identity);

            IntantiatedCard.GetComponent<SpriteRenderer>().sprite = _sprite;

            return _weight;
        }
    }
}