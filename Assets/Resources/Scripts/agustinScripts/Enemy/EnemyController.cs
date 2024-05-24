using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStateMachine.EEnemyState CurrentState;
    private EnemyBaseState _enemyState;
    public EnemyBaseState EnemyState { set { _enemyState = value; } }
}
