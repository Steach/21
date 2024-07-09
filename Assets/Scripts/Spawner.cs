using TwentyOne.Data.Card;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Card[] cards;

    private void Awake()
    {
        Debug.Log(cards[Random.Range(0, cards.Length)].Init());
    }
}
