using System;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyStateMachine : StateManager<EnemyStateMachine.EEnemyState>
{
    public enum EEnemyState
    {
        DEFAULT = 0,
        HUNTING = 1,
        KILLING = 2
    }

    EnemyDefaultState EnemyDefaultState = new EnemyDefaultState(EEnemyState.DEFAULT);
    EnemyHuntingState EnemyHuntingState = new EnemyHuntingState(EEnemyState.HUNTING);
    EnemyKillingState EnemyKillingState = new EnemyKillingState(EEnemyState.KILLING);

    private void Awake()
    {
        AddStatesInDictionary();
        _currentState = States[EEnemyState.DEFAULT];
    }

    private void AddStatesInDictionary()
    {
        Type type = this.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo field in fields)
        {
            if (field.FieldType.IsSubclassOf(typeof(BaseState<EEnemyState>)))
            {
                BaseState<EEnemyState> state = (BaseState<EEnemyState>)field.GetValue(this);
                States.Add(state.StateKey, state);
            }
        }
    }
}
