using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    private static EntityManager _instance;
    public static EntityManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != this && _instance != null)
            Destroy(gameObject);
        _instance = this;
    }
    private void Start()
    {
        EnemyList = new List<EnemyController>();
    }

    public List<MipController> MipsAlive;
    public List<EnemyController> EnemyList;

    public void RemoveMip(MipController mipController)
    {
        MipsAlive.Remove(mipController);
        if (MipsAlive.Count == 0)
            GameManager.Instance.GameOver();
    }
}
