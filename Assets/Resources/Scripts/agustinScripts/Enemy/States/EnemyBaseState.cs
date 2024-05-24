public abstract class EnemyBaseState : BaseState<EnemyStateMachine.EEnemyState>
{
    public EnemyBaseState(EnemyStateMachine.EEnemyState state) : base(state) { }

    protected EnemyController _enemyController;
    public override void EnterState(StateManager<EnemyStateMachine.EEnemyState> enemy)
    {
        if (!_enemyController)
            _enemyController = enemy.gameObject.GetComponent<EnemyController>();

        _enemyController.CurrentState = StateKey;
        _enemyController.EnemyState = this;
    }

    public abstract void OnDestroy();
}
