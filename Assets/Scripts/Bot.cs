using TMPro;
using UnityEngine;

namespace TwentyOne.FSM
{
    public class Bot : MonoBehaviour
    {
        public StateMachine FSM;
        public WaitState WaitState;
        public GetCardOrPassState GetCardOrPassedState;

        [SerializeField] private Player player;
        [SerializeField] private TextMeshProUGUI _debug;

        private void Awake()
        {
            Croupier.NextStep += GetCardOrPassed;
        }

        private void Start()
        {
            FSM = new StateMachine();

            WaitState = new WaitState(FSM, this);
            GetCardOrPassedState = new GetCardOrPassState(FSM, this);

            FSM.Init(WaitState, _debug);
        }

        private void Update()
        {
            FSM.CurrentState.LogicUpdate();
        }

        private void GetCardOrPassed()
        {
            FSM.ChangeState(GetCardOrPassedState);
        }

        public int GetScore()
        {
            return player.Score;
        }

        public void GetCard()
        {
            player.GetMoreCard();
        }

        public void Passed()
        {
            player.PlayerIsPassed();
        }
    }
}