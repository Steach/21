namespace TwentyOne.FSM
{
    public class GetCardOrPassState : PatternState
    {
        public GetCardOrPassState(StateMachine stateMachine, Bot bot) : base(stateMachine, bot)
        { }

        public override void Enter()
        {
            base.Enter();
            if (Bot.GetScore() < 18)
                Bot.GetCard();
            else
                Bot.Passed();

            Exit();
        }

        public override void Exit() 
        {
            FSM.ChangeState(Bot.WaitState);
        }
    }
}