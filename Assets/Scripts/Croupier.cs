using System.Collections.Generic;
using TwentyOne.Data.Card;
using UnityEngine;

public class Croupier : MonoBehaviour
{
    [SerializeField] private Deck _deck;
    [SerializeField] private Queue<GameObject> _players = new Queue<GameObject>();
    [SerializeField] private Vector3 _positionOffset;
    private float _timer = 0;
    private int _timerDelay = 2;

    private void Awake()
    {
        _deck.Init();
    }

    private void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;

        if (_timer <= 0 && _players.Count > 0)
        {
            _timer = _timerDelay;
            var player = _players.Dequeue();
            var PlayerComponent = player.GetComponent<Player>();
            PlayerComponent.SetScore(_deck.GetCard(PlayerComponent.Position, PlayerComponent.IsBot));
            ChangeCurrentPositionAtPlayerCards(PlayerComponent.Position, _positionOffset, PlayerComponent);
        }   
    }

    public void GetCard(GameObject player)
    {
        _timer = _timerDelay;
        _players.Enqueue(player);
    }

    private void OnDestroy()
    {
        _deck.ClearDesk();
        _players.Clear();
    }

    private void ChangeCurrentPositionAtPlayerCards(Vector3 current, Vector3 offset, Player player)
    {
        player.Position = new Vector3(current.x + offset.x, current.y + offset.y, current.z + offset.z);
    }
}