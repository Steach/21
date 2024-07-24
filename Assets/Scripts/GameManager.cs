using UnityEngine;
using UnityEngine.SceneManagement;

namespace TwentyOne.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private int _playersCounts;
        [SerializeField] private Player[] _players;
        [SerializeField] private int _starterCardsCount;

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
            foreach (var p in _players)
            {
                for (int i = 0; i < _starterCardsCount; i++)
                {
                    p.GetStartedCards();
                }
            }
        }

        private void Shuffle(Player[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = Random.Range(0, array.Length);
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;

                array[i].NumberInGame = i;
                array[j].NumberInGame = j;
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log($"Scene: {scene.name}");
            SceneManager.sceneLoaded -= OnSceneLoaded;

            if (_players[0].TryGetComponent<Player>(out Player player))
            {
                Shuffle(_players);
                GetStartedCards();
            }
            else
            {
                Debug.Log($"PLAYERS IS NULL");
                _players = new Player[_playersCounts];
                for (int i = 0; i < _playersCounts; i++)
                {
                    _players[i] = FindAnyObjectByType<Player>();
                }
                Shuffle(_players);
                GetStartedCards();
            }
        }
    }
}