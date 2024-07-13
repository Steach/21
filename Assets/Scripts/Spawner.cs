using TwentyOne.Data.Card;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Deck _deck;

    private void Awake()
    {
        _deck.Init();
    }

    public int GetCard()
    {
        return _deck.GetCard();
    }

    private void OnDestroy()
    {
        _deck.ClearDesk();
    }
}