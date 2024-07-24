namespace TwentyOne.FSM
{
    public class WaitState : PatternState
    {
        public WaitState(StateMachine stateMachine, Bot bot) : base(stateMachine, bot)
        { }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit() 
        { 
            base.Exit();
        }
    }
}