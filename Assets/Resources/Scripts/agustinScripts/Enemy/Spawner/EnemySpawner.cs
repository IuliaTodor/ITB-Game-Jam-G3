using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float _radius;
    [SerializeField] GameObject _enemyPrefab;

    [ContextMenu("SpawnEnemy")]
    public void SpawnEnemy()
    {
        Vector2 circle = Random.insideUnitCircle.normalized * _radius;
        Vector3 _spawnPosition = new Vector3(circle.x, 0 , circle.y);

        Instantiate(_enemyPrefab, _spawnPosition + transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
