using UnityEngine;

public class EnemyHuntingState : EnemyBaseState
{
    MipController prey;
    bool mustProtect;
    public EnemyHuntingState(EnemyStateMachine.EEnemyState state) : base(state) { }

    public override void EnterState(StateManager<EnemyStateMachine.EEnemyState> enemy)
    {
        base.EnterState(enemy);
        mustProtect = false;

        prey = FindPrey();

        if (!mustProtect)
            _enemyController.Agent.SetDestination(prey.transform.position);
    }

    public override void UpdateState(StateManager<EnemyStateMachine.EEnemyState> context)
    {
        if (!prey.isGrabbed && !mustProtect)
            _enemyController.Agent.SetDestination(prey.transform.position);
        else
            prey = FindPrey();
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
        else if (mustProtect)
            return EnemyStateMachine.EEnemyState.PROTECTING;

        return EnemyStateMachine.EEnemyState.HUNTING;
    }

    public override void OnDestroy()
    {   }

    private MipController FindPrey()
    {
        MipController newPrey = new MipController();

        MipController[] preys = EntityManager.Instance.MipsAlive.ToArray();

        foreach (MipController prey in preys) 
        {
            if (newPrey != null)
            {
                if (Vector3.Distance(_enemyController.transform.position, prey.transform.position) <= Vector3.Distance(_enemyController.transform.position, newPrey.transform.position) && !prey.isGrabbed)
                    newPrey = prey;
            }
            else if (!prey.isGrabbed)
            {
                newPrey = prey;
            }
        }

        if (newPrey == null)
        {
            mustProtect = true;
        }
        return newPrey;
    }
}
