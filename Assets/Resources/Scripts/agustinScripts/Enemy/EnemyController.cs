using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour, IDamageable
{
    #region Parameters
    private Vector3 _startPosition;
    public Vector3 StartPosition { get { return _startPosition; } }

    [Header("State")]
    public EnemyStateMachine.EEnemyState CurrentState;
    private EnemyBaseState _enemyState;
    public EnemyBaseState EnemyState { set { _enemyState = value; } }

    [Space, Header("Parameters")]
    [SerializeField, Min(1)] private float _maxLife;
    [SerializeField, Min(1)] private float _currentLife;
    private bool _killed;
    public bool Killed { get { return _killed; } }

    [Space, Header("Components")]
    [SerializeField] NavMeshAgent _agent;
    public NavMeshAgent Agent { get { return _agent; } }

    [SerializeField] private EnemyGrabHitbox _enemyGrabHitbox;
    public EnemyGrabHitbox EnemyGrabHitbox { get { return _enemyGrabHitbox; } }
    [HideInInspector] public MipController GrabedPrey;
    #endregion

    private void Start()
    {
        _startPosition = transform.position;
        _currentLife = MaxLife;
    }

    private void OnDestroy()
    {
        _enemyState.OnDestroy();
    }

    #region IDamageable

    #region Parameters
    public float MaxLife { get => _maxLife; set => _maxLife = value; }
    public float CurrentLife { get => _currentLife; set => _currentLife = value; }
    #endregion

    public void TakeDamage(float damageTaken)
    {
        if (CurrentState is not EnemyStateMachine.EEnemyState.RUNING)
        {
            CurrentLife -= damageTaken;

            if (CurrentLife <= 0)
                Die();
        }
    }

    public void SetLife(float life)
    {
        CurrentLife = life;
    }

    public void Die()
    {
        _killed = true;
    }
    #endregion
}
