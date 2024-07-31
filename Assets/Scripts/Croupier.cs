using System.Collections.Generic;
using TwentyOne.Data.Card;
using TwentyOne.Managers;
using UnityEngine;

public class Croupier : MonoBehaviour
{
    [SerializeField] private Deck _deck;
    [SerializeField] private Queue<GameObject> _playersQueue = new Queue<GameObject>();
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private Player[] _players;
    public Player[] Players { get { return _players; } }
    private float _timer = 0;
    private int _timerDelay = 2;

    public static System.Action NextStep;
    private bool _anEventHappens = true;

    private void Awake()
    {
        _deck.Init();
    }

    private void Update()
    {
        if (_playersQueue.Count == 0 && !_anEventHappens)
        {
            NextStep.Invoke();
            _anEventHappens = true;
        }
        else if (_playersQueue.Count >= 1 && _anEventHappens)
        {
            _anEventHappens = false;
        }

        if (_timer > 0)
            _timer -= Time.deltaTime;

        if (_timer <= 0 && _playersQueue.Count > 0)
        {
            _timer = _timerDelay;
            var player = _playersQueue.Dequeue();
            var PlayerComponent = player.GetComponent<Player>();
            //PlayerComponent.SetScore(_deck.GetCard(PlayerComponent.Position, PlayerComponent.IsBot));
            ChangeCurrentPositionAtPlayerCards(PlayerComponent.Position, _positionOffset, PlayerComponent);
        }
    }

    public void GetCard(GameObject player)
    {
        _timer = _timerDelay;
        _playersQueue.Enqueue(player);
    }

    private void OnDestroy()
    {
        _deck.ClearDesk();
        _playersQueue.Clear();
    }

    private void ChangeCurrentPositionAtPlayerCards(Vector3 current, Vector3 offset, Player player)
    {
        player.Position = new Vector3(current.x + offset.x, current.y + offset.y, current.z + offset.z);
    }
}