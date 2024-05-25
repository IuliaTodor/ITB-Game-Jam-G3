using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    #region Parameters
    private Vector3 _startPosition;
    public Vector3 StartPosition { get { return _startPosition; } }

    [Header("State")]
    public EnemyStateMachine.EEnemyState CurrentState;
    private EnemyBaseState _enemyState;
    public EnemyBaseState EnemyState { set { _enemyState = value; } }

    [Space, Header("Components")]
    [SerializeField] NavMeshAgent _agent;
    public NavMeshAgent Agent { get { return _agent; } }

    [SerializeField] private EnemyGrabHitbox _enemyGrabHitbox;
    public EnemyGrabHitbox EnemyGrabHitbox { get { return _enemyGrabHitbox; } }
    #endregion

    private void Start()
    {
        _startPosition = transform.position;
    }
}
