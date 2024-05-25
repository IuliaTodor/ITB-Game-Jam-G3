using UnityEngine;

public class EnemyProtectingState : EnemyBaseState
{
    EnemyController _enemyToProtect;
    private Vector3 _positionToProtect;
    private float _radius = 2;
    private float _defaultSpeed;
    private float _maxDistance = 25f;
    private float _minDistance = 0f;

    public EnemyProtectingState(EnemyStateMachine.EEnemyState state) : base(state)
    {   }

    public override void EnterState(StateManager<EnemyStateMachine.EEnemyState> enemy)
    {
        base.EnterState(enemy);
        _enemyToProtect = FindEnemyToProtect();
        Vector2 circle = Random.insideUnitCircle.normalized * _radius;
        _positionToProtect = new Vector3(circle.x, 0, circle.y);
        _defaultSpeed = _enemyController.Agent.speed;
    }
    public override void UpdateState(StateManager<EnemyStateMachine.EEnemyState> context)
    {  
        _enemyController.Agent.SetDestination(_enemyToProtect.transform.position + _positionToProtect);
        float t = Mathf.InverseLerp(_minDistance, _maxDistance, Vector2.Distance(_enemyController.transform.position, _enemyToProtect.transform.position));
        _enemyController.Agent.speed = Mathf.Lerp(_defaultSpeed, _defaultSpeed * 2f, t);
    }

    public override void ExitState(StateManager<EnemyStateMachine.EEnemyState> context)
    {
        _enemyController.Agent.speed = _defaultSpeed;
    }

    public override void FixedUpdateState(StateManager<EnemyStateMachine.EEnemyState> context)
    {   }

    public override EnemyStateMachine.EEnemyState GetNextState(StateManager<EnemyStateMachine.EEnemyState> context)
    {
        if (_enemyToProtect.CurrentState != EnemyStateMachine.EEnemyState.KILLING || _enemyToProtect == null)
            return EnemyStateMachine.EEnemyState.HUNTING;

        return EnemyStateMachine.EEnemyState.PROTECTING;
    }

    public override void OnDestroy()
    {   }

    private EnemyController FindEnemyToProtect()
    {
        foreach (var enemy in EntityManager.Instance.EnemyList)
        {
            if (enemy.CurrentState == EnemyStateMachine.EEnemyState.KILLING)
                return enemy;
        }

        return null;
    }
}
