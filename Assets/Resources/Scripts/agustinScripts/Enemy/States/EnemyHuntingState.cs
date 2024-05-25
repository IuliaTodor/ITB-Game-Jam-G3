using UnityEngine;

public class EnemyHuntingState : EnemyBaseState
{
    Transform prey;
    public EnemyHuntingState(EnemyStateMachine.EEnemyState state) : base(state) { }

    public override void EnterState(StateManager<EnemyStateMachine.EEnemyState> enemy)
    {
        base.EnterState(enemy);

        prey = FindPrey();
        _enemyController.Agent.SetDestination(prey.position);
    }

    public override void UpdateState(StateManager<EnemyStateMachine.EEnemyState> context)
    {
        _enemyController.Agent.SetDestination(prey.position);
    }

    public override void ExitState(StateManager<EnemyStateMachine.EEnemyState> context)
    {
        _enemyController.GrabedPrey = prey;
    }

    public override void FixedUpdateState(StateManager<EnemyStateMachine.EEnemyState> context)
    {   }

    public override EnemyStateMachine.EEnemyState GetNextState(StateManager<EnemyStateMachine.EEnemyState> context)
    {
        if (_enemyController.EnemyGrabHitbox.isEnemyGrabed)
            return EnemyStateMachine.EEnemyState.KILLING;
        else if (_enemyController.Killed)
            return EnemyStateMachine.EEnemyState.RUNING;

        return EnemyStateMachine.EEnemyState.HUNTING;
    }

    public override void OnDestroy()
    {   }


    private Transform FindPrey()
    {
        GameObject newPrey;

        GameObject[] preys = GameObject.FindGameObjectsWithTag("Prey");
        newPrey = preys[0];

        foreach (GameObject prey in preys) 
        {   
            if (Vector3.Distance(_enemyController.transform.position, prey.transform.position) <= Vector3.Distance(_enemyController.transform.position, newPrey.transform.position))
                newPrey = prey;

        }

        return newPrey.transform;
    }
}
