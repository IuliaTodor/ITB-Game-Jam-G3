public class EnemyKillingState : EnemyBaseState
{
    public EnemyKillingState(EnemyStateMachine.EEnemyState state) : base(state) {   }

    public override void EnterState(StateManager<EnemyStateMachine.EEnemyState> enemy)
    {
        base.EnterState(enemy);
        _enemyController.Agent.SetDestination(_enemyController.StartPosition);
    }

    public override void ExitState(StateManager<EnemyStateMachine.EEnemyState> context)
    {   }

    public override void FixedUpdateState(StateManager<EnemyStateMachine.EEnemyState> context)
    {   }

    public override EnemyStateMachine.EEnemyState GetNextState(StateManager<EnemyStateMachine.EEnemyState> context)
    {
        return EnemyStateMachine.EEnemyState.KILLING;
    }

    public override void OnDestroy()
    {   }

    public override void UpdateState(StateManager<EnemyStateMachine.EEnemyState> context)
    {   }
}
