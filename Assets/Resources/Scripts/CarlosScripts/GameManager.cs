using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public int score = 0;
    public int MipsAlive;
    public string playerName;
    [SerializeField] private EnemySpawner _spawner;

    [Space, Header("Spawn Time Related")]
    [SerializeField] private int _minScore;
    [SerializeField] private int _maxScore;
    [SerializeField] private float _currentTimer;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        MipsAlive = EntityManager.Instance.MipsAlive.Count;
    }

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

    private void SpawnEnemy()
    {
        _spawner.SpawnEnemy();
    }

    public void GameOver()
    {
        Debug.Log("EndGame");
        DataManager.SaveData(score, playerName);
    }
    
}
