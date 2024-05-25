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

    public GameObject GameOverPanel;


    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (EntityManager.Instance != null)
            MipsAlive = EntityManager.Instance.MipsAlive.Count; 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("EndGame");
        DataManager.SaveData(score, playerName);
        Time.timeScale = 0f;
        GameOverPanel.SetActive(true);
    }
    
}
