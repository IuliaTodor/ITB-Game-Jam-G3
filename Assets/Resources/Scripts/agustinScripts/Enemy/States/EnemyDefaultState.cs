public class EnemyDefaultState : EnemyBaseState
{
    public EnemyDefaultState(EnemyStateMachine.EEnemyState state) : base(state) {   }
    public override void EnterState(StateManager<EnemyStateMachine.EEnemyState> enemy)
    {
        base.EnterState(enemy);
        EntityManager.Instance.EnemyList.Add(_enemyController);
    }

    public override void ExitState(StateManager<EnemyStateMachine.EEnemyState> context)
    {   }

    public override void FixedUpdateState(StateManager<EnemyStateMachine.EEnemyState> context)
    {   }

    public override EnemyStateMachine.EEnemyState GetNextState(StateManager<EnemyStateMachine.EEnemyState> context)
    {
        return EnemyStateMachine.EEnemyState.HUNTING;
    }

    public override void OnDestroy()
    {   }

    public override void UpdateState(StateManager<EnemyStateMachine.EEnemyState> context)
    {   }
}
