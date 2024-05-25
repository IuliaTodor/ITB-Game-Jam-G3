using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> _currentState;
    public BaseState<EState> CurrentState { get { return _currentState; } }
    protected bool IsTransitioningState = false;

    private void Awake() {}
    private void Start() => _currentState.EnterState(this);
    private void Update() 
    {
        EState nextStateKey = _currentState.GetNextState(this);

        if (!IsTransitioningState && nextStateKey.Equals(_currentState.StateKey))
        {
            _currentState.UpdateState(this);
        } else {
            TransitionToState(nextStateKey);
        }
    }

    private void FixedUpdate() =>   _currentState.FixedUpdateState(this);

    public void TransitionToState(EState stateKey)
    {
        IsTransitioningState = true;
        _currentState.ExitState(this);
        _currentState = States[stateKey];
        _currentState.EnterState(this);
        IsTransitioningState = false;
    }
}
