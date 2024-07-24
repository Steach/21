using TMPro;
using UnityEngine;
using TwentyOne.FSM;
using TwentyOne.Managers;


public class Player : MonoBehaviour
{
    public int NumberInGame;

    [SerializeField] private string _name;
    [SerializeField] private int _score;
    [SerializeField] private Croupier _croupier;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private bool _isBot;
    [SerializeField] private Bot _bot;
    [SerializeField] private Vector3 _currentPosition;


    private int _cardCountOnHands = 0;
    private bool _waitACard = false;
    private bool _isPassed = false;


    public int Score { get { return _score; } }
    public Vector3 Position { get { return _currentPosition; } set { _currentPosition = value; } }
    public bool IsBot { get { return _isBot; } }


    private void Start()
    {
        _score = 0;
        //for (int i = 0; i < _starterCardsCount; i++)
        //{
        //    _croupier.GetCard(gameObject);
        //}
    }

    public void SetScore(int addscore)
    {
        _score += addscore;
        _cardCountOnHands++;
        _waitACard = false;
        Debug.Log($"{_name}: {_score}");
    }

    public void GetMoreCard()
    {
        if (_cardCountOnHands >= GameManager.Instance.StarterCardsCount && _isBot && !_waitACard)
        {
            _croupier.GetCard(gameObject);
            _waitACard = true;
        }    
    }

    public void PlayerIsPassed()
    {
        if (!_isPassed)
        {
            Debug.Log($"{_name} is passed.");
            _isPassed = true;
        }
    }

    public void GetStartedCards()
    {
        _croupier.GetCard(gameObject);
    }
}