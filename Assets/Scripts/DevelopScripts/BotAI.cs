using UnityEngine;

namespace TwentyOne.Develop
{
    public class BotAI : MonoBehaviour
    {
        [SerializeField] private Player _player;
        public void PassOrGet(int score)
        {
            if (score < 18)
                _player.GetCardAction();
            else
                _player.PassAction();
        }
    }
}