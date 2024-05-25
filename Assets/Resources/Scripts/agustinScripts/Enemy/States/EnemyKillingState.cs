using UnityEngine;

public class EnemyKillingState : EnemyBaseState
{
    public EnemyKillingState(EnemyStateMachine.EEnemyState state) : base(state) {   }

    public override void EnterState(StateManager<EnemyStateMachine.EEnemyState> enemy)
    {
        base.EnterState(enemy);
        _enemyController.Agent.SetDestination(_enemyController.StartPosition);
        _enemyController.Anim.SetBool("grabbing", true);
    }
    
    public override void UpdateState(StateManager<EnemyStateMachine.EEnemyState> context)
    {
        if (Vector2.Distance(_enemyController.transform.position, _enemyController.StartPosition) <= 1)
            GameObject.Destroy(_enemyController.gameObject);
    }

    public override void ExitState(StateManager<EnemyStateMachine.EEnemyState> context)
    {  
        _enemyController.GrabedPrey.Release();
        _enemyController.EnemyGrabHitbox.gameObject.SetActive(false);
        _enemyController.Anim.SetBool("grabbing", false);
    }

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
        EntityManager.Instance.RemoveMip(_enemyController.GrabedPrey);
    }

}
