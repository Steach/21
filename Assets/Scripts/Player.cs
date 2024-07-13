using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private int _starterCardsCount;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        Debug.Log("Player Start Game");
        _score = 0;
        for (int i = 0; i < _starterCardsCount; i++)
        {
            _score += _spawner.GetCard();
            _scoreText.text = "Player: " + _score.ToString();
        }
    }
}