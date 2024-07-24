namespace TwentyOne.FSM
{
    public abstract class PatternState
    {
        protected Bot Bot;
        protected StateMachine FSM;

        protected PatternState(StateMachine stateMachine, Bot bot) 
        {
            FSM = stateMachine;
            Bot = bot;
        }

        public virtual void Enter()
        { }

        public virtual void LogicUpdate()
        { }

        public virtual void Exit()
        { }
    }
}