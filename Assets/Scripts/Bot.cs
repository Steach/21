using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private Player player;

    private void Update()
    {
        if (player.Score < 18)
            player.GetMoreCard();
        else
            player.PlayerIsPassed();
    }
}