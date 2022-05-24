namespace MT.State
{
    public interface IState
    {
        IState NextState { get; }
        void Enter();
        void Exit();
    }
}