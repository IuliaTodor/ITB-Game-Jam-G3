using System;

public abstract class BaseState<EState> where EState : Enum
{
    public BaseState(EState key) => StateKey = key;
    public EState StateKey { get; private set; }
    public abstract void EnterState(StateManager<EState> context);
    public abstract void ExitState(StateManager<EState> context);
    public abstract void UpdateState(StateManager<EState> context);
    public abstract void FixedUpdateState(StateManager<EState> context);
    public abstract EState GetNextState(StateManager<EState> context);
}
