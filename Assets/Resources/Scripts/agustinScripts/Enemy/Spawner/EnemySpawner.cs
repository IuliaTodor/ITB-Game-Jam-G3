using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float _radius;
    [SerializeField] GameObject _enemyPrefab;

    [Space, Header("Spawn Time Related")]
    [SerializeField] private int _minScore;
    [SerializeField] private int _maxScore;
    [SerializeField] private float _currentTimer;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;
    private void Update()
    {
        float t = Mathf.InverseLerp(_maxScore, _minScore, score);
        float SpawnTime = Mathf.Lerp(_minSpawnTime, _maxSpawnTime, t);
        _currentTimer += Time.deltaTime;

        if (_currentTimer >= SpawnTime)
        {
            SpawnEnemy();
            _currentTimer = 0;
        }
    }

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
