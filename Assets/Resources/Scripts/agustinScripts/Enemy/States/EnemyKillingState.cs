using UnityEngine;

public class EnemyKillingState : EnemyBaseState
{
    public EnemyKillingState(EnemyStateMachine.EEnemyState state) : base(state) {   }

    public override void EnterState(StateManager<EnemyStateMachine.EEnemyState> enemy)
    {
        base.EnterState(enemy);
        _enemyController.Agent.SetDestination(_enemyController.StartPosition);
    }
    
    public override void UpdateState(StateManager<EnemyStateMachine.EEnemyState> context)
    {
        if (Vector2.Distance(_enemyController.transform.position, _enemyController.StartPosition) <= 1)
            GameObject.Destroy(_enemyController.gameObject);
    }

    public override void ExitState(StateManager<EnemyStateMachine.EEnemyState> context)
    {   }

    public override void FixedUpdateState(StateManager<EnemyStateMachine.EEnemyState> context)
    {   }

    public override EnemyStateMachine.EEnemyState GetNextState(StateManager<EnemyStateMachine.EEnemyState> context)
    {
        if (_enemyController.Killed)
            return EnemyStateMachine.EEnemyState.RUNING;

        return EnemyStateMachine.EEnemyState.KILLING;
    }

    public override void OnDestroy()
    {
        GameObject.Destroy(_enemyController.GrabedPrey);
    }

}
