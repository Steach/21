using TMPro;

namespace TwentyOne.FSM
{
    public class StateMachine
    {
        public PatternState CurrentState { get; private set; }
        public TextMeshProUGUI _debug;

        public void Init(PatternState startingState, TextMeshProUGUI debug)
        {
            _debug = debug;
            CurrentState = startingState;
            startingState.Enter();
            _debug.text = startingState.GetType().Name;
        }

        public void ChangeState(PatternState newState)
        {
            CurrentState.Exit();

            _debug.text = newState.GetType().Name;
            CurrentState = newState;
            newState.Enter();
        }
    }
}