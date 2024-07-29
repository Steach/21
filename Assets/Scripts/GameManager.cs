using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TwentyOne.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private int _playersCounts;
        [SerializeField] private List<Player> _players = new List<Player>();
        [SerializeField] private int _starterCardsCount;

        public List<Player> Players { get { return Instance._players; } }

        public int StarterCardsCount { get { return _starterCardsCount; } }

        private void Awake()
        {
            if (Instance == null )
            {
                Instance = this;
                transform.SetParent(null);
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void GetStartedCards()
        {
            foreach (var p in Instance._players)
            {
                for (int i = 0; i < _starterCardsCount; i++)
                {
                    p.GetStartedCards();
                }
            }
        }

        private void Shuffle(List<Player> array)
        {
            for (int i = array.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, array.Count);
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;

                array[i].NumberInGame = i;
                array[j].NumberInGame = j;
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;

            if (Instance._players[0] != null)
            {
                Shuffle(Instance._players);
                GetStartedCards();
            }
            else
            {
                var tmpPlayers = FindAnyObjectByType<Croupier>().Players;

                for (int i = 0; i < tmpPlayers.Length; i++)
                {
                    Instance._players[i] = tmpPlayers[i];
                }

                Shuffle(Instance._players);
                GetStartedCards();
            }
        }
    }
}